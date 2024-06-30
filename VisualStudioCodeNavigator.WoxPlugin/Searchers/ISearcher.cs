using System.Collections.Generic;
using VisualStudioCodeNavigator.WoxPlugin.Dtos;

namespace VisualStudioCodeNavigator.WoxPlugin.Searchers
{
    internal interface ISearcher
    {
        List<DirectoryDto> Find(string keyword);
    }
}