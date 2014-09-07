using Lib.SecurityFramework.Domain;
using Lib.SecurityFramework.Domain.Actions;
using Lib.SecurityFramework.Domain.Security;

namespace Lib.SecurityFramework.UI
{
    public class InvoiceHtmlActions : IInvoiceActions<HtmlFormat>
    {
        public IContext Context { get; set; }

        public Invoice Invoice { get; set; }

        public int InvoiceID
        {
            get { return Invoice.InvoiceID; }
        }

        public HtmlFormat Create()
        {
            return new HtmlFormat
            {
                Controller = "Invoice",
                Action = "HtmlUpsert",
                RouteValues = new { parentId = Context.CompanyID }
            };
        }

        public HtmlFormat Read()
        {
            return new HtmlFormat
            {
                Controller = "Invoice",
                Action = "HtmlGet",
                RouteValues = new { entityId = InvoiceID }
            };
        }

        public HtmlFormat Update()
        {
            return new HtmlFormat
            {
                Controller = "Invoice",
                Action = "HtmlUpsert",
                RouteValues = new { entityId = InvoiceID }
            };
        }

        public HtmlFormat Delete()
        {
            return new HtmlFormat
            {
                Controller = "Invoice",
                Action = "HtmlDelete",
                RouteValues = new { entityId = InvoiceID }
            };
        }

        public HtmlFormat Publish()
        {
            return new HtmlFormat
            {
                Controller = "Invoice",
                Action = "HtmlPublish",
                RouteValues = new { entityId = InvoiceID }
            };
        }

        public HtmlFormat Unpublish()
        {
            return new HtmlFormat
            {
                Controller = "Invoice",
                Action = "HtmlUnpublish",
                RouteValues = new { entityId = InvoiceID }
            };
        }

        public HtmlFormat Send()
        {
            return new HtmlFormat
            {
                Controller = "Invoice",
                Action = "HtmlSend",
                RouteValues = new { entityId = InvoiceID }
            };
        }

        public HtmlFormat Cancel()
        {
            return new HtmlFormat
            {
                Controller = "Invoice",
                Action = "HtmlCancel",
                RouteValues = new { entityId = InvoiceID }
            };
        }
    }
}