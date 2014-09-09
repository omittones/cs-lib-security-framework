using System;
using Autofac;

namespace Lib.SecurityFramework.Framework
{
    public class ActionSelector<TFormat, TCommonInterface>
    {
        private readonly Action<TCommonInterface> initalize;
        private readonly TCommonInterface securityChecker;
        private readonly TCommonInterface actionResultFactory;
        private readonly IDisabledEndpointFactory<TFormat> disabledEndpointFactory;

        public ActionSelector(
            IDisabledEndpointFactory<TFormat> disabledEndpointFactory,
            TCommonInterface securityChecker,
            TCommonInterface actionResultFactory,
            Action<TCommonInterface> initialize)
        {
            this.initalize = initialize;
            this.disabledEndpointFactory = disabledEndpointFactory;
            this.securityChecker = securityChecker;
            this.actionResultFactory = actionResultFactory;
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
                this.initalize(this.actionResultFactory);
                var generateActionInvocation = methodSelector(this.actionResultFactory);
                return (TFormat) generateActionInvocation();
            }
            else
            {
                return disabledEndpointFactory.Create();
            }
        }
    }
}