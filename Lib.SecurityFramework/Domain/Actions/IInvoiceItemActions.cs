using System;

namespace Lib.SecurityFramework.Domain.Actions
{
    public interface IInvoiceItemActions<out T> : IActions<T>
        where T : class
    {
        IContext Context { get; set; }

        Invoice Invoice { get; set; }

        InvoiceItem Item { get; set; }

        T SetPrice();

        T RemoveVAT();
    }
}