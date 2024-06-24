using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using EverythingSharp.Enums;
using EverythingSharp.Fluent;
using RiderNavigator.WoxPlugin.Dtos;
using RiderNavigator.WoxPlugin.Extensions;
using RiderNavigator.WoxPlugin.Logger;
using Wox.Plugin;

namespace RiderNavigator.WoxPlugin
{
    public class RiderNavigator : IPlugin
    {
        public List<Result> Query(Query query)
        {
            try
            {
                return query.FirstSearch.Equals("sln", StringComparison.InvariantCultureIgnoreCase)
                    ? SearchSolutionFiles(query)
                    : SearchRiderProjectsFolder(query);
            }
            catch (Exception e)
            {
                DotNetNavigatorLogger.Error(e, $"Error in RiderNavigator, RawQuery: {query.RawQuery}");
                return new List<Result>
                {
                    new Result
                    {
                        Title = "Internal Info",
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

        private static List<Result> SearchSolutionFiles(Query query)
        {
            var keyWord = string.IsNullOrEmpty(query.SecondSearch)
                ? "*.sln"
                : $"{query.SecondSearch} *.sln";

            using (var everything = new EverythingSearcher())
            {
                var searchResult = everything
                    .SearchFor(keyWord)
                    .OrderBy(Sort.NameAscending)
                    .WithResultLimit(30)
                    .WithOffset(0)
                    .GetFields(RequestFlags.FullPathAndFileName | RequestFlags.RunCount)
                    .Execute();

                return searchResult
                    .Select(x =>
                    {
                        var result = new Result
                        {
                            Title = new SolutionFile(x.FullPath).GetSolutionName(),
                            SubTitle = x.FullPath,
                            IcoPath = "rider.ico",
                            Action = context => LaunchRiderProject(x.FullPath)
                        };
                        return result;
                    })
                    .ToList();
            }
        }

        private static List<Result> SearchRiderProjectsFolder(Query query)
        {
            return SearchRiderProject()
                .Where(x => string.IsNullOrEmpty(query.Search) || query.Search.IgnoreCaseContains(x.ProjectName))
                .Select(x => new Result
                {
                    Title = x.ProjectName,
                    SubTitle = x.FullPath,
                    IcoPath = "rider.ico",
                    Action = context => LaunchRiderProject(x.FullPath)
                })
                .ToList();
        }

        private static bool LaunchRiderProject(string fullPath)
        {
            var process = new Process
            {
                StartInfo = new ProcessStartInfo
                {
                    FileName = "rider",
                    Arguments = fullPath,
                    UseShellExecute = true
                }
            };

            process.Start();

            return true;
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