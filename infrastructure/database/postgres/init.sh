#!/usr/bin/env bash
set -euo pipefail

for database in legal_persons bureau_qbch bureau_data; do
    psql -X -v ON_ERROR_STOP=1 -d postgres -v database="$database" <<'SQL'
SELECT format('CREATE DATABASE %I', :'database')
WHERE NOT EXISTS (SELECT FROM pg_database WHERE datname = :'database')\gexec
SQL
    schema="/bootstrap/sql/$database.sql"
    fingerprint=$(sha256sum "$schema" | cut -d ' ' -f 1)
    initialized=$(psql -X -At -v ON_ERROR_STOP=1 -d "$database" -c "SELECT to_regclass('public.__local_bootstrap') IS NOT NULL")
    if [[ "$initialized" == t ]]; then
        previous=$(psql -X -At -v ON_ERROR_STOP=1 -d "$database" -c 'SELECT fingerprint FROM public.__local_bootstrap')
        if [[ "$previous" != "$fingerprint" ]]; then
            echo "Schema changed for $database. Apply a reviewed migration or recreate the local volume; bootstrap does not upgrade databases." >&2
            exit 1
        fi
        echo "$database: already initialized"
        continue
    fi
    # Schema and marker commit together. A failed initialization can safely be retried.
    {
        cat <<'SQL'
DO $$ BEGIN
    IF EXISTS (SELECT FROM information_schema.tables WHERE table_schema NOT IN ('pg_catalog', 'information_schema')) THEN
        RAISE EXCEPTION 'Refusing to bootstrap a non-empty, unmanaged database';
    END IF;
END $$;
SQL
        cat "$schema"
        printf '\nCREATE TABLE public.__local_bootstrap (fingerprint text NOT NULL);\n'
        printf "INSERT INTO public.__local_bootstrap VALUES ('%s');\n" "$fingerprint"
    } > /tmp/bootstrap.sql
    psql -X -v ON_ERROR_STOP=1 --single-transaction -d "$database" -f /tmp/bootstrap.sql
    echo "$database: initialized"
done
