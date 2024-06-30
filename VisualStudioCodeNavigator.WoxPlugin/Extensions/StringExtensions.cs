namespace VisualStudioCodeNavigator.WoxPlugin.Extensions
{
    public static class StringExtensions
    {
        public static bool IgnoreCaseContains(this string query, string str)
        {
            return str.ToLower().Contains(query.ToLower());
        }
    }
}