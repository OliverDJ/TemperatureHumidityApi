


function initServicePlans ( [object]$serviceplans, [string]$rgroup, [string]$location, [string]$sub )
    { foreach($plan in $serviceplans){ createServicePlan ($plan).name ($plan).sku $rgroup $location $sub }}

function deleteServicePlans ([object]$serviceplans, [string]$rgroup, [string]$sub )
    { foreach($plan in $serviceplans){ deleteServicePlan ($plan).name $rgroup $sub } }