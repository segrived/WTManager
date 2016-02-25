@ECHO OFF

set TMPOUTDIR=%~dp0tmp_build

msbuild.exe /t:Build /p:Configuration=Release ^
    /property:Platform="Any CPU" ^
    /p:OutputPath="%TMPOUTDIR%" ^
    "%~dp0..\WTManager\WTManager.csproj"

if ERRORLEVEL 1 goto BUILDERROR

makensis /DTARGETDIR="%OUTDIR%" "%~dp0Setup.nsi"
goto OKEXIT

:BUILDERROR
echo Can't build project

:OKEXIT
@rd /S /Q "%TMPOUTDIR%" 2>nul
pause