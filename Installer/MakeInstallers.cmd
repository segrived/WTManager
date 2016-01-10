msbuild.exe /t:MakeInstaller /p:Configuration=Release /property:Platform=x64 /p:OutputPath=tmp_build/x64 ..\ServiceManager\ServiceManager.csproj
msbuild.exe /t:MakeInstaller /p:Configuration=Release /property:Platform=x86 /p:OutputPath=tmp_build/x86 ..\ServiceManager\ServiceManager.csproj
@rd /S /Q ..\ServiceManager\tmp_build
pause