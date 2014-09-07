namespace Lib.SecurityFramework.Domain.Actions
{
    public interface IActions<out T>
        where T : class
    {
        T Create();
        T Read();
        T Update();
        T Delete();
    }
}