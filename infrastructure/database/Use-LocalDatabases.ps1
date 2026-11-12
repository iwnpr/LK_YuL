# Run in the same PowerShell session as dotnet run. Overrides all project database connections.
[CmdletBinding()]
param()
$ErrorActionPreference = 'Stop'
$root = Split-Path (Split-Path $PSScriptRoot -Parent) -Parent
Push-Location $root
try {
    $configuration = docker compose config --format json | ConvertFrom-Json
    if ($LASTEXITCODE -ne 0) { throw 'Cannot read local Docker configuration. Check .env.' }
    $pg = $configuration.services.postgres
    $ms = $configuration.services.sqlserver
    foreach ($item in @{
        LegalPersons = 'legal_persons'
        BureauQBCH = 'bureau_qbch'
        BureauData = 'bureau_data'
    }.GetEnumerator()) {
        $connection = [System.Data.Common.DbConnectionStringBuilder]::new()
        $connection['Host'] = '127.0.0.1'
        $connection['Port'] = [string]$pg.ports[0].published
        $connection['Database'] = $item.Value
        $connection['Username'] = $pg.environment.POSTGRES_USER
        $connection['Password'] = $pg.environment.POSTGRES_PASSWORD
        [Environment]::SetEnvironmentVariable("ConnectionStrings__$($item.Key)", $connection.ConnectionString, 'Process')
    }
    foreach ($item in @{ BureauUsers = 'bureau_users'; BureauWebUI = 'bureau_web_ui' }.GetEnumerator()) {
        $connection = [System.Data.Common.DbConnectionStringBuilder]::new()
        $connection['Server'] = "127.0.0.1,$($ms.ports[0].published)"
        $connection['Database'] = $item.Value
        $connection['User Id'] = 'sa'
        $connection['Password'] = $ms.environment.MSSQL_SA_PASSWORD
        $connection['Encrypt'] = 'True'
        $connection['TrustServerCertificate'] = 'True'
        [Environment]::SetEnvironmentVariable("ConnectionStrings__$($item.Key)", $connection.ConnectionString, 'Process')
    }
    Write-Host 'Five ConnectionStrings overrides now point to local Docker databases in this PowerShell session.'
} finally {
    Pop-Location
}
