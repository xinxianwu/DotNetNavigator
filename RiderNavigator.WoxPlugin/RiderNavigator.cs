using System.Collections.Generic;
using Wox.Plugin;

namespace RiderNavigator.WoxPlugin
{
    public class RiderNavigator : IPlugin
    {
        public List<Result> Query(Query query)
        {
            return new List<Result>()
            {
                new Result
                {
                    Title = "Project1",
                    SubTitle = "Path1",
                    IcoPath = "rider.ico",
                    Action = context => true
                },
                new Result
                {
                    Title = "Project1",
                    SubTitle = "Path1",
                    IcoPath = "rider.ico",
                    Action = context => true
                },
            };
        }

        public void Init(PluginInitContext context)
        {
            // throw new System.NotImplementedException();
        }
    }
}