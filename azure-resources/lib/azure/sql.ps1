

# Sql Server
function createServer([string]$name,[string]$user, [string]$pass, [string]$rgroup, [string]$location, [string]$sub) 
    { az sql server create -n $name -u $user -p $pass -g $rgroup -l $location --subscription $sub }
function deleteServer([string]$name, [string]$rgroup, [string]$sub) 
    { az sql server delete -n $name -g $rgroup --subscription $sub -y } # -y => Do not prompt for confirmation

# Database
function createDb([string]$name, [string]$server, [string]$rgroup, [string]$sub) 
    { az sql db create -n $name -s $server -g $rgroup --subscription $sub  --service-objective S0}

function deleteDb( [string]$name, [string]$server,[string]$rgroup, [string]$sub) 
    { az sql db delete -n $name -s $server -g $rgroup --subscription $sub }

# Firewall
function setFirewallRuleAllAccess([string]$name, [string]$server, [string]$startip , [string]$endip , [string]$rgroup, [string]$sub) 
    { az sql server firewall-rule create -n $name --server $server --start-ip-address $startip --end-ip-address $endip -g $rgroup --subscription $sub }
function deleteFirewallRuleAllAccess([string]$name, [string]$server, [string]$rgroup, [string]$sub) 
    { az sql server firewall-rule delete -n $name --server $server --resource-group $rgroup --subscription $sub }

# Sql Commander
function runSql([string]$server,[string]$db, [string]$user, [string]$pass, [string]$sqlFilePath)
    { $Env:DB_NAME=$db; sqlcmd -S "$server.database.windows.net" -d $db -U $user -P $pass -i $sqlFilePath  -f 65001 ; $Env:DB_NAME=""} 