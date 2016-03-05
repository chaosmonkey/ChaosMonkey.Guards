param(
    [string] $version,
	[string]$branch
    )
if($branch -ne "master"){ $version += "-Pre"}
Write-Host("Building branch '" + $branch + "' as version '" + $version + "'")
$nuspec = Get-ChildItem "ChaosMonkey.Guards.nuspec" -recurse | Select-Object -First 1
$content = Get-Content($nuspec)
$content = $content -replace '\$version\$', $version
$content | Out-File $nuspec
& NuGet.exe pack $nuspec