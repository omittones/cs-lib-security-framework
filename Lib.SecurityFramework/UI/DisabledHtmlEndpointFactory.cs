using Lib.SecurityFramework.Framework;

namespace Lib.SecurityFramework.UI
{
    public class DisabledHtmlEndpointFactory : IDisabledEndpointFactory<HtmlEndpoint>
    {
        private class DisabledHtmlEndpoint : HtmlEndpoint
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

        public HtmlEndpoint Create()
        {
            return new DisabledHtmlEndpoint();
        }
    }
}