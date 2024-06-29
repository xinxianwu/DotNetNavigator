using System.ComponentModel;
using System.Linq;
using System.Reflection;
using EverythingSharp.Enums;

namespace EverythingSharp.Extensions
{
    internal static class ErrorEnumExtensions
    {
        internal static string GetDescription(this Error error)
        {
            return error.GetType()
                .GetMember(error.ToString())
                .FirstOrDefault()
                ?.GetCustomAttribute<DescriptionAttribute>()?
                .Description;
        }
    }
}
