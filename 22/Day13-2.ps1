#cls

Function CompIntArray([int[]]$left, [int[]]$right) {
    $small = $left.Length
    if ($left.Length -lt $right.Length) {
        $small = $left.Length
        $val = 1
    }elseif($left.Length -gt $right.Length) {
        $small = $right.Length
        $val = 2
    }
    $count = 0
    while ($count -lt $small) {
        if ($left[$count] -lt $right[$count]) {
            #left failed - correct order
            return 1
        }
        if ($left[$count] -gt $right[$count]) {
            #right failed - incorrect order
            return 2
        }
    }
    if ($left.Length -eq $right.Length) {
        #all matched, return "continue"
        return 0
    }else{
        #one side expired, return "winning" side
        return $val
    }
}

Function CountBrackets($left, $right) {
    
}

Function FindArray($string, $count) {
    # starting to think we need to first calculate all possible arrays, add them to a vector type list, then iterate through those and compare
    # it's like the int values are the last thing we need to worry about!
}

$AdventInput = Get-Content "C:\Users\alexf\OneDrive\Documents\AdventofCode\22\Day13.txt"
$Advent = @()
foreach ($line in $AdventInput) {
    $Advent += $line
    
}
$Advent += ""
$TotalCompare = $Advent.Length / 3
$CurrentCompare = 1
$PairArray = @(102, 34, 21)
$Advent = $Advent | ? {$_ -ne ""}
$Advent += "[[2]]"
$Advent += "[[6]]"
$count = 0
$lv = 1
$valarr = @()


foreach ($val in $Advent) {
    $l2 = $val.Replace("[","")
    $l2 = $l2.Replace("]","")
    $l2 = $l2.Split(",")
    $string = ""
    foreach ($v in $l2) {
        $string += $v
    }
    
    if ($string.Length -ne 10) {
        while ($string.Length -lt 9) {
            $string += "0"
        }
    }
    $valarr += [int]$string
}

#$valarr | Sort


while ($count -lt 7) {
    if ($count -eq 0) {
        foreach ($l in $Advent) {
            if ($l.split(",")[0] -notmatch '[0-9]') {
                $lv
                $lv++
                $l
            }
        }
    }else{
        $secondcount = 0
        while ($secondcount -lt 9) {
            foreach ($l in $Advent) {
                if ($l -match '[0-9]') {
                    $l2 = $l.Replace("[","")
                    $l2 = $l2.Replace("]","")
                    $l2 = $l2.Split(",")
                    if ([int]$l2[0] -eq $count -and [int]$l2[1] -eq $secondcount) {
                        $lv
                        $lv++
                        $l
                    }
                }
            }
            $secondcount++
        }
    }
    $count++
}
#$PairArray = @()
<#
while ($CurrentCompare -le $TotalCompare) {
    $CompareInd = ($CurrentCompare - 1) * 3
    $left = $Advent[$CompareInd]
    $right = $Advent[$CompareInd + 1]
    $initleft = $left.Split(",")[0]
    $initright = $right.Split(",")[0]
    #Compare initial values and save some hassle
    
    if ($initleft -notmatch '[0-9]' -and $initright -match '[0-9]') {
        "Right is correct"
        $PairArray += $CurrentCompare
        $CurrentCompare++
        #"skip"
        continue
    }
    if ($initleft -match '[0-9]' -and $initright -notmatch '[0-9]') {
        "Right is wrong"
        $CurrentCompare++
        #"skip"
        continue
    }
    if ($initleft -notmatch '[0-9]' -and $initright -notmatch '[0-9]') {
        $lbcount = $initleft.ToCharArray() | ? {$_ -eq "["} | Measure | Select -exp Count
        $rbcount = $initright.ToCharArray() | ? {$_ -eq "["} | Measure | Select -exp Count
        if ($lbcount -lt $rbcount) {
            "Right is correct"
            $PairArray += $CurrentCompare
            $CurrentCompare++
            #"skip"
            continue
        }else{
            "Right is wrong"
            $CurrentCompare++
            #"skip"
            continue
        }
    }


    if (!($initleft.Contains("10") -or $initright.Contains("10"))) {
    
    # Get int arrays, then count them
    $leftints = $left.ToCharArray() | ? {$_ -match '[0-9]'}
    $rightints = $right.ToCharArray() | ? {$_ -match '[0-9]'}
    $leftintscount = $leftints.Count
    $rightintscount = $rightints.Count

    #compare first ints
    if ($leftints[0] -lt $rightints[0]) {
        "Right is correct"
        $PairArray += $CurrentCompare
        $CurrentCompare++
        continue
    }elseif($leftints[0] -gt $rightints[0]) {
        "Right is wrong"
        $CurrentCompare++
        continue
    }
    }else{
            $left2 = $initleft.Replace("[","")
            $left2 = $left2.Replace("]","")
            $lvalue = [int]$left2.split(",")[0]
            $right2 = $initright.Replace("[","")
            $right2 = $right2.Replace("]","")
            $rvalue = [int]$right2.split(",")[0]
            if ($lvalue -lt $rvalue) {
                "Right is correct"
                $PairArray += $CurrentCompare
            }elseif($lvalue -gt $rvalue) {
                "Right is wrong"
            }
            $CurrentCompare++
            continue
    }
    ###
    # left bracket count
    $lbcount = $left.ToCharArray() | ? {$_ -eq "["} | Measure | Select -exp Count
    $rbcount = $right.ToCharArray() | ? {$_ -eq "["} | Measure | Select -exp Count

    if ($lbcount -ge $rbcount) {
        $totalarrays = $lbcount
    }else{
        $totalarrays = $rbcount
    }
    # We now know which side has more arrays in its string

    # Now look at each array and compare the int values
    # First get the first array

    
    

    "needs a look: " + $CurrentCompare
    $left
    $right
    $CurrentCompare++
    Continue

    #This doesn't work for arrays without ints
    switch($leftintscount) {
        {$_ -lt $rightintscount} { $ForCount = $rightintscount  }
        {$_ -eq $rightintscount} { $ForCount = $_  }
        {$_ -gt $rightintscount} { $ForCount = $_ }
    }

    #
    $FCounter = 0

    if ($leftintscount -eq 0 -and $rightintscount -eq 0) {
        if ($lbcount -lt $rbcount) {
            $Output = $true
        }else{
            $Output = $false
        }
        if ($Output -eq $true) {
            #"Right is correct"
        }else{
            #"Right is wrong"
        }
        "bracket compare"
        $CurrentCompare++
        continue
    }

    while ($FCounter -lt $ForCount) {        
        if ($leftintscount -lt ($FCounter + 1)) {
            $Output = $true
            break
        }
        if ($rightintscount -lt ($FCounter + 1)) {
            $Output = $false
            break
        }
        if ($leftints[$FCounter] -eq $rightints[$FCounter]) {
            $FCounter++
            continue
        }
        if ($leftints[$FCounter] -lt $rightints[$FCounter]) {
            $Output = $true
            break
        }else{
            $Output = $false
            break
        }
    }
    if ($Output -eq $true) {
        #"Right is correct"
    }else{
        #"Right is wrong"
    }
    $CurrentCompare++
}
$PairArray
$answer = 0
foreach ($i in $PairArray) {
    $answer += $i
}
$answer
#>

# 5278 low
# 5350

#2

#2014 - low - 106 * 19
# 2289 - low - 109 * 21
# 14110 - low - 83 * 170
# 14705