using System;

namespace Lib.SecurityFramework.Framework
{
    public class ActionEndpointFactory<TFormat>
    {
        private readonly IDisabledEndpointFactory<TFormat> disabledEndpointFactory;

        public ActionEndpointFactory(IDisabledEndpointFactory<TFormat> disabledEndpointFactory)
        {
            this.disabledEndpointFactory = disabledEndpointFactory;
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