#Generate alphabet into array
$alphabet = @()
$alphabet += [char[]]([char]'a'..[char]'z')
$alphabet += [char[]]([char]'A'..[char]'Z')

<#
    Run through each line in puzzle
    Create an array to prevent duplicate outputs for that line
    Split the line in half
    Determine if any character from 1st exists in 2nd, if yes..
    Add that character to the duplicate array and the solution array to solve the puzzle later
Note: In Powershell, if you index a value that doesn't exist, it outputs -1
#>
$Advent = Get-Content .\Day3.txt
$SolutionChars = @()
foreach ($line in $Advent) {
    $PreventDuplicates = @()
    foreach ($c in $line[0..(($line.Length / 2) - 1)]) {
        if ($line[(($line.Length / 2))..$line.Length].IndexOf($c) -ne -1) {
            if ($PreventDuplicates.IndexOf($c)) {
                $PreventDuplicates += $c
                $SolutionChars += $c
            }
        }
    }
}

#Find index value of each char and +1 for true value
$TotalValue = 0
foreach ($c in $SolutionChars) {
    $TotalValue += $alphabet.IndexOf($c) + 1
}
"Question 1 answer is: $TotalValue"

#Part 2

#My theory is if there's only 1 char that matches all three lines..
#If you put all lines together and sort them, there will be 3 same chars in a row
#Find the 3 chars, that's your matching item
$Advent = Get-Content .\Day3.txt
$GroupCount = 0
[string]$ItemCheck = ''
$SolutionChars = @()
foreach ($line in $Advent) {
    #Only select unique values from the current line, then add to the pot
    $line = $line.ToCharArray() | Select -Unique
    $ItemCheck += $line
    #Add 3 lines to the array, then take action on 3rd line
    if ($GroupCount -eq 2) {
        $Current = 0
        $Count = 0
        #Sort all of the items in order, then remove all blank chars
        $ItemCheck = $ItemCheck.ToCharArray() | Sort
        $ItemCheck = $ItemCheck.Replace(' ','')
        #Scan through each item, if current item matches previous, then add 1 to Count
        #When Count = 2 (3 items), break the loop and add that char to solution array
        for ($Item = 0; $Item -ne $ItemCheck.Length; $Item++) {
            if ([int]$ItemCheck[$Item] -eq [int]$Current) {
                $Count++
                if ($Count -eq 2) {
                    $SolutionChars += $ItemCheck[$Item]
                    break
                }
            }else{
                $Count = 0
            }
            $Current = $ItemCheck[$Item]
        }
        $GroupCount = 0
        [string]$ItemCheck = ''
    }else{
        $GroupCount++
    }
}

#Calculate answer as we did previously
$TotalValue = 0
foreach ($c in $SolutionChars) {
    $TotalValue += $alphabet.IndexOf($c) + 1
}
"Question 2 answer is: $TotalValue"