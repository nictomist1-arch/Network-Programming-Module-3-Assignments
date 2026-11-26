$ErrorActionPreference = 'Stop'
$vswhere = "${env:ProgramFiles(x86)}\Microsoft Visual Studio\Installer\vswhere.exe"
$msbuild = & $vswhere -latest -products * -requires Microsoft.Component.MSBuild -find 'MSBuild\**\Bin\MSBuild.exe' | Select-Object -First 1
if (!$msbuild) { throw 'Не найден MSBuild из Visual Studio.' }

$systemInclude = "${env:ProgramFiles(x86)}\Windows Kits\10\Include"
if (!(Test-Path $systemInclude)) {
    $version = '10.0.28000.2957'
    $cache = Join-Path $env:LOCALAPPDATA 'Codex\WindowsSdk'
    New-Item -ItemType Directory -Force $cache | Out-Null
    Add-Type -AssemblyName System.IO.Compression.FileSystem
    foreach ($id in @('microsoft.windows.sdk.cpp', 'microsoft.windows.sdk.cpp.x64')) {
        $destination = Join-Path $cache "$id.$version"
        if (!(Test-Path (Join-Path $destination 'build'))) {
            $package = Join-Path $cache "$id.$version.download.nupkg"
            Write-Host "Загрузка $id $version..."
            & curl.exe --fail --location --retry 3 --connect-timeout 20 --max-time 900 `
                "https://api.nuget.org/v3-flatcontainer/$id/$version/$id.$version.nupkg" --output $package
            if ($LASTEXITCODE -ne 0) { throw "Не удалось загрузить $id" }
            [System.IO.Compression.ZipFile]::ExtractToDirectory($package, $destination)
        }
    }
}

& $msbuild (Join-Path $PSScriptRoot 'NetworkHomeWork.sln') /t:Build /p:Configuration=Debug /p:Platform=x64 /verbosity:minimal /nologo
if ($LASTEXITCODE -ne 0) { throw 'Ошибка сборки.' }
