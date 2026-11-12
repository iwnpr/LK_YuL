[CmdletBinding()]
param()
$ErrorActionPreference = 'Stop'
$root = Split-Path (Split-Path $PSScriptRoot -Parent) -Parent
Push-Location $root
try {
    if (!(Test-Path '.env')) { throw 'Create .env from .env.example and choose local passwords first.' }
    docker compose up -d --wait postgres sqlserver
    if ($LASTEXITCODE -ne 0) { throw 'Database containers did not become healthy.' }
    docker compose run --rm --no-deps postgres-init
    if ($LASTEXITCODE -ne 0) { throw 'PostgreSQL initialization failed.' }
    docker compose run --rm --no-deps sqlserver-init
    if ($LASTEXITCODE -ne 0) { throw 'SQL Server initialization failed.' }
    Write-Host 'All five local databases are initialized.'
} finally {
    Pop-Location
}
