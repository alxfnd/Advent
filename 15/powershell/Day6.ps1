$Lights = ""
$Count = 0
$Advent = Get-Content .\15\Day6.txt
$Before = Get-Date
foreach ($line in $Advent) {
    $Count++
    $line = $line.split(" ")
    if ($line[0] -eq "turn") {
        [string[]]$from = $line[2].Split(",")
        [int]$fromx = $from[0]; [int]$fromy = $from[1]
        [string[]]$to = $line[4].Split(",")
        [int]$tox = $to[0]; [int]$toy = $to[1]
        if ($line[1] -eq "on") {
            while($fromx -le $tox) {
                while($fromy -le $toy) {
                    $Lights = $Lights+"x"+$fromx+"y"+$fromy
                    $fromy++
                }
                $fromx++
                $fromy = $from[1]
            }
        }else{
            while($fromx -le $tox) {
                while($fromy -le $toy) {
                    if ($Lights.IndexOf(("x"+$fromx+"y"+$fromy)) -ne -1) {
                        $Lights.Remove(($Lights.IndexOf(("x"+$fromx+"y"+$fromy)),8))
                    }
                    $fromy++
                }
                $fromx++
                $fromy = $from[1]
            }
        }
    }else{
    }
    if ($Count -eq 3) {
        break
    }
}
($Lights.Split("y").Count) - 1

(Get-Date) - $Before