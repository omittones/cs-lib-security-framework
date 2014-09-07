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
                var placeholder = new ActionPlaceholder(scope);

                IContext context = new FakeContext();
                Invoice invoice = new Invoice { CompanyID = 1, InvoiceID = 1, Status = InvoiceStatus.Draft };
                InvoiceItem invoiceItem = new InvoiceItem { InvoiceID = 1, InvoiceItemID = 1 };

                placeholder.With<HtmlFormat>().ForInvoice(context, invoice, a => a.Create).RenderAsButton("Add new invoice").WriteLine();
                placeholder.With<HtmlFormat>().ForInvoice(context, invoice, a => a.Delete).RenderAsButton("Delete invoice").WriteLine();
                placeholder.With<HtmlFormat>().ForInvoice(context, invoice, a => a.Publish).RenderAsButton("Publish invoice").WriteLine();

                placeholder.With<HtmlFormat>().ForInvoiceItem(context, invoiceItem, a => a.RemoveVAT).RenderAsImage("minus.png").WriteLine();
                placeholder.With<HtmlFormat>().ForInvoiceItem(context, invoiceItem, a => a.SetPrice).RenderAsImage("dollar.png").WriteLine();
            }
        }
    }
}