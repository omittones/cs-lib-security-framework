using Lib.SecurityFramework.Domain.Security;

namespace Lib.SecurityFramework.Framework
{
    public static class ActionPlaceholder
    {
        public static PlaceholderFactory<TFormat> With<TFormat>()
            where TFormat : class, IActionFormat
        {
            return new PlaceholderFactory<TFormat>();
        }
    }
}