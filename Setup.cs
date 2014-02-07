using System;
using System.ComponentModel;
using System.Diagnostics;
using System.Security.Principal;
using Microsoft.Win32;

namespace Launcher
{
    internal static class Setup
    {
        public static string ProcessFilename
        {
            get { return Process.GetCurrentProcess().MainModule.FileName; }
        }

        private static bool HasAdministrativeRight()
        {
            WindowsIdentity windowsIdentity = WindowsIdentity.GetCurrent();
            return windowsIdentity != null
                   && new WindowsPrincipal(windowsIdentity).IsInRole(WindowsBuiltInRole.Administrator);
        }

        private static void RestartElevated(string command)
        {
            var processInfo = new ProcessStartInfo
            {
                Verb = "runas",
                FileName = ProcessFilename,
                Arguments = command
            };
            try
            {
                Process.Start(processInfo);
            }
            catch (Win32Exception)
            {
                //Do nothing. Probably the user canceled the UAC window
            }
        }

        private static void RegisterProtocol(string protocol)
        {
            string key = @"HKEY_CLASSES_ROOT\" + protocol;
            Registry.SetValue(key, "", "URL:Launch browser for external link");
            Registry.SetValue(key, "URL Protocol", "");
            Registry.SetValue(key + @"\DefaultIcon", "URL Protocol", ProcessFilename);
            Registry.SetValue(key + @"\shell\open\command", "", string.Format(@"""{0}"" open ""%1""", ProcessFilename));
        }

        internal static bool IsInstalled(string protocol)
        {
            string key = @"HKEY_CLASSES_ROOT\" + protocol;
            return string.Equals(ProcessFilename,
                Registry.GetValue(key + @"\DefaultIcon", "URL Protocol", null) as string,
                StringComparison.OrdinalIgnoreCase);
        }

        internal static bool Install()
        {
            if (HasAdministrativeRight())
            {
                RegisterProtocol("extern");
                RegisterProtocol("externs");
                return true;
            }
            RestartElevated("install");
            return false;
        }

        internal static bool Uninstall()
        {
            if (HasAdministrativeRight())
            {
                Registry.ClassesRoot.DeleteSubKeyTree("extern", false);
                Registry.ClassesRoot.DeleteSubKeyTree("externs", false);
                return true;
            }
            RestartElevated("uninstall");
            return false;
        }
    }
}