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

            Action.WithFormat<AjaxFormat>().ForInvoice(context, invoice, a => a.Create).RenderWithText("Add new invoice");
            Action.WithFormat<AjaxFormat>().ForInvoice(context, invoice, a => a.Delete).RenderWithText("Delete invoice");
            Action.WithFormat<AjaxFormat>().ForInvoice(context, invoice, a => a.Publish).RenderWithText("Publish invoice");

            Action.WithFormat<AjaxFormat>().ForInvoiceItem(context, invoiceItem, a => a.RemoveVAT).RenderAsImage();
            Action.WithFormat<AjaxFormat>().ForInvoiceItem(context, invoiceItem, a => a.SetPrice).RenderAsImage();
        }
    }
}