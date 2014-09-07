using Lib.SecurityFramework.Framework;

namespace Lib.SecurityFramework.UI
{
    public class ForbiddenHtmlActionFactory : IForbiddenActionFactory<HtmlFormat>
    {
        private class ForbiddenHtmlFormat : HtmlFormat
        {
            public override string RenderAsImage()
            {
                return "<span>Forbidden!</span>";
            }

            public override string RenderWithText(string text)
            {
                return "<span>" + text + "</span>";
            }
        }

        public HtmlFormat Create()
        {
            return new ForbiddenHtmlFormat();
        }
    }
}