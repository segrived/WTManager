msbuild.exe /t:MakeInstaller /p:Configuration=Release /property:Platform=x64 /p:OutputPath=tmp_build/x64 ..\WTManager\WTManager.csproj
msbuild.exe /t:MakeInstaller /p:Configuration=Release /property:Platform=x86 /p:OutputPath=tmp_build/x86 ..\WTManager\WTManager.csproj
@rd /S /Q ..\WTManager\tmp_build
pause