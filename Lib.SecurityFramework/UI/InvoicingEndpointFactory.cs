using Autofac;
using Lib.SecurityFramework.Domain;
using Lib.SecurityFramework.Domain.Actions;
using Lib.SecurityFramework.Domain.Security;
using Lib.SecurityFramework.Framework;

namespace Lib.SecurityFramework.UI
{
    public class InvoicingEndpointFactory<TFormat> : ActionEndpointFactory<TFormat>
        where TFormat : class
    {
        private readonly ILifetimeScope scope;
        private readonly IInvoiceRepository repo;

        public InvoicingEndpointFactory(IDisabledEndpointFactory<TFormat> disabledEndpointFactory, 
            IInvoiceRepository repo,
            ILifetimeScope scope)
            : base(disabledEndpointFactory)
        {
            this.scope = scope;
            this.repo = repo;
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
            var invoce = repo.GetInvoice(item.InvoiceID);

            return CreateActionSelector<IInvoiceItemActions<object>>(
                scope.Resolve<IInvoiceItemActions<TFormat>>(),
                new InvoiceItemSecurity(),
                i =>
                {
                    i.Context = context;
                    i.Invoice = invoce;
                    i.Item = item;
                });
        }
    }
}