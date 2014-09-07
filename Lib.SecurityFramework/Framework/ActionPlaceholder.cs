using Autofac;
using Lib.SecurityFramework.Domain.Security;

namespace Lib.SecurityFramework.Framework
{
    public class ActionPlaceholder
    {
        private readonly ILifetimeScope scope;

        public ActionPlaceholder(ILifetimeScope scope)
        {
            this.scope = scope;
        }

        public PlaceholderFactory<TFormat> With<TFormat>()
            where TFormat : class, IActionFormat
        {
            return new PlaceholderFactory<TFormat>(this.scope);
        }
    }
}