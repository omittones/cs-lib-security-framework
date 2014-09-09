using System;
using Autofac;
using Lib.SecurityFramework.Domain.Security;

namespace Lib.SecurityFramework.Framework
{
    public class ActionEndpointFactory<TFormat>
    {
        private readonly ILifetimeScope scope;
        private readonly IDisabledEndpointFactory<TFormat> disabledEndpointFactory;

        public ActionEndpointFactory(ILifetimeScope scope)
        {
            this.scope = scope;
            this.disabledEndpointFactory = scope.Resolve<IDisabledEndpointFactory<TFormat>>();
        }

        public ActionSelector<TFormat, TCommonInterface> CreateActionSelector<TCommonInterface>(
            TCommonInterface actions,
            TCommonInterface security,
            Action<TCommonInterface> init)
        {
            return new ActionSelector<TFormat, TCommonInterface>(this.disabledEndpointFactory,
                security, actions, init);
        }
    }
}