using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Lib.SecurityFramework.Domain;
using Lib.SecurityFramework.Framework;
using Lib.SecurityFramework.UI;

namespace Lib.SecurityFramework
{
    public static class Program
    {
        public static void Main()
        {
            IContext context = null;
            Invoice invoice = null;
            InvoiceItem invoiceItem = null;

            ActionPlaceholder.With<AjaxFormat>().ForInvoice(context, invoice, a => a.Create).RenderWithText("Add new invoice");
            ActionPlaceholder.With<AjaxFormat>().ForInvoice(context, invoice, a => a.Delete).RenderWithText("Delete invoice");
            ActionPlaceholder.With<AjaxFormat>().ForInvoice(context, invoice, a => a.Publish).RenderWithText("Publish invoice");

            ActionPlaceholder.With<AjaxFormat>().ForInvoiceItem(context, invoiceItem, a => a.RemoveVAT).RenderAsImage();
            ActionPlaceholder.With<AjaxFormat>().ForInvoiceItem(context, invoiceItem, a => a.SetPrice).RenderAsImage();
        }
    }
}