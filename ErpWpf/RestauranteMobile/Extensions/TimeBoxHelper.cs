using System;
using System.Linq.Expressions;
using System.Web.Mvc;

namespace RestauranteMobile.Extensions
{
    public static class TimeBoxHelper
    {
        public static MvcHtmlString TimeBoxFor<TModel, TValue>(this HtmlHelper<TModel> helper,
            Expression<Func<TModel, TValue>> expression, string pattern = "hh:mm:ss")
        {
            var div = new TagBuilder("div")
            {
                InnerHtml = string.Format("<input data-format=\"{0}\" type=\"time\" id=\"{1}\"></input>" +
                                          "<span class=\"add-on\"> <i data-time-icon=\"icon-time\" data-date-icon=\"icon-calendar\"></i>" +
                                          "</span>", pattern, ExtensionFunctions.GetFieldName(expression))
            };

            div.Attributes.Add("class", "bootstrap-timepicker");

            //var build = new TagBuilder("input");
            //build.Attributes.Add("type", "time");
            //build.Attributes.Add("class", "bootstrap-timepicker");
            //if (!string.IsNullOrEmpty(pattern))
            //{
            //    build.Attributes.Add("pattern", pattern);
            //}
            //build.Attributes.Add("id", ExtensionFunctions.GetFieldName(expression));
            return new MvcHtmlString(div.ToString());
        }
    }
}