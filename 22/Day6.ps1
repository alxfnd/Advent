$Advent = "mjqjpqmgbljsphdztnvjfqwrcgsmlb"
$Advent = Get-Content .\22\Day6.txt

$PartOne = 0
$PartTwo = 0
foreach ($line in $Advent) {
    for ($i = 3; $i -le $line.length; $i++) {
        if (($line[($i - 3)..$i] | Select -Unique).Count -eq 4 -and $PartOne -eq 0) {
            "Answer to Question 1 is: "+ ($i + 1)
            $PartOne++
        }
        if (($line[($i - 13)..$i] | Select -Unique).Count -eq 14 -and $PartTwo -eq 0) {
            "Answer to Question 2 is: "+ ($i + 1)
            $PartTwo++
        }
        if ($PartOne -ne 0 -and $PartTwo -ne 0) {
            break
        }
    }
}