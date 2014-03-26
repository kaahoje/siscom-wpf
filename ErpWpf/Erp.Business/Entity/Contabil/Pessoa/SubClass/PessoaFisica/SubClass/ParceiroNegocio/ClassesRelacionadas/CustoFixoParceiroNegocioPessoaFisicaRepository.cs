using System.Collections.Generic;
using NHibernate.Criterion;

namespace Erp.Business.Entity.Contabil.Pessoa.SubClass.PessoaFisica.SubClass.ParceiroNegocio.ClassesRelacionadas
{
    public class CustoFixoParceiroNegocioPessoaFisicaRepository : RepositoryBase<CustoFixoParceiroNegocioPessoaFisica>
    {
        public static IList<CustoFixoParceiroNegocioPessoaFisica> GetByRange(string filter, int takePesquisa)
        {

            if (filter.Length == Validation.Validation.GetOnlyNumber(filter).Length)
            {
                return GetQueryOver().JoinQueryOver(custo => custo.ParceiroNegocioPessoaFisica)
                    .Where(ParceiroNegocio => ParceiroNegocio.Cpf.IsInsensitiveLike(StartStringFilter(filter)))
                    .Take(takePesquisa).List();
            }
            return GetQueryOver().JoinQueryOver(custo => custo.ParceiroNegocioPessoaFisica)
                    .Where(ParceiroNegocio => ParceiroNegocio.Nome.IsInsensitiveLike(ContainsStringFilter(filter)) ||
                        ParceiroNegocio.Alias.IsInsensitiveLike(ContainsStringFilter(filter)))
                    .Take(takePesquisa).List();
        }
    }
}
