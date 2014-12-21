namespace Lib.SecurityFramework.Framework
{
    public sealed class SecurityCheckResult
    {
        public static readonly SecurityCheckResult Ok = new SecurityCheckResult(true);

        public static readonly SecurityCheckResult Fail = new SecurityCheckResult(false);

        private SecurityCheckResult(bool allowed)
        {
            this.Allowed = allowed;
        }

        public bool Allowed { get; private set; }
    }
}