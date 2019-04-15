


Param(
    [parameter(mandatory=$true)][string]$bluefile,
    [parameter(mandatory=$true)][string]$greenfile,
    [parameter(mandatory=$true)][string]$command
)


. .\lib\opt\login.ps1
. .\lib\opt\printlib.ps1

handleLogin # Ensures login
azureArt # Ascii Art (Azure)

if ($command -eq "up"){
    spinUpArt
    $services = .\servicesdeploy.ps1 -file $bluefile -command $command
    $serviceplan = ($services).serviceplan
    $resourcegroup = ($services).rgroup
    $location = ($services).location
    $subscription = ($services).subscription
    .\envdeploy.ps1 -file $greenfile -serviceplan $serviceplan -resourcegroup $resourcegroup -location $location -subscription $subscription -command $command
}
elseif($command -eq "down"){
    teardownArt
    #.\envdeploy.ps1 -file $greenfile -command $command -serviceplan "dummy"
    $services = .\servicesdeploy.ps1 -file $bluefile -command $command
}
