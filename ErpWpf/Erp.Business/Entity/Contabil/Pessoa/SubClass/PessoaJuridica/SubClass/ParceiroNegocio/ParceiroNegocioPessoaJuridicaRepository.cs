using System.Collections.Generic;
using NHibernate.Criterion;

namespace Erp.Business.Entity.Contabil.Pessoa.SubClass.PessoaJuridica.SubClass.ParceiroNegocio
{
    public class ParceiroNegocioPessoaJuridicaRepository : RepositoryBase<ParceiroNegocioPessoaJuridica>
    {
        public static IList<ParceiroNegocioPessoaJuridica> GetByRange(string filter, int takePesquisa)
        {
            if (filter.Length == Validation.Validation.GetOnlyNumber(filter).Length)
            {
                return GetQueryOver().Where(x => x.Cnpj.IsInsensitiveLike(StartStringFilter(filter))).Take(takePesquisa).List();
            }
            return GetQueryOver().Where(x => x.RazaoSocial.IsInsensitiveLike(ContainsStringFilter(filter)) ||
                x.NomeFantasia.IsInsensitiveLike(ContainsStringFilter(filter))).Take(takePesquisa).List();
        }
    }
}
