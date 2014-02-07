using System;

namespace Launcher
{
    internal class Program
    {
        [STAThread]
        private static void Main(string[] args)
        {
            try
            {
                if (args.Length == 1 && string.Equals("install", args[0], StringComparison.OrdinalIgnoreCase))
                {
                    if (Setup.Install())
                    {
                        HelpText.ShowInstalled();
                    }
                }
                else if (args.Length == 1 && string.Equals("uninstall", args[0], StringComparison.OrdinalIgnoreCase))
                {
                    if (Setup.Uninstall())
                    {
                        HelpText.ShowUninstalled();
                    }
                }
                else if (args.Length == 2 && string.Equals("open", args[0], StringComparison.OrdinalIgnoreCase))
                {
                    if (!args[1].StartsWith("extern", StringComparison.OrdinalIgnoreCase))
                    {
                        throw new Exception("This program only accepts links starting with extern:// or externs://");
                    }
                    string url = "http" + args[1].Substring(6);
                    ChromeLauncher.OpenLink(url);
                }
                else
                {
                    HelpText.ShowUsage();
                }
            }
            catch (Exception e)
            {
                HelpText.ShowError(e);
            }
        }
    }
}