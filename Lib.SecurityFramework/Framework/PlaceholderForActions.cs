using System;
using Autofac;

namespace Lib.SecurityFramework.Framework
{
    public class PlaceholderForActions<TFormat, TSecurityCheckInterface, TActionGeneratorInterface, TCommonInterface>
        where TSecurityCheckInterface : TCommonInterface
        where TActionGeneratorInterface : TCommonInterface
    {
        private readonly ILifetimeScope scope;
        private readonly Action<TCommonInterface> initalize;
        private readonly TSecurityCheckInterface securityChecker;
        private readonly TCommonInterface actionFactory;

        public PlaceholderForActions(ILifetimeScope scope, Action<TCommonInterface> initialize)
        {
            this.scope = scope;
            this.initalize = initialize;

            this.securityChecker = ResolveViaDependencyController<TSecurityCheckInterface>();
            this.actionFactory = ResolveViaDependencyController<TActionGeneratorInterface>();
        }

        protected T ResolveViaDependencyController<T>()
        {
            return this.scope.Resolve<T>();
        }

        public TFormat Select(Func<TCommonInterface, Func<object>> methodSelector)
        {
            var forbiddenActionFactory = ResolveViaDependencyController<IForbiddenActionFactory<TFormat>>();

            this.initalize(securityChecker);
            var performSecurityCheck = methodSelector(securityChecker);

            if (((SecurityCheckResult)performSecurityCheck()).Allowed)
            {
                this.initalize(this.actionFactory);
                var generateActionInvocation = methodSelector(this.actionFactory);
                return (TFormat)generateActionInvocation();
            }
            else
            {
                return forbiddenActionFactory.Create();
            }
        }
    }
}