$LicenseHeader = @"
/*

 */
"@

$baseDir = Split-Path -Parent $PSCommandPath
#
#gci $baseDir -Recurse -Filter *.cs | %{
#	$content = gc $_.FullName -Encoding UTF8
#	$newContent = @()
#	
#	$started = $false
#	foreach ($line in $content) {
#		if ($line.StartsWith('//$Authors')) {
#			$started = $true
#			$line = $LicenseHeader + "`r`n`r`n" + $line
#		}
#		if ($started) {
#			$newContent += $line
#		}		
#	}
#	if (!$started) {
#		#echo $_.FullName
#		return
#	}
#
#	sc $_.FullName $newContent -Encoding UTF8
#}