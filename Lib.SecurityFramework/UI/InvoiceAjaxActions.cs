using Lib.SecurityFramework.Domain;
using Lib.SecurityFramework.Domain.Actions;
using Lib.SecurityFramework.Domain.Security;

namespace Lib.SecurityFramework.UI
{
    public class InvoiceAjaxActions : IInvoiceActions<AjaxFormat>
    {
        public IContext Context { get; set; }

        public Invoice Invoice { get; set; }

        public int InvoiceID
        {
            get { return Invoice.InvoiceID; }
        }

        public AjaxFormat Create()
        {
            return new AjaxFormat
            {
                Controller = "Invoice",
                Action = "AjaxUpsert"
            };
        }

        public AjaxFormat Read()
        {
            return new AjaxFormat
            {
                Controller = "Invoice",
                Action = "AjaxGet",
                RouteValues = new { entityId = InvoiceID }
            };
        }

        public AjaxFormat Update()
        {
            return new AjaxFormat
            {
                Controller = "Invoice",
                Action = "AjaxUpsert",
                RouteValues = new { entityId = InvoiceID }
            };
        }

        public AjaxFormat Delete()
        {
            return new AjaxFormat
            {
                Controller = "Invoice",
                Action = "AjaxDelete",
                RouteValues = new { entityId = InvoiceID }
            };
        }

        public AjaxFormat Publish()
        {
            return new AjaxFormat
            {
                Controller = "Invoice",
                Action = "AjaxPublish",
                RouteValues = new { entityId = InvoiceID }
            };
        }

        public AjaxFormat Unpublish()
        {
            return new AjaxFormat
            {
                Controller = "Invoice",
                Action = "AjaxUnpublish",
                RouteValues = new { entityId = InvoiceID }
            };
        }

        public AjaxFormat Send()
        {
            return new AjaxFormat
            {
                Controller = "Invoice",
                Action = "AjaxSend",
                RouteValues = new { entityId = InvoiceID }
            };
        }

        public AjaxFormat Cancel()
        {
            return new AjaxFormat
            {
                Controller = "Invoice",
                Action = "AjaxCancel",
                RouteValues = new { entityId = InvoiceID }
            };
        }
    }
}