using System;

namespace VisualStudioCodeNavigator.WoxPlugin.Exceptions
{
    public class NavigatorException : Exception
    {
        // filed to launch rider with filename
        public NavigatorException(string message, Exception innerException) : base(message, innerException)
        {
            
        }
    }
}