Write-Output "Null Output"
& .\NullTracer\bin\Release\NullTracer.exe "Scene.xml"
$t = 0
for($n = 0; $n -lt 3; ++$n) {
  $t += (Measure-Command {& .\NullTracer\bin\Release\NullTracer.exe "Scene.xml" }).Ticks
}
Write-Output $($t / 30000)


Write-Output "Jpeg Output"
& .\JpegTracer\bin\Release\JpegTracer.exe "Scene.xml"
$t = 0
for($n = 0; $n -lt 3; ++$n) {
  $t += (Measure-Command {& .\JpegTracer\bin\Release\JpegTracer.exe "Scene.xml" }).Ticks
}
Write-Output $($t / 30000)

Remove-Item .\output.jpg