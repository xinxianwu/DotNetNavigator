using System.Collections.Generic;
using Navigator.Common.Dtos;

namespace Navigator.Common.Searchers
{
    internal interface ISearcher
    {
        List<DirectoryDto> Find(string keyword);
    }
}