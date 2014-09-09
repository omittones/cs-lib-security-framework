using Lib.SecurityFramework.Domain.Actions;
using Lib.SecurityFramework.Framework;

namespace Lib.SecurityFramework.Domain.Security
{
    public class InvoiceSecurity : DatabaseSecurity, IInvoiceActions<SecurityCheckResult>
    {
        public Invoice Invoice { get; set; }

        public InvoiceSecurity()
            : base(DomainObjects.Invoice)
        {
        }

        public override SecurityCheckResult Update()
        {
            return Result(this.Invoice.InvoiceID >= 0 &&
                          this.Invoice.CompanyID == Context.CompanyID &&
                          base.Update().Allowed);
        }

        public override SecurityCheckResult Delete()
        {
            return Result(this.Invoice.Status == InvoiceStatus.Draft &&
                          this.Invoice.CompanyID == Context.CompanyID &&
                          base.Delete().Allowed);
        }

        public SecurityCheckResult Publish()
        {
            return Result(this.Invoice.Status == InvoiceStatus.Draft &&
                          this.Invoice.CompanyID == Context.CompanyID &&
                          this.Update().Allowed);
        }

        public SecurityCheckResult Unpublish()
        {
            return Result(this.Invoice.Status == InvoiceStatus.NotSent &&
                          this.Invoice.CompanyID == Context.CompanyID &&
                          this.Update().Allowed);
        }

        public SecurityCheckResult Send()
        {
            return Result(this.Invoice.Status == InvoiceStatus.NotSent &&
                          this.Context.IsAdminLoggedIn() &&
                          this.Update().Allowed);
        }

        public SecurityCheckResult Cancel()
        {
            return Result(this.Invoice.Status != InvoiceStatus.Paid &&
                          this.Invoice.Status != InvoiceStatus.Cancelled &&
                          this.Invoice.CompanyID == Context.CompanyID &&
                          this.Context.IsAdminLoggedIn() &&
                          this.Update().Allowed);
        }
    }
}