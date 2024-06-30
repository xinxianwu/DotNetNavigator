using System.ComponentModel;
using System.Diagnostics;
using VisualStudioCodeNavigator.WoxPlugin.Exceptions;

namespace VisualStudioCodeNavigator.WoxPlugin.Launchers
{
    public class VisualStudioCodeLauncher
    {
        private readonly Process _process;

        public VisualStudioCodeLauncher(string path)
        {
            _process = new Process
            {
                StartInfo = new ProcessStartInfo
                {
                    FileName = "code",
                    Arguments = $"-n \"{path}\"",
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
                throw new NavigatorException(@"To add the VisualStudioCode folder to your environment variables, try adding the following path: C:\Users\your user name\AppData\Local\Programs\Microsoft VS Code",
                    e);
            }

            return true;
        }
    }
}