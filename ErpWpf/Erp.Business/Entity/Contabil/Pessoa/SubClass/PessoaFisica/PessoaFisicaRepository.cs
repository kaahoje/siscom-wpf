using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Security;
using NHibernate.Criterion;
using Util.Seguranca;

namespace Erp.Business.Entity.Contabil.Pessoa.SubClass.PessoaFisica
{
    public class PessoaFisicaRepository : RepositoryBase<PessoaFisica>
    {
        public static void Save(PessoaFisica entity )
        {
            var t = NHibernateHttpModule.Session.BeginTransaction();
            try
            {

                if (ExisteCpf(entity) && entity.Id == 0)
                {
                    throw new Exception("Já existe um CPF cadastrado");
                }
                NHibernateHttpModule.Session.Save(entity);
                t.Commit();
            }
            catch (Exception)
            {
                t.Rollback();
            }
        }

        public static bool ExisteCpf( PessoaFisica entity)
        {
            
            if (entity.Id == 0)
            {
                if (GetByCpf(entity.Cpf) != null)
                {
                    return true;
                }
            }
            
            return false;
        }

        /// <summary>
        /// Método que obtém uma pessoa por meio do campo CPF.
        /// </summary>
        /// <param name="cpf">Número do cpf da pessoa pesquisada.</param>
        /// <returns>Retorna a pessoa referênte ao CPF consultado.</returns>
        public static PessoaFisica GetByCpf(string cpf)
        {
            cpf = Util.Validation.GetOnlyNumber(cpf);

            var usuarioDb = NHibernateHttpModule.Session.QueryOver<PessoaFisica>()
                .Where(x => x.Cpf == cpf)
                .Take(1)
                .SingleOrDefault();

            return usuarioDb;
        }

        public static bool AutenticarUsuario(string login, string senha)
        {
            senha = Criptografia.CriptografarSenha(senha);
            var usuario = GetList().SingleOrDefault(x => x.Login == login && x.Senha == senha);

            if (usuario != null)
            {

                //FormsAuthentication.SetAuthCookie(usuario.Login, false);
                FormsAuthentication.RedirectFromLoginPage(usuario.Login, false);

                return true;
            }

            return false;
        }

        public static PessoaFisica GetPessoaLogada()
        {
            try
            {

                var login = HttpContext.Current.User.Identity.Name;

                if (login == string.Empty)
                {
                    return null;
                }

                var pessoa = GetList().SingleOrDefault(x => x.Login == login);

                return pessoa;
            }
            catch (Exception)
            {
                return null;

            }

        }

        public static void Logoff()
        {
            FormsAuthentication.SignOut();
        }

        public static PessoaFisica GetByLogin(string login)
        {
            return GetList().SingleOrDefault(p => p.Login == login);
        }

        public static IList<PessoaFisica> GetByRange(string filter, int takePesquisa)
        {
            if (filter.Length == Validation.Validation.GetOnlyNumber(filter).Length)
            {
                return GetQueryOver().Where(x => x.Cpf.IsInsensitiveLike(StartStringFilter(filter))).Take(takePesquisa)
                    .List();
            }
            return GetQueryOver().Where(x => x.Nome.IsInsensitiveLike(ContainsStringFilter(filter)) ||
                x.Alias.IsInsensitiveLike(ContainsStringFilter(filter)))
                .Take(takePesquisa)
                .List();
        }
    }
}
