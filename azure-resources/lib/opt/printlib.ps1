
function azureArt{
    clear
    Write-Output "`n`n`n`n`n`n"
    Write-Output "     /\"
    Write-Output "    /  \    _____   _ _ __ ___"
    Write-Output "   / /\ \  |_  / | | | \'__/ _ \"
    Write-Output "  / ____ \  / /| |_| | | |  __/"
    Write-Output " /_/    \_\/___|\__,_|_|  \___|"
    Write-Output "-----------------------------------`n`n`n"
}


function teardownArt {
    Write-Output " _____             _             ___                   "
    Write-Output "|_   _|__ __ _ _ _(_)_ _  __ _  |   \ _____ __ ___ _  "
    Write-Output "  | |/ -_) _ ` | '_| | ' \/ _`  | | |) / _ \ V  V / ' \ "
    Write-Output "  |_|\___\__,_|_| |_|_||_\__, | |___/\___/\_/\_/|_||_|"
    Write-Output "                         |___/                        `n`n"

}

function spinUpArt {
    Write-Output " ___      _           _             _   _       "
    Write-Output "/ __|_ __(_)_ _  _ _ (_)_ _  __ _  | | | |_ __ "
    Write-Output "\__ \ '_ \ | ' \| ' \| | ' \/ _`  | | |_| | '_ \"
    Write-Output "|___/ .__/_|_||_|_||_|_|_||_\__, |  \___/| .__/"
    Write-Output "    |_|                     |___/        |_|   `n`n"
}


function progress([string]$a, [int]$p){
    Write-Progress -Activity $a -Status "$p% Complete:" -PercentComplete $p;
}