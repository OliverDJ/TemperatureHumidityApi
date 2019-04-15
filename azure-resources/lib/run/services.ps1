
. .\lib\azure\services.ps1
. .\lib\aggregates\services.ps1

function spinUpServices([string]$rgname, [object]$splans, [string]$location, [string]$sub) {
    $rg = createResourceGroup $rgname  $location $sub 
    $sp = initServicePlans $splans $rgname $location $sub | ConvertFrom-Json
    $spId = ($sp).id
    $r = "{`"serviceplan`": `"$spId`" , `"rgroup`": `" $rgname`", `"location`": `" $location`", `"subscription`": `" $sub`"}"
    return $r
}

function tearDownServices([string]$rgname, [object]$splans, [string]$location, [string]$sub){
    $sp = deleteServicePlans $splans $rgname $sub 
    #$rg = deleteResourceGroup $rgname $sub
    $r = "{`"serviceplan`": `"deleted`"}"
    return $r
}
