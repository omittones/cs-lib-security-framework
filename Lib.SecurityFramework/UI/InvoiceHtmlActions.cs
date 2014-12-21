using Lib.SecurityFramework.Domain;
using Lib.SecurityFramework.Domain.Actions;

namespace Lib.SecurityFramework.UI
{
    public class InvoiceHtmlActions : IInvoiceActions<HtmlEndpoint>
    {
        public IContext Context { get; set; }

        public Invoice Invoice { get; set; }

        public int InvoiceID
        {
            get { return Invoice.InvoiceID; }
        }

        public HtmlEndpoint Create()
        {
            return new HtmlEndpoint
            {
                Controller = "Invoice",
                Action = "HtmlUpsert",
                RouteValues = new { parentId = Context.CompanyID }
            };
        }

        public HtmlEndpoint Read()
        {
            return new HtmlEndpoint
            {
                Controller = "Invoice",
                Action = "HtmlGet",
                RouteValues = new { entityId = InvoiceID }
            };
        }

        public HtmlEndpoint Update()
        {
            return new HtmlEndpoint
            {
                Controller = "Invoice",
                Action = "HtmlUpsert",
                RouteValues = new { entityId = InvoiceID }
            };
        }

        public HtmlEndpoint Delete()
        {
            return new HtmlEndpoint
            {
                Controller = "Invoice",
                Action = "HtmlDelete",
                RouteValues = new { entityId = InvoiceID }
            };
        }

        public HtmlEndpoint Publish()
        {
            return new HtmlEndpoint
            {
                Controller = "Invoice",
                Action = "HtmlPublish",
                RouteValues = new { entityId = InvoiceID }
            };
        }

        public HtmlEndpoint Unpublish()
        {
            return new HtmlEndpoint
            {
                Controller = "Invoice",
                Action = "HtmlUnpublish",
                RouteValues = new { entityId = InvoiceID }
            };
        }

        public HtmlEndpoint Send()
        {
            return new HtmlEndpoint
            {
                Controller = "Invoice",
                Action = "HtmlSend",
                RouteValues = new { entityId = InvoiceID }
            };
        }

        public HtmlEndpoint Cancel()
        {
            return new HtmlEndpoint
            {
                Controller = "Invoice",
                Action = "HtmlCancel",
                RouteValues = new { entityId = InvoiceID }
            };
        }
    }
}