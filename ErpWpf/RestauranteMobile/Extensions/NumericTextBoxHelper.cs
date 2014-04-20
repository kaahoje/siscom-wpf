using System;
using System.Linq.Expressions;
using System.Web.Mvc;

namespace RestauranteMobile.Extensions
{
    public static class NumericTextBoxHelper
    {
        public static MvcHtmlString NumericBoxFor<TModel,TValue>(this HtmlHelper<TModel> helper,
            Expression<Func<TModel, TValue>> expression)
        {
            var build = new TagBuilder("input");
            build.Attributes.Add("type","number");
            build.Attributes.Add("id",ExtensionFunctions.GetFieldName(expression));
            build.Attributes.Add("name",ExtensionFunctions.GetFieldName(expression).Replace("_","."));
            return new MvcHtmlString(build.ToString());
        }
    }
}