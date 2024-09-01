openfiles > NUL 2>&1 
if not %ERRORLEVEL% == 0 (
  powershell start-process \"%~f0\" -Verb runas
)

SignTool.exe sign /f C:\Users\shu-t\source\Syobosyobonn.pfx /t http://timestamp.digicert.com /p "shu.t1211" /fd SHA256 C:\Users\shu-t\source\repos\Syousetsu\ReadMultipleNovelFilesProject\bin\Debug\ReadMultipleNovelFilesProject.exe

SignTool.exe sign /f C:\Users\shu-t\source\Syobosyobonn.pfx /t http://timestamp.digicert.com /p "shu.t1211" /fd SHA256 C:\Users\shu-t\source\repos\Syousetsu\Syousetsu\bin\Debug\Syousetsu.exe

SignTool.exe sign /f C:\Users\shu-t\source\Syobosyobonn.pfx /t http://timestamp.digicert.com /p "shu.t1211" /fd SHA256 C:\Users\shu-t\source\repos\Syousetsu\Installer\Debug\Installer.msi