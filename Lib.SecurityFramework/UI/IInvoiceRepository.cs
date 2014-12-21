using Lib.SecurityFramework.Domain;

namespace Lib.SecurityFramework.UI
{
    public interface IInvoiceRepository
    {
        Invoice GetInvoice(int invoiceId);
    }
}