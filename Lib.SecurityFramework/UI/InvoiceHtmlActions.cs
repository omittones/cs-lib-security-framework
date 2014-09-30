using Lib.SecurityFramework.Domain;
using Lib.SecurityFramework.Domain.Actions;
using Lib.SecurityFramework.Domain.Security;

namespace Lib.SecurityFramework.UI
{
    public class InvoiceHtmlActions : IInvoiceActions<MvcEndpoint>
    {
        public IContext Context { get; set; }

        public Invoice Invoice { get; set; }

        public int InvoiceID
        {
            get { return Invoice.InvoiceID; }
        }

        public MvcEndpoint Create()
        {
            return new MvcEndpoint
            {
                Controller = "Invoice",
                Action = "HtmlUpsert",
                RouteValues = new { parentId = Context.CompanyID }
            };
        }

        public MvcEndpoint Read()
        {
            return new MvcEndpoint
            {
                Controller = "Invoice",
                Action = "HtmlGet",
                RouteValues = new { entityId = InvoiceID }
            };
        }

        public MvcEndpoint Update()
        {
            return new MvcEndpoint
            {
                Controller = "Invoice",
                Action = "HtmlUpsert",
                RouteValues = new { entityId = InvoiceID }
            };
        }

        public MvcEndpoint Delete()
        {
            return new MvcEndpoint
            {
                Controller = "Invoice",
                Action = "HtmlDelete",
                RouteValues = new { entityId = InvoiceID }
            };
        }

        public MvcEndpoint Publish()
        {
            return new MvcEndpoint
            {
                Controller = "Invoice",
                Action = "HtmlPublish",
                RouteValues = new { entityId = InvoiceID }
            };
        }

        public MvcEndpoint Unpublish()
        {
            return new MvcEndpoint
            {
                Controller = "Invoice",
                Action = "HtmlUnpublish",
                RouteValues = new { entityId = InvoiceID }
            };
        }

        public MvcEndpoint Send()
        {
            return new MvcEndpoint
            {
                Controller = "Invoice",
                Action = "HtmlSend",
                RouteValues = new { entityId = InvoiceID }
            };
        }

        public MvcEndpoint Cancel()
        {
            return new MvcEndpoint
            {
                Controller = "Invoice",
                Action = "HtmlCancel",
                RouteValues = new { entityId = InvoiceID }
            };
        }
    }
}