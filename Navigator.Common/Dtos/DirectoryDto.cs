using System.Diagnostics;
using System.IO;
using Navigator.Common.Launchers;
using Wox.Plugin;

namespace Navigator.Common.Dtos
{
    [DebuggerDisplay("ProjectName: {ProjectName}, DirectoryPath: {DirectoryPath}, SolutionPath: {SolutionPath}")]
    public class DirectoryDto
    {
        public string ProjectName { get; set; }
        public string DirectoryPath { get; set; }
        public string SolutionPath { get; set; }

        public DirectoryDto(string path)
        {
            if (path.EndsWith(".sln"))
            {
                var fileInfo = new FileInfo(path);
                ProjectName = fileInfo.Name.Replace(".sln", string.Empty);
                DirectoryPath = fileInfo.Directory.FullName;
                SolutionPath = path;
            }
            else
            {
                var directoryInfo = new DirectoryInfo(path);
                ProjectName = directoryInfo.Name;
                DirectoryPath = path;
                SolutionPath = string.Empty;
            }
        }

        public DirectoryDto()
        {
        }
        
        public Result ToRiderResult()
        {
            return new Result
            {
                Title = ProjectName,
                SubTitle = SolutionPath,
                IcoPath = "rider.ico",
                Action = context => new RiderLauncher(SolutionPath).Launch()
            };
        }

        public Result ToVisualStudioCodeResult()
        {
            return new Result
            {
                Title = ProjectName,
                SubTitle = SolutionPath,
                IcoPath = "code.png",
                Action = context => new VisualStudioCodeLauncher(DirectoryPath).Launch()
            };
        }

        public Result ToVisualStudioResult()
        {
            return new Result
            {
                Title = ProjectName,
                SubTitle = SolutionPath,
                IcoPath = "VisualStudio.png",
                Action = context => new VisualStudioLauncher(SolutionPath).Launch()
            };
        }
    }
}