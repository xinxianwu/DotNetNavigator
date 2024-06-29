using System.ComponentModel;
using System.Diagnostics;
using RiderNavigator.WoxPlugin.Exceptions;

namespace RiderNavigator.WoxPlugin.Launchers
{
    public class RiderLauncher
    {
        private readonly Process _process;

        public RiderLauncher(string path)
        {
            _process = new Process
            {
                StartInfo = new ProcessStartInfo
                {
                    FileName = "rider",
                    Arguments = path,
                    UseShellExecute = true
                }
            };
        }

        public bool Launch()
        {
            try
            {
                _process.Start();
            }
            catch (Win32Exception e)
            {
                throw new NavigatorException(@"To add the Rider folder to your environment variables, try adding the following path: C:\Users\your user name\AppData\Local\JetBrains\Toolbox\scripts",
                    e);
            }

            return true;
        }
    }
}