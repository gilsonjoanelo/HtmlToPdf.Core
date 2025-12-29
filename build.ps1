param(
	[Parameter(Mandatory=$True)]$Configuration)

$ErrorActionPreference = 'Stop'

$baseDir = Split-Path -Parent $PSCommandPath

. "$baseDir\include.ps1"

$outDir = "$baseDir\Output"

function Clean() {
	if (Test-Path $outDir) {
		rm -Force -Recurse $outDir
	}
	mkdir $outDir | Out-Null
}

function Build() {
	dotnet clean "$baseDir\src\HtmlToPdf.Core.slnx" -c $Configuration -v m
	dotnet build "$baseDir\src\HtmlToPdf.Core.slnx" -c $Configuration -p:ContinuousIntegrationBuild=true -v m
}

function Versions() {
	
}

function NuGets() {
	
}

Clean
Build
Versions
NuGets
