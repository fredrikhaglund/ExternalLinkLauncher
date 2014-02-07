using System.Windows.Forms;

namespace Launcher
{
    internal static class HelpText
    {
        internal const string Title = "External Link Launcher";

        internal static void ShowUsage()
        {
            MessageBox.Show(
                @"Launcher.exe is used to open an external link in Chrome. It registers a protocol for extern:// and externs://. When external links are opened the url are first changed to start with to http:// and https:// and then opened with chrome.

Usage:
Run ""Launcher install"" as administrator to register protocol handlers.
Run ""Launcher uninstall"" as administrator to unregister protocol handlers.

Troubleshooting:
Run ""Launcher open extern://www.google.com"" as a user to test if the application can launch chrome.
Press Windows+R to open the System Run dialog and enter ""extern://www.google.com"" and click OK to verify that the protocols are registered correctly.

Copyright 2014 Fredrik Haglund. This is free software. You may redistribute copies of it under the terms of the MIT License.
http://www.opensource.org/licenses/mit-license.php",
                Title);
        }

        internal static void ShowError(System.Exception e)
        {
            MessageBox.Show(e.Message, Title, MessageBoxButtons.OK, MessageBoxIcon.Error);
        }

        internal static void ShowInstalled()
        {
            MessageBox.Show("Installation successful.", Title, MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        internal static void ShowUninstalled()
        {
            MessageBox.Show("Uninstallation successful.", Title, MessageBoxButtons.OK, MessageBoxIcon.Information);
        }
    }
}