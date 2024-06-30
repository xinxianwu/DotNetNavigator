using System.ComponentModel;
using System.Diagnostics;
using Navigator.Common.Exceptions;

namespace Navigator.Common.Launchers
{
    public class VisualStudioLauncher
    {
        private readonly Process _process;

        public VisualStudioLauncher(string path)
        {
            _process = new Process
            {
                StartInfo = new ProcessStartInfo
                {
                    FileName = "devenv",
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
                throw new NavigatorException(@"To add the VisualStudio folder to your environment variables, try adding the following path: C:\Program Files\Microsoft Visual Studio\2022\Community\Common7\IDE",
                    e);
            }

            return true;
        }
    }
}