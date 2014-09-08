using System;
using Autofac;
using Lib.SecurityFramework.Domain;
using Lib.SecurityFramework.Domain.Actions;
using Lib.SecurityFramework.Framework;

namespace Lib.SecurityFramework.UI
{
    public class FormattedPlaceholderFactory<TFormat>
        where TFormat : class, IActionFormat
    {
        private readonly ILifetimeScope scope;

        public FormattedPlaceholderFactory(ILifetimeScope scope)
        {
            this.scope = scope;
        }

        public Func<Func<IInvoiceActions<object>, Func<object>>, TFormat> ForInvoice(IContext context, Invoice invoice)
        {
            var placeholderForActions = new PlaceholderForActions<TFormat,
                IInvoiceActions<SecurityCheckResult>,
                IInvoiceActions<TFormat>,
                IInvoiceActions<object>>(scope, i =>
                {
                    i.Context = context;
                    i.Invoice = invoice;
                });

            return placeholderForActions.Select;
        }

        public Func<Func<IInvoiceItemActions<object>, Func<object>>, TFormat> ForInvoiceItem(IContext context, InvoiceItem item)
        {
            var placeholderForActions = new PlaceholderForActions<TFormat, 
                IInvoiceItemActions<SecurityCheckResult>,
                IInvoiceItemActions<TFormat>,
                IInvoiceItemActions<object>>(scope, i =>
                {
                    i.Context = context;
                    i.Invoice = new Invoice { CompanyID = context.CompanyID, InvoiceID = item.InvoiceID, Status = InvoiceStatus.Draft };
                    i.Item = item;
                });

            return placeholderForActions.Select;
        }
    }
}