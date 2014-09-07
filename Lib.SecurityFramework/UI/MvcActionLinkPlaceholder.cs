using Lib.SecurityFramework.Framework;

namespace Lib.SecurityFramework.UI
{
    public class AjaxFormat : IActionFormat
    {
        public string Controller { get; set; }
        public string Action { get; set; }
        public object RouteValues { get; set; }

        public virtual string RenderWithText(string text)
        {
            return text;
        }

        public virtual string RenderAsImage()
        {
            return string.Empty;
        }
    }
}