External Link Launcher
======================

Launcher.exe is used to open an external link in Chrome. It registers a protocol for extern:// and externs://. When external links are opened the url are first changed to start with to http:// and https:// and then opened with chrome.


Background
----------
This application is developed to solve a specific scenario. 

Several internal web applications require Internet Explorer and does not work with the required security settings so access to internet is not available using Internet Explorer. If you want to access external web sites you have to use Chrome that has a proxy server configured. 

Unfortunately the Intranet is not accessible using Chrome so when you browse the Intranet using Internet Explorer all external links are broken.

To overcome this problem this application registers a protocol handlers for extern:// and externs:// that opens these URLs in Chrome to make it possible to open links on the Intranet.


Usage
-----

Run ""Launcher install"" as administrator to register protocol handlers.

Run ""Launcher uninstall"" as administrator to unregister protocol handlers.


Troubleshooting
---------------
Run ""Launcher open extern://www.google.com"" as a user to test if the application can launch chrome.

Press Windows+R to open the System Run dialog and enter ""extern://www.google.com"" and click OK to verify that the protocols are registered correctly.



Copyright 2014 Fredrik Haglund. 

This is free software. You may redistribute copies of it under the terms of the MIT License. <http://www.opensource.org/licenses/mit-license.php>