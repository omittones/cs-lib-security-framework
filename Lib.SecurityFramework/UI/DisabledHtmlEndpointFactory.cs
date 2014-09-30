using Lib.SecurityFramework.Framework;

namespace Lib.SecurityFramework.UI
{
    public class DisabledHtmlEndpointFactory : IDisabledEndpointFactory<MvcEndpoint>
    {
        private class DisabledMvcEndpoint : MvcEndpoint
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

        public MvcEndpoint Create()
        {
            return new DisabledMvcEndpoint();
        }
    }
}