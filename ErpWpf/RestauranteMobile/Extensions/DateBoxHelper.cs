using System;
using System.Linq.Expressions;
using System.Web.Mvc;

namespace RestauranteMobile.Extensions
{
    public static class DateBoxHelper
    {
        public static MvcHtmlString DateBoxFor<TModel, TValue>(this HtmlHelper<TModel> helper,
            Expression<Func<TModel, TValue>> expression, string pattern= "yyyy/MM/dd")
        {
            var div = new TagBuilder("div")
            {
                InnerHtml = string.Format("<input data-format=\"{0}\" type=\"date\" id=\"{1}\"></input>" +
                                          "<span class=\"add-on\"> <i data-time-icon=\"icon-time\" data-date-icon=\"icon-calendar\"></i>" +
                                          "</span>", pattern, ExtensionFunctions.GetFieldName(expression))
            };

            div.Attributes.Add("class", "input-append date");
            //var build = new TagBuilder("input");
            //build.Attributes.Add("type", "date");
            //build.Attributes.Add("class", "input-append date");
            
            //if (!string.IsNullOrEmpty(pattern))
            //{
            //    build.Attributes.Add("pattern", pattern);
            //}
            //build.Attributes.Add("id", ExtensionFunctions.GetFieldName(expression));
            return new MvcHtmlString(div.ToString());
        }
    }
}