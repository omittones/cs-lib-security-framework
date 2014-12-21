namespace Lib.SecurityFramework.Framework
{
    public interface IDisabledEndpointFactory<out T>
    {
        T Create();
    }
}