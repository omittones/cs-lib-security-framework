namespace Lib.SecurityFramework.Domain
{
    public interface IContext
    {
        bool IsAdminLoggedIn();

        int CompanyID { get; }

        int UserID { get; }
    }
}