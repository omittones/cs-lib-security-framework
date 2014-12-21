using Lib.SecurityFramework.Domain;
using Lib.SecurityFramework.Domain.Actions;

namespace Lib.SecurityFramework.UI
{
    public class InvoiceItemHtmlActions : IInvoiceItemActions<HtmlEndpoint>
    {
        public IContext Context { get; set; }
        public Invoice Invoice { get; set; }
        public InvoiceItem Item { get; set; }

        public HtmlEndpoint Create()
        {
            return new HtmlEndpoint
            {
                Controller = "InvoiceItem",
                Action = "Upsert",
                RouteValues = new { parentId = Invoice.InvoiceID }
            };
        }

        public HtmlEndpoint Read()
        {
            return new HtmlEndpoint
            {
                Controller = "InvoiceItem",
                Action = "Read",
                RouteValues = new { entityId = Item.InvoiceItemID }
            };
        }

        public HtmlEndpoint Update()
        {
            return new HtmlEndpoint
            {
                Controller = "InvoiceItem",
                Action = "Upsert",
                RouteValues = new { entityId = Item.InvoiceItemID }
            };
        }

        public HtmlEndpoint Delete()
        {
            return new HtmlEndpoint
            {
                Controller = "InvoiceItem",
                Action = "Delete",
                RouteValues = new { entityId = Item.InvoiceItemID }
            };
        }

        public HtmlEndpoint SetPrice()
        {
            return new HtmlEndpoint
            {
                Controller = "InvoiceItem",
                Action = "SetPrice",
                RouteValues = new { entityId = Item.InvoiceItemID }
            };
        }

        public HtmlEndpoint RemoveVAT()
        {
            return new HtmlEndpoint
            {
                Controller = "InvoiceItem",
                Action = "RemoveVAT",
                RouteValues = new { entityId = Item.InvoiceItemID }
            };
        }
    }
}