using System;
using System.IO;

namespace RiderNavigator.WoxPlugin
{
    public class SolutionFile
    {
        private readonly string _path;

        public SolutionFile(string path)
        {
            _path = path;
        }
        
        public string GetSolutionName()
        {
            try
            {
                return new FileInfo(_path).Name.Replace(".sln", string.Empty);
            }
            catch (Exception e)
            {
                throw new Exception($"Error getting solution name, path: {_path}", e);
            }
        }
    }
}