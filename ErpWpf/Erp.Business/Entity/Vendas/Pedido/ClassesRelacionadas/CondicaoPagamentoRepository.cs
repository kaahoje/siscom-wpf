using System.Collections.Generic;
using System.Linq;
using Erp.Business.Enum;
using NHibernate.Criterion;

namespace Erp.Business.Entity.Vendas.Pedido.ClassesRelacionadas
{
    public class CondicaoPagamentoRepository : RepositoryBase<CondicaoPagamento>
    {
        public static IList<CondicaoPagamento> GetByDescricao(string text)
        {
            return GetQueryOver().Where(pagamento => pagamento.Descricao.IsInsensitiveLike("%" + text + "%")
                                                     && pagamento.Status == Status.Ativo).List<CondicaoPagamento>();
        }

        public static IEnumerable<CondicaoPagamento> GetByRange(string filter,int take)
        {
            return GetQueryOver().Where(x => x.Descricao.IsInsensitiveLike("%" + filter + "%")).Take(take).List();
        }
    }
}