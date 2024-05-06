$Advent = Get-Content ".\15\Day1.txt"
$FloorNumber = 0
$Position = 0
for ([int]$i = 0; $i -lt $Advent.Length; $i++) {
    switch ($Advent[$i]) {
        ")" {$FloorNumber--}
        "(" {$FloorNumber++}
    }
    if ($FloorNumber -eq -1 -and $Position -eq 0) {
        $Position = $i
    }
}
$FloorNumber
$Position + 1