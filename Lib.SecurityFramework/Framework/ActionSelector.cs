using System;

namespace Lib.SecurityFramework.Framework
{
    public class ActionSelector<TFormat, TCommonInterface>
    {
        private readonly Action<TCommonInterface> initalize;
        private readonly TCommonInterface securityChecker;
        private readonly TCommonInterface endpointFactory;
        private readonly IDisabledEndpointFactory<TFormat> disabledEndpointFactory;

        public ActionSelector(
            IDisabledEndpointFactory<TFormat> disabledEndpointFactory,
            TCommonInterface securityChecker,
            TCommonInterface endpointFactory,
            Action<TCommonInterface> initialize)
        {
            this.initalize = initialize;
            this.disabledEndpointFactory = disabledEndpointFactory;
            this.securityChecker = securityChecker;
            this.endpointFactory = endpointFactory;
        }

        public bool IsActionAllowed(Func<TCommonInterface, Func<object>> methodSelector)
        {
            this.initalize(securityChecker);
            var performSecurityCheck = methodSelector(securityChecker);
            return ((SecurityCheckResult) performSecurityCheck()).Allowed;
        }

        public TFormat Action(Func<TCommonInterface, Func<object>> methodSelector)
        {
            if (IsActionAllowed(methodSelector))
            {
                this.initalize(this.endpointFactory);
                var generateActionInvocation = methodSelector(this.endpointFactory);
                return (TFormat) generateActionInvocation();
            }

            return disabledEndpointFactory.Create();
        }
    }
}