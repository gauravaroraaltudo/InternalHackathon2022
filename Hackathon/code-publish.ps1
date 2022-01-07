Function Find-MsBuild()
{
    $communityPath = "C:\Program Files (x86)\Microsoft Visual Studio\2019\Community\MSBuild\Current\Bin\MSBuild.exe"
    $professionalPath = "C:\Program Files (x86)\Microsoft Visual Studio\2019\Professional\MSBuild\Current\Bin\MSBuild.exe"

If (Test-Path $communityPath) 
    {
        $agentPath = $communityPath 
    }
    else
    {
        $agentPath= $professionalPath;
    }
    return $agentPath;
}

$msbuildPath = Find-MsBuild
cmd.exe /c "$msbuildPath" Hackathon.sln /t:Build /restore /m /p:DeployOnBuild=true /p:PublishProfile=FolderProfile /p:RestorePackages=true

cd app.publish
rm .\Web.config
cd ..
