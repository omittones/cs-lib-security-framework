using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Lib.SecurityFramework.Domain;
using Lib.SecurityFramework.Framework;
using Autofac;
using Lib.SecurityFramework.UI;
using Should;

namespace Lib.SecurityFramework
{
    public static class Program
    {
        public static string WriteLine(this string format, params object[] args)
        {
            string result = string.Format(format, args);

            Console.WriteLine(result);

            return result;
        }

        public static void Main()
        {
            ContainerBuilder builder = new ContainerBuilder();
            builder.RegisterType<UI.DisabledHtmlEndpointFactory>().AsImplementedInterfaces().InstancePerLifetimeScope();
            builder.RegisterType<UI.InvoiceHtmlActions>().AsImplementedInterfaces().InstancePerLifetimeScope();
            builder.RegisterType<UI.InvoiceItemHtmlActions>().AsImplementedInterfaces().InstancePerLifetimeScope();
            builder.RegisterType<Domain.Security.InvoiceSecurity>().AsImplementedInterfaces().InstancePerLifetimeScope();
            builder.RegisterType<Domain.Security.InvoiceItemSecurity>().AsImplementedInterfaces().InstancePerLifetimeScope();
            builder.RegisterGeneric(typeof (InvoicingEndpointFactory<>)).AsSelf().InstancePerLifetimeScope();

            using (var container = builder.Build())
            using (var scope = container.BeginLifetimeScope())
            {
                IContext context = new FakeContext();
                Invoice invoice = new Invoice { CompanyID = 1, InvoiceID = 1, Status = InvoiceStatus.Draft };
                InvoiceItem invoiceItem = new InvoiceItem { InvoiceID = 1, InvoiceItemID = 1 };

                var htmlEndpoint = scope.Resolve<InvoicingEndpointFactory<HtmlEndpoint>>();

                try
                {
                    const string disabledClass = "class=\"disabled";

                    var forInvoice = htmlEndpoint.ForInvoice(context, invoice);
                    forInvoice.Action(a => a.Create).RenderAsButton("Add new invoice")
                        .WriteLine()
                        .ShouldContain(disabledClass);
                    forInvoice.Action(a => a.Delete).RenderAsButton("Delete invoice")
                        .WriteLine()
                        .ShouldContain(disabledClass);
                    forInvoice.Action(a => a.Publish).RenderAsButton("Publish invoice")
                        .WriteLine()
                        .ShouldNotContain(disabledClass);

                    var forInvoiceItem = htmlEndpoint.ForInvoiceItem(context, invoiceItem);
                    forInvoiceItem.Action(a => a.RemoveVAT).RenderAsImage("minus.png")
                        .WriteLine()
                        .ShouldNotContain(disabledClass);
                    forInvoiceItem.Action(a => a.SetPrice).RenderAsImage("dollar.png")
                        .WriteLine()
                        .ShouldNotContain(disabledClass);
                }
                catch (Exception ex)
                {
                    ex.Message.WriteLine();
                    return;
                }

                int count = 0;
                var start = DateTime.UtcNow;
                while (DateTime.UtcNow.Subtract(start).TotalSeconds < 2)
                {
                    for (int i = 0; i < 10000; i++)
                    {
                        htmlEndpoint = scope.Resolve<InvoicingEndpointFactory<HtmlEndpoint>>();

                        var forInvoice = htmlEndpoint.ForInvoice(context, invoice);
                        forInvoice.Action(a => a.Create).RenderAsButton("Add new invoice");
                        forInvoice.Action(a => a.Delete).RenderAsButton("Delete invoice");
                        forInvoice.Action(a => a.Publish).RenderAsButton("Publish invoice");

                        var forInvoiceItem = htmlEndpoint.ForInvoiceItem(context, invoiceItem);
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