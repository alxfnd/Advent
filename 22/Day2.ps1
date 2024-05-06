$WinArray = @(6,3,0,6,3)
$PlayArray = @("X","Z","Y","X","Z","Y")

$PlayValues = @{
    X = 1
    Y = 0
    Z = 2
}
$Play = New-Object -TypeName psobject -Property $PlayValues

$WinValues = @{
    X = 0
    Y = 2
    Z = 1
}
$Win = New-Object -TypeName psobject -Property $WinValues

$Advent = Get-Content .\Day2.txt

Function DeterminePlay {
    param(
        $Opponent,
        $Outcome
    )
    switch ($Opponent) {
        "B" { $ArrayStart = 0 }
        "A" { $ArrayStart = 1 }
        "C" { $ArrayStart = 2 }
    }
    $index = $Win.$Outcome
    switch ($Outcome) {
        "X" { return $PlayArray[$index + $ArrayStart] }
        "Y" { return $PlayArray[$index + $ArrayStart] }
        "Z" { return $PlayArray[$index + $ArrayStart] }
    }
}

Function Calculate {
    param(
        $Part2
    )
    $Total = 0
    foreach ($line in $Advent) {
        $line = $line.split(" ")
        $index = $Play.($line[1])
        if ($Part2 -eq 1) {
            $Shape = (DeterminePlay -Opponent $line[0] -Outcome $line[1])
            $index = $Play.$Shape
        }else{
            $Shape = $line[1]
        }
        switch ($Shape) {
            "X" { $Total += 1 }
            "Y" { $Total += 2 }
            "Z" { $Total += 3 }
        }
        switch ($line[0]) {
            "A" { $Total += $WinArray[$index] }
            "B" { $Total += $WinArray[$index + 1] }
            "C" { $Total += $WinArray[$index + 2] }
        }
    }
    return $Total
}

Write-Host "Question 1 answer is: "
Calculate -Part2 0
Write-Host "Question 2 answer is: "
Calculate -Part2 1