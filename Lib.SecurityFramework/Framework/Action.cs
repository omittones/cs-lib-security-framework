using Lib.SecurityFramework.Domain.Security;

namespace Lib.SecurityFramework.Framework
{
    public static class Action
    {
        public static PlaceholderFactory<TInvocator> WithFormat<TInvocator>()
            where TInvocator : class, IActionFormat
        {
            return new PlaceholderFactory<TInvocator>();
        }
    }
}