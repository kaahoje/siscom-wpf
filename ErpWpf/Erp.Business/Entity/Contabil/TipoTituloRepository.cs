using System.Collections.Generic;
using Erp.Business.Enum;
using NHibernate.Criterion;

namespace Erp.Business.Entity.Contabil
{
    public class TipoTituloRepository : RepositoryBase<TipoTitulo>
    {
        public static IList<TipoTitulo> GetByRange(string filter, int takePesquisa)
        {
            return
                GetQueryOver()
                    .Where(x => x.Descricao.IsInsensitiveLike(ContainsStringFilter(filter)) &&
                        x.Status == Status.Ativo)
                    .Take(takePesquisa)
                    .List();
        }
    }
}