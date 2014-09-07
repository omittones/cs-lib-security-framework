namespace Lib.SecurityFramework.Domain
{
    public interface IContext
    {
        bool IsAdminLoggedIn();

        int CompanyID { get; }

        int UserID { get; }
    }

    public class FakeContext : IContext
    {
        public FakeContext()
        {
            CompanyID = 1;
            UserID = 1;
        }

        public bool IsAdminLoggedIn()
        {
            return true;
        }

        public int CompanyID { get; private set; }

        public int UserID { get; private set; }
    }
}