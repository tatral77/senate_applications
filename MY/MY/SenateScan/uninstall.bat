@echo off
rem Removes SenateScan for the current user.
taskkill /f /im SenateScan.exe >nul 2>&1
reg delete "HKCU\Software\Microsoft\Windows\CurrentVersion\Run" /v SenateScan /f >nul 2>&1
timeout /t 1 /nobreak >nul
rmdir /s /q "%LOCALAPPDATA%\SenateScan-App" >nul 2>&1
rmdir /s /q "%LOCALAPPDATA%\SenateScan" >nul 2>&1
echo SenateScan has been removed.
pause
