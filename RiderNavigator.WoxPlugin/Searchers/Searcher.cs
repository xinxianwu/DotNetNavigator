using System.Collections.Generic;
using System.Linq;
using EverythingSharp.Enums;
using EverythingSharp.Exceptions;
using EverythingSharp.Fluent;
using RiderNavigator.WoxPlugin.Dtos;
using RiderNavigator.WoxPlugin.Exceptions;

namespace RiderNavigator.WoxPlugin.Searchers
{
    public class Searcher : ISearcher
    {
        public List<DirectoryDto> Find(string keyword)
        {
            try
            {
                using (var everything = new EverythingSearcher())
                {
                    return everything
                        .SearchFor($"{keyword} *.sln")
                        .OrderBy(Sort.NameAscending)
                        .WithResultLimit(30)
                        .WithOffset(0)
                        .GetFields(RequestFlags.FullPathAndFileName | RequestFlags.RunCount)
                        .Execute()
                        .Select(x => new DirectoryDto(x.FullPath))
                        .ToList();
                }
            }
            catch (EverythingException e)
            {
                throw new NavigatorException("Please check if the Everything service is running", e);
            }
        }
    }
}