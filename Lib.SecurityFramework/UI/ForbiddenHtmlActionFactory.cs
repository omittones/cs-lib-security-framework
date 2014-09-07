using Lib.SecurityFramework.Framework;

namespace Lib.SecurityFramework.UI
{
    public class ForbiddenHtmlActionFactory : IForbiddenActionFactory<HtmlFormat>
    {
        private class ForbiddenHtmlFormat : HtmlFormat
        {
            public override string RenderAsImage(string src)
            {
                return "<img class=\"disabled\" src=\"" + src + "\" />";
            }

            public override string RenderAsButton(string text)
            {
                return "<span class=\"disabled button\">" + text + "</span>";
            }
        }

        public HtmlFormat Create()
        {
            return new ForbiddenHtmlFormat();
        }
    }
}