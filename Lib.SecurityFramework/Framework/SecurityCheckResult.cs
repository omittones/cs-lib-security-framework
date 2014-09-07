namespace Lib.SecurityFramework.Framework
{
    public class SecurityCheckResult
    {
        public SecurityCheckResult(bool allowed)
        {
            this.Allowed = allowed;
        }
        public bool Allowed { get; private set; }
    }
}