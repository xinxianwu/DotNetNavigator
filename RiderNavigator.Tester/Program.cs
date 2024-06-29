using System;
using System.Linq;
using RiderNavigator.WoxPlugin.Searchers;

namespace RiderNavigator.Tester
{
    internal class Program
    {

        public static void Main(string[] args)
        {
            var everythingSearcher = new Searcher();
            var everythingEntries = everythingSearcher.Find("betting");
            var enumerable = everythingEntries
                .Select(x => x.ToRiderResult());

            enumerable.First().Action.Invoke(null);
            

            Console.WriteLine();
        }
    }
}