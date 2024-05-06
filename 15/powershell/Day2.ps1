$Advent = "10x9x8"
#$Advent = Get-Content .\15\Day2.txt

Function Lowest {
    param($l,$w,$h)
    if ($l -lt $w) {
        if ($l -lt $h) {
            return $l
        }elseif ($h -lt $w) {
            return $h
        }
    }elseif ($w -lt $h) {
        return $w
    }else{
        return $h
    }
}
Function Algorithm {
    param($dimensions)
    $dimensions = $dimensions.split("x")
    [int]$l = [int]$dimensions[0] * [int]$dimensions[1]
    [int]$w = [int]$dimensions[1] * [int]$dimensions[2]
    [int]$h = [int]$dimensions[0] * [int]$dimensions[2]
    $lowest = Lowest -l $l -w $w -h $h
    [int]$total = ((2 * $l) + (2 * $w) + (2 * $h)) + $lowest
    return $total
}

$SquareFeet = 0
$RibbonTotal = 0
foreach ($line in $Advent) {
    $SquareFeet += Algorithm -dimensions $line
    
    $line = $line.Split("x")
    $RL = $line
    $RLow = @()
    $RL.ForEach({$_;$RLow += [int]$_})
    $RLow = $RLow | Sort
    $RibbonTotal += (([int]$Rlow[0] + [int]$Rlow[0] + [int]$RLow[1] + [int]$RLow[1]) + ([int]$RLow[0] * [int]$RLow[1] * [int]$RLow[2]))
    #break
}
"Question 1 answer is: $SquareFeet"
"Question 2 answer is: $RibbonTotal"