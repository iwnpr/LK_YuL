[CmdletBinding()]
param()
$ErrorActionPreference = 'Stop'
$root = Split-Path (Split-Path $PSScriptRoot -Parent) -Parent
Push-Location $root
try {
    dotnet build "$PSScriptRoot/generator/SchemaGenerator.csproj" --nologo -m:1
    if ($LASTEXITCODE -ne 0) { throw 'Schema generator build failed.' }
    dotnet run --project "$PSScriptRoot/generator/SchemaGenerator.csproj" --no-build -- "$PSScriptRoot/sql"
    if ($LASTEXITCODE -ne 0) { throw 'SQL generation failed.' }
} finally {
    Pop-Location
}
