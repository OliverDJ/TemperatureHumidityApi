function isLoggedIn{
    $r=az account show
    if($r){return $true}
    else{return $false}}

function handleLogin {
    $loggedIn =isLoggedIn
    if($loggedIn -eq $false){ensureLogin}
}
 function ensureLogin {az login}