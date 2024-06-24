using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using EverythingSharp.Enums;
using EverythingSharp.Fluent;
using Wox.Plugin;

namespace RiderNavigator.WoxPlugin.Tester
{
    internal class Program
    {
        public static void Main(string[] args)
        {
            // var keyWord = " *.sln";
            // var everyThingApi = new EverythingApi();
            // var enumerable = everyThingApi.Search(keyWord).ToList();

            using (EverythingSearcher everything = new EverythingSearcher())
            {
                IEnumerable<EverythingEntry> results = everything
                    .SearchFor("result *.sln")
                    .OrderBy(Sort.NameAscending)
                    .WithResultLimit(30)
                    .WithOffset(0)
                    .GetFields(RequestFlags.FullPathAndFileName | RequestFlags.RunCount)
                    .Execute();

                foreach (EverythingEntry entry in results)
                {
                    Console.WriteLine(entry.FullPath);
                }
            }

            Console.WriteLine();
        }
    }
}