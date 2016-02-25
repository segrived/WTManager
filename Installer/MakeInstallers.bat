@ECHO OFF

pushd %~dp0

set TMPOUTDIR=%~dp0%tmp_build

msbuild.exe /t:Build /p:Configuration=Release ^
    /property:Platform="Any CPU" ^
    /p:OutputPath="%TMPOUTDIR%" ^
    "..\WTManager\WTManager.csproj"

if ERRORLEVEL 1 goto BUILDERROR

makensis /DTARGETDIR="%TMPOUTDIR%" Setup.nsi
goto OKEXIT

:BUILDERROR
echo Can't build project

:OKEXIT
@rd /S /Q "%TMPOUTDIR%" 2>nul
popd