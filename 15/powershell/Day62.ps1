<#
Add-Type -AssemblyName System.Collections
Get-Variable | Remove-Variable -ErrorAction Ignore
$LightsArray = New-Object System.Collections.Generic.List[int]
$CountArray = New-Object System.Collections.Generic.List[int]
$LightsCount = @()
$AllLights = New-Object psobject
[string[]]$ActionTrack

$Advent = Get-Content C:\Users\alexf\OneDrive\Documents\AdventofCode\15\Day6.txt
$Before = Get-Date
for ($ind = 299; $ind -ne -1; $ind -= 1) {
    $ind
    $LightsArray.Clear()
    $CountArray.Sort()
    $line = $Advent[$ind].split(" ")
    if ($line[0] -eq "turn") {
        [string[]]$from = $line[2].Split(",")
        [int]$fromx = $from[0]; [int]$fromy = $from[1]
        [string[]]$to = $line[4].Split(",")
        [int]$tox = $to[0]; [int]$toy = $to[1]
            while($fromx -le $tox) {
                [int]$x = (('{0:d3}' -f $fromx)+('{0:d3}' -f [int]$from[1]))
                [int]$y = (('{0:d3}' -f $fromx)+('{0:d3}' -f [int]$to[1]))
                $LightsArray.AddRange([int[]]($x..$y))
                $CountArray.AddRange([int[]]($x..$y))
                $fromx++
            }
        if ($line[1] -eq "on") {
            Add-Member -InputObject $AllLights -MemberType NoteProperty -Name "$ind" -Value $LightsArray.ToArray()
        }else{
            Add-Member -InputObject $AllLights -MemberType NoteProperty -Name "$ind" -Value $LightsArray.ToArray()
        }
    }else{
        [string[]]$from = $line[1].Split(",")
        [int]$fromx = $from[0]; [int]$fromy = $from[1]
        [string[]]$to = $line[3].Split(",")
        [int]$tox = $to[0]; [int]$toy = $to[1]
        while($fromx -le $tox) {
                [int]$x = (('{0:d3}' -f $fromx)+('{0:d3}' -f [int]$from[1]))
                [int]$y = (('{0:d3}' -f $fromx)+('{0:d3}' -f [int]$to[1]))
                $LightsArray.AddRange([int[]]($x..$y))
                $CountArray.AddRange([int[]]($x..$y))
                $fromx++
            }
            Add-Member -InputObject $AllLights -MemberType NoteProperty -Name "$ind" -Value $LightsArray.ToArray()
    }
}

#$CountArray = $CountArray | Select -Unique

$ActionTrack = @()
for ($ind = 0; $ind -ne 300; $ind ++) {
    $line = $Advent[$ind].split(" ")
    if ($line[0] -eq "turn") {
        $ActionTrack += $line[1]
    }else{
        $ActionTrack += $line[0]
    }
}
#>
$Before = Get-Date
$CountList = @()
for ($i = 10000; $i -ne 15000; $i++) {
    
    if (! $CountArray.Contains($i)) {
        #continue
    }
    #$i
    for ($z = 299; $z -ne -1; $z -= 1) {
        foreach ($number in $AllLights.$z) {
            #$CountList += $i
            foreach ($n in $number) {
                $n
                break
            }
            break
        }
    }
    break
    if ($i -eq 15000) {
        break
    }
}
(Get-Date) - $Before