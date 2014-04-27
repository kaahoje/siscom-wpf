using System.Web.Mvc;
using Erp.Business.Entity.Configuracao;

namespace RestauranteMobile.Controllers
{
    public class BaseController : Controller
    {
        private ConfiguracaoGeral _configuracaoGeral;

        public ConfiguracaoGeral ConfiguracaoGeral
        {
            get { return _configuracaoGeral?? (_configuracaoGeral = ConfiguracaoGeralRepository.GetById(1)); }
            set { _configuracaoGeral = value; }
        }

        public void ErrorMessage(string message)
        {
            ViewBag.ReturnMessage = message;
        }
    }
}