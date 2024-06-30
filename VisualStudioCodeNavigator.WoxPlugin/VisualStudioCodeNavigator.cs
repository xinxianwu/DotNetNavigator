using System;
using System.Collections.Generic;
using System.Linq;
using Navigator.Common.Exceptions;
using Navigator.Common.Logger;
using Navigator.Common.Searchers;
using Wox.Plugin;

namespace VisualStudioCodeNavigator.WoxPlugin
{
    public class VisualStudioCodeNavigator : IPlugin
    {
        public List<Result> Query(Query query)
        {
            try
            {
                var everythingSearcher = new Searcher();
                var everythingEntries = everythingSearcher.Find(query.Search);

                return everythingEntries
                    .Select(x => x.ToVisualStudioCodeResult())
                    .ToList();
            }
            catch(NavigatorException e)
            {
                DotNetNavigatorLogger.Error(e);
                return new List<Result>
                {
                    new Result
                    {
                        Title = "Internal Info",
                        SubTitle = "Everything service is not running",
                        IcoPath = "close.png",
                        Action = context => true
                    }
                };
            }
            catch (Exception e)
            {
                DotNetNavigatorLogger.Error(e, $"Error in VisualStudioCodeNavigator, RawQuery: {query.RawQuery}");
                return new List<Result>
                {
                    new Result
                    {
                        Title = "Internal Info",
                        SubTitle = e.ToString(),
                        IcoPath = "close.png",
                        Action = context => true
                    }
                };
            }
        }

        public void Init(PluginInitContext context)
        {
        }

    }
}