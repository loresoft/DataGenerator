@echo off
NuGet.exe install MSBuildTasks -OutputDirectory .\Tools\ -ExcludeVersion -NonInteractive
NuGet.exe install coveralls.net -OutputDirectory .\Tools\ -ExcludeVersion -NonInteractive
