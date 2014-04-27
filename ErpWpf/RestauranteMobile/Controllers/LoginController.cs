using System.Web.Mvc;
using Erp.Business.Entity.Contabil.Pessoa.SubClass.PessoaFisica.SubClass.ParceiroNegocio;
using RestauranteMobile.Models;
using Util.Seguranca;

namespace RestauranteMobile.Controllers
{
    public class LoginController : BaseController
    {
        //
        // GET: /Login/
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult Entrar(LoginModel model)
        {
            var pessoa = ParceiroNegocioPessoaFisicaRepository.GetByLogin(model.Usuario);
            if (pessoa == null)
            {
                ErrorMessage("Usuário inválido.");
                return View("Index");
            }
            var senha = Criptografia.CriptografarSenha(model.Senha);
            if (!senha.Equals(pessoa.Senha))
            {
                ErrorMessage("Senha inválida.");
                return View("Index");
            }
            return RedirectToAction("Index", "Home");
        }
        public ActionResult Sair()
        {

            return View("Index");
        }

        public static ParceiroNegocioPessoaFisica GetPessoaLogada()
        {
            return null;
        }
	}
}