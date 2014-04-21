using System.Web.Mvc;

namespace RestauranteMobile.Controllers
{
    public class BaseController : Controller
    {
        public void ErrorMessage(string message)
        {
            ViewBag.ReturnMessage = message;
        }
    }
}