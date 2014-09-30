using Lib.SecurityFramework.Domain;

namespace Lib.SecurityFramework.UI
{
    public class InvoiceItemHtmlActions : Domain.Actions.IInvoiceItemActions<MvcEndpoint>
    {
        public IContext Context { get; set; }
        public Invoice Invoice { get; set; }
        public InvoiceItem Item { get; set; }

        public MvcEndpoint Create()
        {
            return new MvcEndpoint
            {
                Controller = "InvoiceItem",
                Action = "Upsert",
                RouteValues = new { parentId = Invoice.InvoiceID }
            };
        }

        public MvcEndpoint Read()
        {
            return new MvcEndpoint
            {
                Controller = "InvoiceItem",
                Action = "Read",
                RouteValues = new { entityId = Item.InvoiceItemID }
            };
        }

        public MvcEndpoint Update()
        {
            return new MvcEndpoint
            {
                Controller = "InvoiceItem",
                Action = "Upsert",
                RouteValues = new { entityId = Item.InvoiceItemID }
            };
        }

        public MvcEndpoint Delete()
        {
            return new MvcEndpoint
            {
                Controller = "InvoiceItem",
                Action = "Delete",
                RouteValues = new { entityId = Item.InvoiceItemID }
            };
        }

        public MvcEndpoint SetPrice()
        {
            return new MvcEndpoint
            {
                Controller = "InvoiceItem",
                Action = "SetPrice",
                RouteValues = new { entityId = Item.InvoiceItemID }
            };
        }

        public MvcEndpoint RemoveVAT()
        {
            return new MvcEndpoint
            {
                Controller = "InvoiceItem",
                Action = "RemoveVAT",
                RouteValues = new { entityId = Item.InvoiceItemID }
            };
        }
    }
}