[CmdletBinding()]
param()
$ErrorActionPreference = 'Stop'
$root = Split-Path (Split-Path $PSScriptRoot -Parent) -Parent
Push-Location $root
try {
    if (!(Test-Path '.env')) { throw 'Create .env and run Start-Databases.ps1 first.' }
    docker compose build postgres-init sqlserver-init
    if ($LASTEXITCODE -ne 0) { throw 'Database initializer image build failed.' }
    # The two databases have independent transactions. Re-run if the second step fails.
    docker compose run --rm --no-deps --entrypoint /opt/mssql-tools18/bin/sqlcmd sqlserver-init -S sqlserver -U sa -C -b -d bureau_users -i /bootstrap/sql/seed/bureau_users.sql
    if ($LASTEXITCODE -ne 0) { throw 'SQL Server public seed failed.' }
    docker compose run --rm --no-deps --entrypoint psql postgres-init -X -v ON_ERROR_STOP=1 -d legal_persons -f /bootstrap/sql/seed/legal_persons.sql
    if ($LASTEXITCODE -ne 0) { throw 'PostgreSQL public seed failed.' }
    Write-Host 'Public seed completed. Initial login: localadmin; initial password: LocalAdmin_2026!'
    Write-Host 'Existing passwords, account status and grants were preserved. This fixture is for local development only.'
} finally {
    Pop-Location
}
