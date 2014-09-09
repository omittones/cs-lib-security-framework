using Lib.SecurityFramework.UI;

namespace Lib.SecurityFramework.Framework
{
    public interface IDisabledEndpointFactory<out T>
    {
        T Create();
    }
}