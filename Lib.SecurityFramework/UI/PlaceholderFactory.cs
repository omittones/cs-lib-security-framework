using Autofac;
using Lib.SecurityFramework.Domain.Security;
using Lib.SecurityFramework.Framework;

namespace Lib.SecurityFramework.UI
{
    public class PlaceholderFactory
    {
        private readonly ILifetimeScope scope;

        public PlaceholderFactory(ILifetimeScope scope)
        {
            this.scope = scope;
        }

        public FormattedPlaceholderFactory<TFormat> With<TFormat>()
            where TFormat : class, IActionFormat
        {
            return new FormattedPlaceholderFactory<TFormat>(this.scope);
        }
    }
}