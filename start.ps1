$wtid     = "MicroService"
$dossiers = @(, "GatewayService", "TaskService", "UserService")
$cmd      = 'powershell -noExit "dotnet watch"'

wt -w $wtid -d ./MicroService powershell "Invoke-Item MicroService.sln"


for ($k=0; $k -lt $dossiers.Length; $k++)
{
    Invoke-Expression "wt -w $wtid --title '$($dossiers[$k])' -d ./MicroService/$($dossiers[$k]) $cmd"
}

