param(
	[Parameter(Mandatory=$True)]$Configuration,
	[Parameter(Mandatory=$True)]$TestSuite)

$ErrorActionPreference = 'Stop'
$ProgressPreference = 'SilentlyContinue'

$baseDir = Split-Path -Parent $PSCommandPath

. "$baseDir\include.ps1"

$frameworkVersion = 'net9.0'

function Prepare() {
	Write-Host "=== $($MyInvocation.MyCommand.Name) ==="
    pushd $baseDir
    Write-Host "=== END ==="
}

function Cleanup() {
	Write-Host "=== $($MyInvocation.MyCommand.Name) ==="
    popd
    Write-Host "=== END ==="
}

function Tests-All() {
	Write-Host "=== Running all tests ==="
    dotnet test "$baseDir\src\HtmlToPdf.Core.slnx" -c $Configuration --framework $frameworkVersion --logger "trx;LogFileName=TestResults.trx"
    Check-ExitCode
    Write-Host "=== Tests completed ==="
}

try {
	Prepare
	& $TestSuite
}
finally {
	Cleanup
}
