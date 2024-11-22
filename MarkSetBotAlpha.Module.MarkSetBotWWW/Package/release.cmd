del "*.nupkg"
"..\..\oqtane.framework\oqtane.package\nuget.exe" pack MarkSetBotAlpha.Module.MarkSetBotWWW.nuspec 
XCOPY "*.nupkg" "..\..\oqtane.framework\Oqtane.Server\Packages\" /Y

