function createWebApp ([string]$name, [string]$serviceplan, [string]$rgroup, [string]$sub) 
    { az webapp create -n $name -p $serviceplan -g $rgroup --subscription $sub}

function deleteWebApp ([string]$name, [string]$rgroup, [string]$sub)
    { az webapp delete -n $name -g $rgroup --subscription $sub }


function setAppSetting ([string]$name, [string]$settingName, [string]$settingValue ,[string]$rgroup, [string]$sub )
    { az webapp config appsettings set  -n $name --settings $settingName=$settingValue -g $rgroup --subscription $sub }


function createApplicationInsights([string]$name, [string]$rgroup, [string]$location, [string] $sub){
    az resource create -n $name -g $rgroup --resource-type "Microsoft.Insights/components" --properties '{\"Application_Type\":\"web\"}'
}

function deleteApplicationInsights([string]$name, [string]$rgroup, [string]$location, [string] $sub){
    az resource delete -n $name -g $rgroup --resource-type "Microsoft.Insights/components"
}
