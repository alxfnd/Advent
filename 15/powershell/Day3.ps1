$Advent = "^v^v^v^v^v"
$Advent = Get-Content .\15\Day3.txt

Remove-Variable -Name x* -ErrorAction Ignore

[int]$x = 0
[int]$y = 0
[int]$santax = 0
[int]$santay = 0
[int]$robox = 0
[int]$roboy = 0

Set-Variable -Name x$x`y$y -Value 2

for ($i = 0; $i -lt $Advent.Length; $i++) {
    if (($i / 2).GetType().Name -eq 'Int32') {
        $x = $santax
        $y = $santay
        switch ($Advent[$i]) {
            "^" {$y++; $santay++}
            ">" {$x++; $santax++}
            "<" {$x--; $santax--}
            "v" {$y--; $santay--}
        }
        if (Get-Variable -Name x$x`y$y -ErrorAction Ignore) {
            Set-Variable -Name x$x`y$y -Value ((Get-Variable x$x`y$y).Value + 1)
        }else{
            New-Variable -Name x$x`y$y -Value 1
        }
    }else{
        $x = $robox
        $y = $roboy
        switch ($Advent[$i]) {
            "^" {$y++; $roboy++}
            ">" {$x++; $robox++}
            "<" {$x--; $robox--}
            "v" {$y--; $roboy--}
        }
        if (Get-Variable -Name x$x`y$y -ErrorAction Ignore) {
            Set-Variable -Name x$x`y$y -Value ((Get-Variable x$x`y$y).Value + 1)
        }else{
            New-Variable -Name x$x`y$y -Value 1
        }
    }
}

((Get-Variable -Name x*).Name | Measure | Select -exp Count) - 1