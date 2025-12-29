param(
	[Parameter(Mandatory=$True)]$Configuration,
	[Parameter(Mandatory=$True)]$TestSuite)

$ErrorActionPreference = 'Stop'
$ProgressPreference = 'SilentlyContinue'

$baseDir = Split-Path -Parent $PSCommandPath

. "$baseDir\include.ps1"

$frameworkVersion = 'net9.0'

function Prepare() {
	echo "=== $($MyInvocation.MyCommand.Name) ==="
	try {
		echo "=== END ==="
	}
	finally {
		popd
	}
}

function Cleanup() {
	Write-Host "=== $($MyInvocation.MyCommand.Name) ==="

	Write-Host "=== END ==="
}

function Tests-All() {
	#Tests-FirebirdClient-Defa
}

try {
	Prepare
	& $TestSuite
}
finally {
	Cleanup
}
