namespace Lib.SecurityFramework.Framework
{
    public class SecurityCheckResult
    {
        public static readonly SecurityCheckResult Ok = new SecurityCheckResult(true);

        public static readonly SecurityCheckResult Fail = new SecurityCheckResult(false);

        public SecurityCheckResult(bool allowed)
        {
            this.Allowed = allowed;
        }

        public bool Allowed { get; private set; }
    }
}