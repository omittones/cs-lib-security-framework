using System;

namespace Lib.SecurityFramework.Framework
{
    public class BasePlaceholderFactory<TFormat>
        where TFormat : class, IActionFormat
    {
        protected virtual T ResolveViaDependencyController<T>()
        {
            return default(T);
        }

        protected TFormat CheckSecurityAndReturnAction<TCommonInterface>(
            TCommonInterface securityChecker,
            TCommonInterface resultFactory,
            Func<TCommonInterface, Func<object>> methodSelector)
        {
            var forbiddenActionFactory = ResolveViaDependencyController<IForbiddenActionFactory<TFormat>>();

            var performSecurityCheck = methodSelector(securityChecker);
            var generateActionInvocation = methodSelector(resultFactory);

            if (((SecurityCheckResult) performSecurityCheck()).Allowed)
            {
                return (TFormat) generateActionInvocation();
            }
            else
            {
                return forbiddenActionFactory.Create();
            }
        }
    }
}