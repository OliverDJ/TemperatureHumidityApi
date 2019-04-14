


# Web Apps 
function initWebApps([object]$wa, [string]$ik, [string]$rgroup, [string]$sub){
    foreach ($app in ($wa).appList)  { 
        createWebApp ($app).name ($app).serviceplan $rgroup $sub
        setAppSetting ($app).name ($wa).applicationInsightKeyName $ik $rgroup $sub #Adding Application Insights
        foreach ($setting in ($app).appSettings){
            setAppSetting ($app).name ($setting).name ($setting).value $rgroup $sub
        }
    }
}


function deleteWebApps([object]$wa, [string]$rgroup, [string]$sub){
    foreach ($app in ($wa).appList)  { 
        deleteWebApp ($app).name $rgroup $sub
    }
}