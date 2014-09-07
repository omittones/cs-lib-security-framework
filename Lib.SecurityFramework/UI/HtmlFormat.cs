using Lib.SecurityFramework.Framework;

namespace Lib.SecurityFramework.UI
{
    public class HtmlFormat : IActionFormat
    {
        public string Controller { get; set; }
        public string Action { get; set; }
        public object RouteValues { get; set; }

        public virtual string RenderAsButton(string text)
        {
            return "<button>" + text + "</button>";
        }

        public virtual string RenderAsImage(string src)
        {
            return "<img src=\"" + src + "\"/>";
        }
    }
}