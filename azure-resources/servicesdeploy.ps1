

Param(
    [parameter(mandatory=$true)][string]$file,
    [parameter(mandatory=$true)][string]$command
)

. .\lib\run\services.ps1

$json = Get-Content -Path $file | ConvertFrom-Json
$params = ($json).parameters
$rgname = ($params).resourcegroup
$location = ($params).location
$subscription = ($params).subscription
$splans = ($params).serviceplans


if ( $command -eq "up" )
    { $r = spinUpServices $rgname $splans $location $subscription }
elseif ( $command -eq "down" )
    { $r = tearDownServices $rgname $splans $location $subscription}
return $r | ConvertFrom-Json
