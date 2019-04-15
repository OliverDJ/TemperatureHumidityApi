




Param(
    [parameter(mandatory=$true)][string]$file,
    [parameter(mandatory=$true)][string]$serviceplan,
    [parameter(mandatory=$true)][string]$resourcegroup,
    [parameter(mandatory=$true)][string]$location,
    [parameter(mandatory=$true)][string]$subscription,
    [parameter(mandatory=$true)][string]$command
)
# Import Libraries
. .\lib\opt\login.ps1
. .\lib\opt\printlib.ps1
. .\lib\run\environment.ps1

$json = Get-Content -Path $file | ConvertFrom-Json
$params = ($json).parameters

$splans = ($params).serviceplans
$ai = ($params).appinsights
$sql = ($params).sqlserver
$wa =  addServicePlan ($params).webapps $serviceplan

$resourcegroup = ($params).resourcegroup
$location = ($params).location
$subscription = ($params).subscription

Write-Output "$serviceplan"
Write-Output "$ai"
Write-Output "$sql"
Write-Output "$wa"
Write-Output "$resourcegroup"
Write-Output "$location"
Write-Output "$subscription"

#Program
if ( $command -eq "up" )
    { spinUpEnv $serviceplan $ai $sql $wa $resourcegroup $location $subscription }
# elseif ( $command -eq "down" )
#     { tearDownEnv $ai $sql $eh $sa $wa $af $resourcegroup $location $subscription }
