$string = "bgvyzdsv"
$value = 0

while ($true) {
    $stringAsStream = [System.IO.MemoryStream]::new()
    $writer = [System.IO.StreamWriter]::new($stringAsStream)
    $writer.write("$string$value")
    $writer.Flush()
    $stringAsStream.Position = 0
    if ((Get-FileHash -InputStream $stringAsStream -Algorithm MD5).Hash -like "000000*") {
        "$string$value"
        exit
    }
    $value++
}