function Check-ExitCode() {
	$exitCode = $LASTEXITCODE
	    if ($exitCode -ne 0) {
        Write-Error "❌ Non-zero exit code detected: $exitCode"
        exit $exitCode
    } else {
        Write-Host "✅ Exit code $exitCode (success)"
    }
}