using System.IO;
using System.Web.Mvc;
using System.Web.Mvc.Html;

namespace RestauranteMobile.Extensions
{
    public static class FormatedDisplayHelper
    {
        public static MvcHtmlString FormatedDisplay(this HtmlHelper helper,
            object value , string pattern = "")
        {
            return new MvcHtmlString(string.Format(pattern, value));
        }
    }
}