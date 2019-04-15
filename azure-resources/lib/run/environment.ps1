. .\lib\azure\webapp.ps1
. .\lib\aggregates\sql.ps1
. .\lib\aggregates\webapp.ps1

function spinUpEnv([object]$splans, [object]$ai, [object]$sql, [object]$wa, [string]$rgroup, [string]$location, $sub) {
    # progress "Creating Application Insight" 30
    Write-Output "---> $splans"
    Write-Output "---> $ai"
    Write-Output "---> $sql"
    Write-Output "---> $wa"
    Write-Output "---> $rgroup"
    Write-Output "---> $location"
    Write-Output "---> $sub"

    Write-Output "$rgroup , $x"
    $rai = createApplicationInsights ($ai).name $rgroup $location $sub  | ConvertFrom-Json
    # progress "Creating Sql Server" 40
    $rsql = initSql $sql $rgroup $location $sub
    # # progress "Creating Web Apps" 80
    $rwa = initWebApps $wa ($rai).properties.InstrumentationKey $rgroup $sub
}


function addServicePlan([object]$wa, [string]$serviceplan ){
    foreach ($app in $wa.appList ){ ($app).serviceplan = $serviceplan }
    return $wa
}