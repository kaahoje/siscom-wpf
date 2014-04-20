using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace RestauranteMobile.Extensions
{
    public static class ButtonHelper
    {
        public static MvcHtmlString SubmitButton(this HtmlHelper helper, string value = "Ok")
        {
            var submit = new TagBuilder("input");
            submit.Attributes.Add("type", "submit");
            submit.Attributes.Add("value", value);
            submit.Attributes.Add("class", "btn btn-primary btn-lg");
            return new MvcHtmlString(submit.ToString());
        }
        public static MvcHtmlString ResetButton(this HtmlHelper helper, string value = "Limpar")
        {
            var submit = new TagBuilder("input");
            submit.Attributes.Add("type", "reset");
            submit.Attributes.Add("value", value);
            submit.Attributes.Add("class", "btn btn-primary btn-lg");
            return new MvcHtmlString(submit.ToString());
        }
    }
}