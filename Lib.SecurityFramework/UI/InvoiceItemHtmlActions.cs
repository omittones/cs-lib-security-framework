using Lib.SecurityFramework.Domain;

namespace Lib.SecurityFramework.UI
{
    public class InvoiceItemHtmlActions : Domain.Actions.IInvoiceItemActions<HtmlFormat>
    {
        public IContext Context { get; set; }
        public Invoice Invoice { get; set; }
        public InvoiceItem Item { get; set; }

        public HtmlFormat Create()
        {
            return new HtmlFormat
            {
                Controller = "InvoiceItem",
                Action = "Upsert",
                RouteValues = new { parentId = Invoice.InvoiceID }
            };
        }

        public HtmlFormat Read()
        {
            return new HtmlFormat
            {
                Controller = "InvoiceItem",
                Action = "Read",
                RouteValues = new { entityId = Item.InvoiceItemID }
            };
        }

        public HtmlFormat Update()
        {
            return new HtmlFormat
            {
                Controller = "InvoiceItem",
                Action = "Upsert",
                RouteValues = new { entityId = Item.InvoiceItemID }
            };
        }

        public HtmlFormat Delete()
        {
            return new HtmlFormat
            {
                Controller = "InvoiceItem",
                Action = "Delete",
                RouteValues = new { entityId = Item.InvoiceItemID }
            };
        }

        public HtmlFormat SetPrice()
        {
            return new HtmlFormat
            {
                Controller = "InvoiceItem",
                Action = "SetPrice",
                RouteValues = new { entityId = Item.InvoiceItemID }
            };
        }

        public HtmlFormat RemoveVAT()
        {
            return new HtmlFormat
            {
                Controller = "InvoiceItem",
                Action = "RemoveVAT",
                RouteValues = new { entityId = Item.InvoiceItemID }
            };
        }
    }
}