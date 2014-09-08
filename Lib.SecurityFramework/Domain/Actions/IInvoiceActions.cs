using System;

namespace Lib.SecurityFramework.Domain.Actions
{
    public interface IInvoiceActions<out T> : IActions<T>
        where T : class
    {
        IContext Context { get; set; }

        Invoice Invoice { get; set; }

        T Publish();

        T Unpublish();

        T Send();

        T Cancel();
    }
}