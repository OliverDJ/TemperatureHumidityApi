

. .\lib\azure\sql.ps1
function initSql ([object]$sql, [string]$rgroup, [string]$location, [string]$sub) {
    $fr = ($sql).firerule # fr: firerule
    createServer ($sql).name ($sql).user ($sql).password $rgroup $location $sub
    setFirewallRuleAllAccess ($fr).name ($sql).name ($fr).startip ($fr).endip $rgroup $sub
    foreach ($db in ($sql).databases)  {  
       createDb ($db).name ($sql).name $rgroup $sub
       runSql ($sql).name ($db).name ($sql).user ($sql).password ($db).sqlfilepath }
    #deleteFirewallRuleAllAccess ($fr).name ($sql).name $rgroup $sub
}

