using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using RiderNavigator.WoxPlugin.Dtos;

namespace RiderNavigator.WoxPlugin
{
    public class DirectoryNode
    {
        private readonly List<DirectoryInfo> _root;

        public DirectoryNode(string rootPath)
        {
            _root = new List<DirectoryInfo>() { new DirectoryInfo(rootPath) };
        }

        private DirectoryNode(List<DirectoryInfo> directoryInfos)
        {
            _root = directoryInfos;
        }

        /// <summary>
        /// Not specified in the requirements
        /// </summary>
        /// <returns></returns>
        /// <exception cref="NotImplementedException"></exception>
        public DirectoryNode Next()
        {
            var directoryInfos = _root
                .SelectMany(SafeGetDirectories)
                .ToList();
            
            return new DirectoryNode(directoryInfos);
        }

        public DirectoryNode Next(string nextDirectory)
        {
            var directoryInfos = _root
                .SelectMany(SafeGetDirectories)
                .Where(x => x.Name.Equals(nextDirectory, StringComparison.OrdinalIgnoreCase))
                .ToList();
            
            return new DirectoryNode(directoryInfos);
        }

        public List<DirectoryDto> GetAllDirectoryPath()
        {
            return _root
                .SelectMany(SafeGetDirectories)
                .Select(x => new DirectoryDto()
                {
                    ProjectName = x.Name,
                    FullPath = x.FullName
                })
                .ToList();
        }

        private static IEnumerable<DirectoryInfo> SafeGetDirectories(DirectoryInfo directoryInfo)
        {
            try
            {
                return directoryInfo.GetDirectories();
            }
            catch (UnauthorizedAccessException)
            {
                WriteEventLog($"Access denied to directory: {directoryInfo.FullName}");
                return Enumerable.Empty<DirectoryInfo>();
            }
            catch (Exception ex)
            {
                WriteEventLog($"Error accessing directory: {directoryInfo.FullName}. Exception: {ex.Message}");
                return Enumerable.Empty<DirectoryInfo>();
            }
        }

        private static void WriteEventLog(string message)
        {
            try
            {
                using (var eventLog = new EventLog("Application")) 
                {
                    eventLog.Source = "Application"; 
                    eventLog.WriteEntry(message, EventLogEntryType.Information);

                    Console.WriteLine(message);
                }
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
            }
        }
    }
}