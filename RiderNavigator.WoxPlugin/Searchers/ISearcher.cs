using System.Collections.Generic;
using RiderNavigator.WoxPlugin.Dtos;

namespace RiderNavigator.WoxPlugin.Searchers
{
    internal interface ISearcher
    {
        List<DirectoryDto> Find(string keyword);
    }
}