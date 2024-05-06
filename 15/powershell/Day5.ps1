$Advent = "ieodomkazucvgmuy"
$Advent = Get-Content .\15\Day5.txt
$Vowels = @("a","e","i","o","u")
$Total = 0

<#
Function CheckVowel {
    param($line)
    $Count = 0
    foreach ($v in $Vowels) {
        for ($i = 0; $i -lt $line.length; $i++) {
            if ($line[$i] -eq $v) {
                $Count++
            }
        }
        if ($Count -ge 3) {
            return $true
        }
    }
}

foreach ($line in $Advent) {
    if ($line -notmatch '(.)\1{1}') {
        continue
    }
    if ($line -match '(ab|cd|pq|xy)') {
        continue
    }
    if (!(CheckVowel -line $line)) {
        continue
    }
    $Total++
}

$Total
#>
$Total2 = 0

foreach ($line in $Advent) {
    $newline = 0
    for ($i = 0; $i -lt $line.Length; $i++) {
        if (!($line[$i] -eq $line[$i + 2] -and $line[$i] -ne $line[$i + 1])) {
            $newline = 1
        }else{
            $newline = 0
            break
        }
    }
    if ($newline -eq 0) {
        for ($i = 0; $i -le ($line.Length - 2); $i++) {
            if ($line.Substring(($i+2),($line.length - ($i + 2))).IndexOf($line[$i]+$line[$i+1]) -ne -1) {
                $line
                $string = $line[$i]+$line[$i+1]
                $string
                $Total2++
                break
            }
        }
    }
}
$Total2