using System.Collections.Generic;
using System.Linq;
using NHibernate.Criterion;
using NHibernate.SqlCommand;

namespace Erp.Business.Entity.Contabil.Pessoa.SubClass.PessoaJuridica.SubClass.ParceiroNegocio.ClassesRelacionadas
{
    public class CustoFixoParceiroNegocioPessoaJuridicaRepository : RepositoryBase<CustoFixoParceiroNegocioPessoaJuridica>
    {
        public static IList<CustoFixoParceiroNegocioPessoaJuridica> GetByRange(string filter, int takePesquisa)
        {
            if (filter.Length == Validation.Validation.GetOnlyNumber(filter).Length)
            {
                return GetList().Where(custo => custo.ParceiroNegocioPessoaJuridica != null &&(
                    custo.ParceiroNegocioPessoaJuridica.Cnpj.IsInsensitiveLike(ContainsStringFilter(filter))))
                    .ToList();
                //return GetQueryOver().JoinQueryOver(custo => custo.ParceiroNegocioPessoaJuridica)
                //    .Where(parceiroNegocio => parceiroNegocio.Cnpj.IsInsensitiveLike(StartStringFilter(filter)))
                //    .Take(takePesquisa).List();
            }
            return GetQueryOver().JoinQueryOver(custo => custo.ParceiroNegocioPessoaJuridica,JoinType.FullJoin)
                    .Where(parceiroNegocio => parceiroNegocio.RazaoSocial.IsInsensitiveLike(ContainsStringFilter(filter)) ||
                        parceiroNegocio.NomeFantasia.IsInsensitiveLike(ContainsStringFilter(filter)))
                    .Take(takePesquisa).List();
        }
    }
}
