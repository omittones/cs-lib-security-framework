using Lib.SecurityFramework.Framework;

namespace Lib.SecurityFramework.UI
{
    public class DisabledHtmlEndpointFactory : IDisabledEndpointFactory<HtmlFormat>
    {
        private class DisabledHtmlFormat : HtmlFormat
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
            return new DisabledHtmlFormat();
        }
    }
}