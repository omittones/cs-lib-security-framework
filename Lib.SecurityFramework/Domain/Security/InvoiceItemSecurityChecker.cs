using Lib.SecurityFramework.Domain.Actions;
using Lib.SecurityFramework.Framework;

namespace Lib.SecurityFramework.Domain.Security
{
    public class InvoiceItemSecurityChecker : DatabaseUserPermissionsChecker, IInvoiceItemActions<SecurityCheckResult>
    {
        private readonly InvoiceSecurityChecker invoiceSecurity;

        public InvoiceItemSecurityChecker() : base(DomainObjects.InvoiceItem)
        {
            this.invoiceSecurity = new InvoiceSecurityChecker();
        }

        public Invoice Invoice
        {
            get { return invoiceSecurity.Invoice; }
            set { invoiceSecurity.Invoice = value; }
        }

        public override IContext Context
        {
            get { return invoiceSecurity.Context; }
            set { invoiceSecurity.Context = value; }
        }

        public InvoiceItem Item { get; set; }

        public SecurityCheckResult SetPrice()
        {
            return invoiceSecurity.Update();
        }

        public SecurityCheckResult RemoveVAT()
        {
            return invoiceSecurity.Update();
        }
    }
}