function createResourceGroup([string]$name, [string]$location, [string]$sub)
    { az group create -n $name  -l $location --subscription $sub }

function deleteResourceGroup([string]$name, [string]$sub)
    { az group delete -n $name --subscription $sub }
# Service Plans 
function createServicePlan([string]$name, [string]$sku, [string]$rgroup, [string]$location, [string]$sub)
    { az appservice plan create -n $name --sku $sku  -g $rgroup -l $location --subscription $sub }

function deleteServicePlan([string]$name, [string]$rgroup, [string]$sub)
    { az appservice plan delete -n $name -g $rgroup --subscription $sub -y} # -y => Do not prompt for confirmation


# Key Vault
function createKeyVault([string]$name, [string]$rgroup, [string] $sub)
    { az keyvault create -n $name -g $rgroup --subscription $sub } 

function deleteKeyVault([string]$name, [string]$rgroup, [string] $sub)
    { az keyvault delete -n $name -g $rgroup --subscription $sub}