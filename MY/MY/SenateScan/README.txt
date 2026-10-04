SenateScan - scanner utility for the Notice Office website
===========================================================

What it is
  A small program that runs near the clock on a Notice Office PC. It lets the Scan button on the Notice website
  scan from any scanner installed on that PC and attach the result (a PDF or a picture) to the page, exactly like
  choosing a file. The scanned pages stay on the PC and only go to the website when the user clicks "Use these pages".

Install (once per PC, no administrator rights needed)
  1. Copy the whole "dist" folder to the PC.
  2. Double-click install.bat.
  3. Look for the SenateScan icon near the clock. It starts by itself every time the user signs in.
  4. If the Notice website is opened with a full name (for example https://notice.senate.gov.pk), open the settings
     file (right-click the icon > Open settings file) and add the address after AllowedOrigins=, then restart
     SenateScan (icon > Exit, then start it again from install.bat).

Scanners it works with
  * Scanners that have a Windows driver (WIA)                - most modern scanners and multi-function printers.
  * Network copiers that "scan to folder"                    - set ScanFolder= in the settings file.
  * Demo scanner (test pages, no hardware)                   - EnableDemo=true. Set to false for real use.
  Scanners that only have a TWAIN driver are not supported yet.

Using it on the website
  On any page with a file attachment box that shows a Scan button: click Scan, choose the scanner, paper source,
  colour and quality, click Scan, check or reorder the pages, then click "Use these pages".

Problems
  * "Could not reach the scanner utility from this page": either SenateScan is not running (start it with install.bat,
    or from the icon near the clock), or the browser is blocking the website from reaching this PC. Click
    "Open scanner window" in the dialog: the scan is then made in a small window served by SenateScan itself, which the
    browser does not block, and the finished file is sent back to the page.
  * A message "allow this website?" appears on the PC the first time a website that is not on the office-network list asks
    to use the scanner. Choose Yes only for your own website; the address is then saved in AllowedOrigins.
  * To test SenateScan without the website: open  http://127.0.0.1:47600/ui  in the browser on the scanning PC.
  * After updating SenateScan, run install.bat again (it replaces the running copy).
  * A log is kept at %LOCALAPPDATA%\SenateScan\senatescan.log (icon > Open log).
  * Remove with uninstall.bat.

Security
  SenateScan only listens on this computer (127.0.0.1) and only answers websites on the office network.


The utility

Where: E:\Senate Code Improvement\SenateScan\. Run build.bat to build it. The compiled program is in dist\, and it needed no downloads.
Install: run dist\install.bat on each scanning PC. It needs no administrator rights, adds a tray icon near the clock, and starts automatically when the user signs in.
Scanners: it covers scanners that have a Windows driver, and network copiers that "scan to folder". For the folder option, set ScanFolder= in the settings file. It doesn't support scanners that only have a TWAIN driver.
Security: it listens only on the PC itself. It answers only websites on the office network, and any other website is refused.
Demo scanner: set EnableDemo=false in SenateScan.ini once real scanners are in use.
Website address: if the Notice site is reached by a full name such as https://notice.senate.gov.pk, add that address to AllowedOrigins in the settings file. Plain names and private IP addresses work without it.
