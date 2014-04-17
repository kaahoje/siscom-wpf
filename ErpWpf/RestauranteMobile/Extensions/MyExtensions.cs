using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Mvc.Html;
using System.Web.Routing;

namespace RestauranteMobile.Extensions
{
    public class MyExtensions
    {

        public MvcHtmlString SpinEdit(HtmlHelper helper)
        {
            return helper.TextBox("teste", "", new {@type = "numeric"});
        }
    }
}