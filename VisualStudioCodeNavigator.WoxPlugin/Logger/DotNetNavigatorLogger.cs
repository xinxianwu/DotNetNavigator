using System;
using System.Diagnostics;

namespace VisualStudioCodeNavigator.WoxPlugin.Logger
{
    public class DotNetNavigatorLogger
    {
        public static void Info(string message)
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

        public static void Error(Exception exception, string message = null)
        {
            try
            {
                using (var eventLog = new EventLog("Application"))
                {
                    eventLog.Source = "Application";
                    eventLog.WriteEntry(string.IsNullOrEmpty(message)
                        ? exception.ToString()
                        : $"{message} - {exception}", EventLogEntryType.Error);

                    Console.WriteLine(exception);
                }
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
            }
        }
    }
}