using System;
using System.Linq.Expressions;
using System.Web;
using System.Web.Helpers;
using System.Web.Mvc;
using System.Web.Mvc.Html;

namespace RestauranteMobile.Extensions
{
    public static class AutoCompleteHelper
    {
        public static object GetAutoCompleteItem(string idVal = "", string labelVal = "",
            string descVal = "", string iconVal = "", object adicionalVal= null)
        {
            return new { label = labelVal, value = idVal, desc = descVal, icon = iconVal, 
                adicionalValues = adicionalVal};
        }

        public static MvcHtmlString AutocompleteFor<TModel, TValue>(this HtmlHelper<TModel> helper,
            Expression<Func<TModel, TValue>> expression, string searchUrl)
        {
            var fieldName =ExtensionFunctions.GetFieldName(expression);
            var hidden = helper.HiddenFor(expression);
            var autoCompName = fieldName + "AutoComplete";
            var script = new TagBuilder("script");
            script.Attributes.Add("type", "text/javascript");
            script.Attributes.Add("language", "javascript");
            script.InnerHtml = "$(function() {$('#" + autoCompName + "').autocomplete(" +
                               "{ focus: function(event, ui) {" +
                               "$('#" + autoCompName + "').val(ui.item.label); " +
                               "return false; }, select: function (evt, ui) {" +
                "$(\"#" + fieldName + "\").val(ui.item.value); $('#" + autoCompName + "').val(ui.item.label);" +
                "return false; }});})";
            var autoComplete = new TagBuilder("input");
            autoComplete.Attributes.Add("id",autoCompName);
            autoComplete.Attributes.Add("data-autocomplete", searchUrl);
            return new MvcHtmlString(script + hidden.ToHtmlString() +
            autoComplete);
        }
    }
}