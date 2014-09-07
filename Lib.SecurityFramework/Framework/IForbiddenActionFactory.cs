using Lib.SecurityFramework.UI;

namespace Lib.SecurityFramework.Framework
{
    public interface IForbiddenActionFactory<out T>
    {
        T Create();
    }
}