#!/usr/bin/env bash
set -euo pipefail
sqlcmd=(/opt/mssql-tools18/bin/sqlcmd -S sqlserver -U sa -C -b -r 1 -l 30)

for database in bureau_users bureau_web_ui; do
    "${sqlcmd[@]}" -d master -Q "IF DB_ID(N'$database') IS NULL EXEC(N'CREATE DATABASE [$database]');"
    schema="/bootstrap/sql/$database.sql"
    fingerprint=$(sha256sum "$schema" | cut -d ' ' -f 1)
    initialized=$("${sqlcmd[@]}" -d "$database" -h -1 -W -Q "SET NOCOUNT ON; SELECT CASE WHEN OBJECT_ID(N'dbo.__local_bootstrap', N'U') IS NULL THEN 0 ELSE 1 END;" | tr -d '[:space:]')
    if [[ "$initialized" == 1 ]]; then
        previous=$("${sqlcmd[@]}" -d "$database" -h -1 -W -Q 'SET NOCOUNT ON; SELECT fingerprint FROM dbo.__local_bootstrap;' | tr -d '[:space:]')
        if [[ "$previous" != "$fingerprint" ]]; then
            echo "Schema changed for $database. Apply a reviewed migration or recreate the local volume; bootstrap does not upgrade databases." >&2
            exit 1
        fi
        echo "$database: already initialized"
        continue
    fi
    {
        cat <<'SQL'
SET XACT_ABORT ON;
IF EXISTS (SELECT 1 FROM sys.tables WHERE is_ms_shipped = 0)
    THROW 51000, 'Refusing to bootstrap a non-empty, unmanaged database', 1;
BEGIN TRANSACTION;
GO
SQL
        cat "$schema"
        printf '\nCREATE TABLE dbo.__local_bootstrap (fingerprint varchar(64) NOT NULL);\n'
        printf "INSERT INTO dbo.__local_bootstrap VALUES ('%s');\n" "$fingerprint"
        printf 'COMMIT TRANSACTION;\nGO\n'
    } > /tmp/bootstrap.sql
    "${sqlcmd[@]}" -d "$database" -i /tmp/bootstrap.sql
    echo "$database: initialized"
done
