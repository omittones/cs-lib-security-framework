using System;
using Autofac;

namespace Lib.SecurityFramework.Framework
{
    public class PlaceholderForActions<TFormat, TSecInterface, TResInterface, TCommonInterface>
        where TSecInterface : TCommonInterface
        where TResInterface : TCommonInterface
    {
        private readonly ILifetimeScope scope;
        private readonly Action<TCommonInterface> initalize;
        private readonly TSecInterface securityChecker;
        private readonly TCommonInterface actionFactory;

        public PlaceholderForActions(ILifetimeScope scope, Action<TCommonInterface> initialize)
        {
            this.scope = scope;
            this.initalize = initialize;

            this.securityChecker = ResolveViaDependencyController<TSecInterface>();
            this.actionFactory = ResolveViaDependencyController<TResInterface>();
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