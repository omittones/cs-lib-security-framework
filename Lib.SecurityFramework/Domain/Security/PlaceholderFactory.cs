using System;
using Lib.SecurityFramework.Domain.Actions;
using Lib.SecurityFramework.Framework;

namespace Lib.SecurityFramework.Domain.Security
{
    public class PlaceholderFactory<TFormat> : BasePlaceholderFactory<TFormat>
        where TFormat : class, IActionFormat
    {
        public TFormat ForInvoice(IContext context, Invoice invoice,
            Func<IInvoiceActions<object>, Func<object>> actionSelector)
        {
            var securityChecker = ResolveViaDependencyController<IInvoiceActions<SecurityCheckResult>>();
            securityChecker.Context = context;
            securityChecker.Invoice = invoice;

            var actionFactory = ResolveViaDependencyController<IInvoiceActions<TFormat>>();
            actionFactory.Context = context;
            actionFactory.Invoice = invoice;

            return CheckSecurityAndReturnAction(
                securityChecker,
                actionFactory,
                actionSelector);
        }

        public TFormat ForInvoiceItem(IContext context, InvoiceItem item,
            Func<IInvoiceItemActions<object>, Func<object>> actionSelector)
        {
            var securityChecker = ResolveViaDependencyController<IInvoiceItemActions<SecurityCheckResult>>();
            securityChecker.Context = context;
            securityChecker.Invoice = new Invoice { InvoiceID = item.InvoiceID };
            securityChecker.Item = item;

            var actionFactory = ResolveViaDependencyController<IInvoiceItemActions<TFormat>>();
            securityChecker.Context = context;
            securityChecker.Invoice = new Invoice { InvoiceID = item.InvoiceID };
            securityChecker.Item = item;

            return CheckSecurityAndReturnAction(
                securityChecker,
                actionFactory,
                actionSelector);
        }
    }
}