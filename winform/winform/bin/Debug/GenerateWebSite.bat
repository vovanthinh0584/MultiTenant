@echo off

xcopy /S /I /Q /Y /F %1 %2

rename %2 %3

"C:\Windows\System32\inetsrv\appcmd.exe"  add site /name:%4 /bindings:%5 /physicalPath:%6

"C:\Windows\System32\inetsrv\appcmd.exe" start site %4
 
pause

