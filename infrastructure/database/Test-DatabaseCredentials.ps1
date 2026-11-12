# Read-only diagnostics. Password values are never printed.
[CmdletBinding()]
param()
$ErrorActionPreference = 'Stop'
$root = Split-Path (Split-Path $PSScriptRoot -Parent) -Parent
Push-Location $root
try {
    $config = docker compose config --format json | ConvertFrom-Json
    if ($LASTEXITCODE -ne 0) { throw 'Cannot read Compose configuration.' }
    $containerId = docker compose ps -q sqlserver
    if ($LASTEXITCODE -ne 0 -or !$containerId) { throw 'SQL Server container is not running.' }
    $inspection = docker inspect $containerId | ConvertFrom-Json
    if ($LASTEXITCODE -ne 0) { throw 'Cannot inspect SQL Server container.' }
    $server = @($inspection)[0]
    $passwordEntry = @($server.Config.Env | Where-Object { $_.StartsWith('MSSQL_SA_PASSWORD=') })
    if ($passwordEntry.Count -ne 1) { throw 'Cannot locate the container password setting.' }
    $containerPassword = $passwordEntry[0].Substring('MSSQL_SA_PASSWORD='.Length)
    $configuredPassword = [string]$config.services.sqlserver.environment.MSSQL_SA_PASSWORD
    $seedPassword = [string]$config.services.'sqlserver-init'.environment.SQLCMDPASSWORD
    Write-Host ('Container status: ' + $server.State.Status)
    Write-Host ('Container health: ' + $server.State.Health.Status)
    Write-Host ('Compose password matches container setting: ' + ($configuredPassword -ceq $containerPassword))
    Write-Host ('Seed password matches Compose server setting: ' + ($seedPassword -ceq $configuredPassword))

    # Use the password saved in the running container, then the one used by seed.
    # Passing it as an environment override avoids command-line quoting of special characters.
    docker compose exec -T -e "SQLCMDPASSWORD=$containerPassword" sqlserver /opt/mssql-tools18/bin/sqlcmd -S localhost -U sa -C -b -l 10 -Q 'SET NOCOUNT ON; SELECT 1 AS connection_ok;'
    $containerLogin = $LASTEXITCODE -eq 0
    Write-Host ('Login with container password: ' + $containerLogin)
    docker compose exec -T -e "SQLCMDPASSWORD=$seedPassword" sqlserver /opt/mssql-tools18/bin/sqlcmd -S localhost -U sa -C -b -l 10 -Q 'SET NOCOUNT ON; SELECT 1 AS connection_ok;'
    $seedLogin = $LASTEXITCODE -eq 0
    Write-Host ('Login with seed password: ' + $seedLogin)
    if ($containerLogin -and !$seedLogin) {
        Write-Host 'The running server accepts its original container password, but seed uses a different value. Restore that original password in .env; do not remove volumes.'
    } elseif (!$containerLogin -and !$seedLogin) {
        Write-Host 'Neither setting matches the stored SQL Server login. The volume may predate this container, or the login was changed/disabled. An existing working SQL login is needed to repair it without deleting data.'
    } elseif ($seedLogin) {
        Write-Host 'The seed password works locally. Check the initializer connection next (network/server resolution).'
    }
} finally {
    Pop-Location
}
