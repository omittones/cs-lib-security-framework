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
            builder.RegisterType<UI.DisabledHtmlEndpointFactory>().AsImplementedInterfaces().InstancePerLifetimeScope();
            builder.RegisterType<UI.InvoiceHtmlActions>().AsImplementedInterfaces().InstancePerLifetimeScope();
            builder.RegisterType<UI.InvoiceItemHtmlActions>().AsImplementedInterfaces().InstancePerLifetimeScope();
            builder.RegisterType<Domain.Security.InvoiceSecurity>().AsImplementedInterfaces().InstancePerLifetimeScope();
            builder.RegisterType<Domain.Security.InvoiceItemSecurity>().AsImplementedInterfaces().InstancePerLifetimeScope();

            using (var container = builder.Build())
            using (var scope = container.BeginLifetimeScope())
            {
                IContext context = new FakeContext();
                Invoice invoice = new Invoice { CompanyID = 1, InvoiceID = 1, Status = InvoiceStatus.Draft };
                InvoiceItem invoiceItem = new InvoiceItem { InvoiceID = 1, InvoiceItemID = 1 };

                int count = 0;
                var start = DateTime.UtcNow;
                while (DateTime.UtcNow.Subtract(start).TotalSeconds < 2)
                {
                    for (int i = 0; i < 10000; i++)
                    {
                        var placeholders = new InvoicingEndpointFactory<HtmlFormat>(scope);

                        var forInvoice = placeholders.ForInvoice(context, invoice);
                        forInvoice.Action(a => a.Create).RenderAsButton("Add new invoice");
                        forInvoice.Action(a => a.Delete).RenderAsButton("Delete invoice");
                        forInvoice.Action(a => a.Publish).RenderAsButton("Publish invoice");

                        var forInvoiceItem = placeholders.ForInvoiceItem(context, invoiceItem);
                        forInvoiceItem.Action(a => a.RemoveVAT).RenderAsImage("minus.png");
                        forInvoiceItem.Action(a => a.SetPrice).RenderAsImage("dollar.png");

                        count++;
                    }
                }
                var end = DateTime.UtcNow;
                var passesPerSecond = count / end.Subtract(start).TotalSeconds;
                
                //Last time: 170000
                Console.WriteLine(passesPerSecond.ToString("0.00"));
            }
        }
    }
}