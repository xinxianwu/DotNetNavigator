using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using RiderNavigator.WoxPlugin.Dtos;
using RiderNavigator.WoxPlugin.Extensions;
using Wox.Plugin;

namespace RiderNavigator.WoxPlugin
{
    public class RiderNavigator : IPlugin
    {
        public List<Result> Query(Query query)
        {
            try
            {
                return SearchRiderProject()
                    .Where(x => string.IsNullOrEmpty(query.Search) || query.Search.IgnoreCaseContains(x.ProjectName))
                    .Select(x => new Result()
                    {
                        Title = x.ProjectName,
                        SubTitle = x.FullPath,
                        IcoPath = "rider.ico",
                        Action = context =>
                        {
                            var process = new Process()
                            {
                                StartInfo = new ProcessStartInfo()
                                {
                                    FileName = "rider",
                                    Arguments = x.FullPath,
                                    UseShellExecute = true
                                } 
                            };

                            process.Start();

                            return true;
                        }
                    })
                    .ToList();
            }
            catch (Exception e)
            {
                return new List<Result>()
                {
                    new Result()
                    {
                        Title = "Internal Error",
                        SubTitle = e.ToString(),
                        IcoPath = "rider.ico",
                        Action = context => true
                    }
                };
            }
        }

        public void Init(PluginInitContext context)
        {
        }

        private static List<DirectoryDto> SearchRiderProject()
        {
            var userProfileFolder = Environment.GetFolderPath(Environment.SpecialFolder.UserProfile);
            var list1 = new DirectoryNode(userProfileFolder)
                .Next("RiderProjects")
                .GetAllDirectoryPath()
                .ToList();

            var list2 = new DirectoryNode(userProfileFolder)
                .Next("source")
                .Next("repos")
                .GetAllDirectoryPath()
                .ToList();

            var cSharpProjects = new List<DirectoryDto>();
            cSharpProjects.AddRange(list1);
            cSharpProjects.AddRange(list2);

            return cSharpProjects;
        }
    }
}