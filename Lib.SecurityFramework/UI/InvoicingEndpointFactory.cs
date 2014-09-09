using System;
using Autofac;
using Lib.SecurityFramework.Domain;
using Lib.SecurityFramework.Domain.Actions;
using Lib.SecurityFramework.Domain.Security;
using Lib.SecurityFramework.Framework;

namespace Lib.SecurityFramework.UI
{
    public class InvoicingEndpointFactory<TFormat> : ActionEndpointFactory<TFormat>
        where TFormat : class, IActionFormat
    {
        private readonly ILifetimeScope scope;
        public InvoicingEndpointFactory(ILifetimeScope scope) : base(scope)
        {
            this.scope = scope;
        }

        public ActionSelector<TFormat, IInvoiceActions<object>> ForInvoice(IContext context, Invoice invoice)
        {
            return CreateActionSelector<IInvoiceActions<object>>(
                scope.Resolve<IInvoiceActions<TFormat>>(),
                new InvoiceSecurity(),
                i =>
                {
                    i.Context = context;
                    i.Invoice = invoice;
                });
        }

        public ActionSelector<TFormat, IInvoiceItemActions<object>> ForInvoiceItem(IContext context, InvoiceItem item)
        {
            return CreateActionSelector<IInvoiceItemActions<object>>(
                scope.Resolve<IInvoiceItemActions<TFormat>>(),
                new InvoiceItemSecurity(),
                i =>
                {
                    i.Context = context;
                    i.Invoice = new Invoice { CompanyID = context.CompanyID, InvoiceID = item.InvoiceID, Status = InvoiceStatus.Draft };
                    i.Item = item;
                });
        }
    }
}