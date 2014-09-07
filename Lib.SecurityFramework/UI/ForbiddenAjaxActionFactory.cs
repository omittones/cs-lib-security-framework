using Lib.SecurityFramework.Framework;

namespace Lib.SecurityFramework.UI
{
    public class ForbiddenAjaxActionFactory : IForbiddenActionFactory<AjaxFormat>
    {
        private class ForbiddenAjaxFormat : AjaxFormat
        {
            public override string RenderAsImage()
            {
                return "Forbidden!";
            }

            public override string RenderWithText(string text)
            {
                return text + " is forbidden!";
            }
        }

        public AjaxFormat Create()
        {
            return new ForbiddenAjaxFormat();
        }
    }
}