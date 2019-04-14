

Param(
    [parameter(mandatory=$true)][string]$settings
)

$json = Get-Content -Path $settings | ConvertFrom-Json
$appname = ($json).appname
$pathtozip = ($json).pathtozip
$resourcegroup = ($json).resourcegroup

Write-Host "Deploying $pathtozip"
$deploy = az webapp deployment source config-zip -n $appname --src $pathtozip -g $resourcegroup --query "status"
# status 4 = success - status 3 = failed
if ([string]$deploy -ne '4') 
{ 
    Write-Error "Deployment Failed, see https://$appname.scm.azurewebsites.net/zipdeploy for details"; 
    EXIT 1 
} 

Write-Host "Successfully deployed $appname"