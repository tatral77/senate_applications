@echo off
rem Installs SenateScan for the current user (no administrator rights needed):
rem   - copies the program to %LOCALAPPDATA%\SenateScan-App
rem   - starts it automatically when the user signs in to Windows
rem   - starts it now
rem If this computer still has the older "ScanBridge" (the tool's previous name) installed, it is
rem removed first, and its settings (such as AllowedOrigins) are carried over automatically.
setlocal
set TARGET=%LOCALAPPDATA%\SenateScan-App
set OLDTARGET=%LOCALAPPDATA%\ScanBridge-App
if not exist "%TARGET%" mkdir "%TARGET%"

rem stop any copy that is currently running (old name or new)
taskkill /f /im SenateScan.exe >nul 2>&1
taskkill /f /im ScanBridge.exe >nul 2>&1
timeout /t 1 /nobreak >nul

rem carry over settings from an old "ScanBridge" install, so websites already allowed there stay allowed
if exist "%OLDTARGET%\ScanBridge.ini" if not exist "%TARGET%\SenateScan.ini" (
    copy /y "%OLDTARGET%\ScanBridge.ini" "%TARGET%\SenateScan.ini" >nul
    echo Carried over settings from the previous ScanBridge install.
)

rem remove the old install and its auto-start entry, so it cannot start alongside the new one
reg delete "HKCU\Software\Microsoft\Windows\CurrentVersion\Run" /v ScanBridge /f >nul 2>&1
if exist "%OLDTARGET%" rmdir /s /q "%OLDTARGET%" >nul 2>&1

copy /y "%~dp0SenateScan.exe" "%TARGET%\SenateScan.exe" >nul
if not exist "%TARGET%\SenateScan.ini" copy /y "%~dp0SenateScan.ini" "%TARGET%\SenateScan.ini" >nul
copy /y "%~dp0README.txt" "%TARGET%\README.txt" >nul
copy /y "%~dp0uninstall.bat" "%TARGET%\uninstall.bat" >nul

reg add "HKCU\Software\Microsoft\Windows\CurrentVersion\Run" /v SenateScan /t REG_SZ /d "\"%TARGET%\SenateScan.exe\"" /f >nul
start "" "%TARGET%\SenateScan.exe"

echo.
echo SenateScan is installed and running (look for its icon near the clock).
echo Settings file: %TARGET%\SenateScan.ini
echo.
pause
endlocal
