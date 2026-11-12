[CmdletBinding()]
param()
$ErrorActionPreference = 'Stop'
$root = Split-Path (Split-Path $PSScriptRoot -Parent) -Parent
Push-Location $root
try {
    # Re-run bootstrap to verify restart safety and check the stored SQL fingerprints.
    docker compose run --rm --no-deps postgres-init
    if ($LASTEXITCODE -ne 0) { throw 'PostgreSQL repeat initialization failed.' }
    docker compose run --rm --no-deps sqlserver-init
    if ($LASTEXITCODE -ne 0) { throw 'SQL Server repeat initialization failed.' }
    docker compose run --rm --no-deps --entrypoint psql postgres-init -X -v ON_ERROR_STOP=1 -d postgres -f /bootstrap/postgres/verify.sql
    if ($LASTEXITCODE -ne 0) { throw 'PostgreSQL smoke check failed.' }
    docker compose run --rm --no-deps --entrypoint /opt/mssql-tools18/bin/sqlcmd sqlserver-init -S sqlserver -U sa -C -b -i /bootstrap/sqlserver/verify.sql
    if ($LASTEXITCODE -ne 0) { throw 'SQL Server smoke check failed.' }
    Write-Host 'Database smoke checks passed. Test rows were rolled back (identity sequences may advance).'
} finally {
    Pop-Location
}
