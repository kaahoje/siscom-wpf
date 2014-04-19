using System.Web.Mvc;
using Erp.Business;
using Erp.Business.Entity.Contabil.Pessoa.SubClass.PessoaFisica;
using Erp.Business.Entity.Contabil.Pessoa.SubClass.PessoaFisica.SubClass.ParceiroNegocio;
using Erp.Business.Entity.Trabalhista;
using NHibernate.Hql.Ast.ANTLR;
using RestauranteMobile.Models;
using Util.Seguranca;

namespace RestauranteMobile.Controllers
{
    public class LoginController : Controller
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
                return View("Index");
            }
            var senha = Criptografia.CriptografarSenha(model.Senha);
            if (!senha.Equals(pessoa.Senha))
            {
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