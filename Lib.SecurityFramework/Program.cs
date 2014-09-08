using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Lib.SecurityFramework.Domain;
using Lib.SecurityFramework.Framework;
using Autofac;
using Lib.SecurityFramework.UI;

namespace Lib.SecurityFramework
{
    public static class Program
    {
        public static void WriteLine(this string format, params object[] args)
        {
            Console.WriteLine(format, args);
        }

        public static void Main()
        {
            ContainerBuilder builder = new ContainerBuilder();
            builder.RegisterType<UI.ForbiddenHtmlActionFactory>().AsImplementedInterfaces().InstancePerLifetimeScope();
            builder.RegisterType<UI.InvoiceHtmlActions>().AsImplementedInterfaces().InstancePerLifetimeScope();
            builder.RegisterType<UI.InvoiceItemHtmlActions>().AsImplementedInterfaces().InstancePerLifetimeScope();
            builder.RegisterType<Domain.Security.InvoiceSecurityChecker>().AsImplementedInterfaces().InstancePerLifetimeScope();
            builder.RegisterType<Domain.Security.InvoiceItemSecurityChecker>().AsImplementedInterfaces().InstancePerLifetimeScope();

            using (var container = builder.Build())
            using (var scope = container.BeginLifetimeScope())
            {
                var placeholders = new ActionPlaceholdersFactory(scope);

                IContext context = new FakeContext();
                Invoice invoice = new Invoice { CompanyID = 1, InvoiceID = 1, Status = InvoiceStatus.Draft };
                InvoiceItem invoiceItem = new InvoiceItem { InvoiceID = 1, InvoiceItemID = 1 };

                var invoiceAction = placeholders.With<HtmlFormat>().ForInvoice(context, invoice);

                invoiceAction(a => a.Create).RenderAsButton("Add new invoice").WriteLine();
                invoiceAction(a => a.Delete).RenderAsButton("Delete invoice").WriteLine();
                invoiceAction(a => a.Publish).RenderAsButton("Publish invoice").WriteLine();

                var invoiceItemAction = placeholders.With<HtmlFormat>().ForInvoiceItem(context, invoiceItem);

                invoiceItemAction(a => a.RemoveVAT).RenderAsImage("minus.png").WriteLine();
                invoiceItemAction(a => a.SetPrice).RenderAsImage("dollar.png").WriteLine();
            }
        }
    }
}