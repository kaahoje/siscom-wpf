using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Mvc.Ajax;

namespace RestauranteMobile.Extensions
{
    public static class LinkHelper
    {
        public static MvcHtmlString Link(this HtmlHelper helper, string texto, string url)
        {
            var link = new TagBuilder("a");
            link.Attributes.Add("class", "btn btn-lg btn-primary");
            link.Attributes.Add("style", "text-decoration: none; color: white");
            link.Attributes.Add("href", url);
            link.InnerHtml = texto;
            return new MvcHtmlString(link.ToString());
        }

        public static MvcHtmlString Link(this AjaxHelper ajax, string texto, string actionName, string controllerName,
            object rootValues, string tagToUpdate = "content")
        {
            return ajax.ActionLink(texto, actionName, controllerName, rootValues, new AjaxOptions
            {
                HttpMethod = "POST",
                OnSuccess = "function(data){$('#"+ tagToUpdate +"').html(data);}"
            }, new { @class = "btn-primary btn-block btn-lg" });
        }
        public static MvcHtmlString LinkBlock(this AjaxHelper ajax, string texto, string actionName, string controllerName,
            string tagToUpdate = "content")
        {
            return ajax.ActionLink(texto, actionName, controllerName,null, new AjaxOptions
            {
                HttpMethod = "POST",
                OnSuccess = "function(data){$('#" + tagToUpdate + "').html(data);}"
            },new { @class = "btn-primary btn-block btn-lg" });
        }
        public static MvcHtmlString LinkBlock(this AjaxHelper ajax, string texto, string actionName, string controllerName,
            object routValues, string tagToUpdate = "content")
        {
            return ajax.ActionLink(texto, actionName, controllerName,routValues, new AjaxOptions
            {
                HttpMethod = "POST",
                OnSuccess = "function(data){$('#" + tagToUpdate + "').html(data);}"
            },new { @class = "btn-primary btn-block btn-lg" });
        }
        public static MvcHtmlString Link(this AjaxHelper ajax, string texto, string actionName, string controllerName,
            string tagToUpdate = "content")
        {
            return ajax.ActionLink(texto, actionName, controllerName,null, new AjaxOptions
            {
                HttpMethod = "POST",
                OnSuccess = "function(data){$('#" + tagToUpdate + "').html(data);}"
            },new { @class = "btn-primary btn-lg" });
        }
    }
}