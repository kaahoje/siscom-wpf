using System.Collections.Generic;
using Erp.Business.Enum;
using NHibernate.Criterion;

namespace Erp.Business.Entity.Vendas.Pedido.ClassesRelacionadas
{
    public class FormaPagamentoRepository : RepositoryBase<FormaPagamento>
    {
        public static IList<FormaPagamento> GetFormasPagamentoAVista()
        {
            return GetQueryOver().Where(pagamento => pagamento.AVista).List<FormaPagamento>();
        }

        public static IList<FormaPagamento> GetFormasPagamentoAPrazo()
        {
            return GetQueryOver().Where(pagamento => !pagamento.AVista).List<FormaPagamento>();
        }

        public static IList<FormaPagamento> GetByDescricao(string text)
        {
            return GetQueryOver().Where(pagamento => pagamento.Descricao.IsInsensitiveLike("%" + text + "%"))
                .List<FormaPagamento>();
        }

        public static IList<FormaPagamento> GetByRange(string filter, int takePesquisa)
        {
            return GetQueryOver().Where(x => (x.Descricao.IsInsensitiveLike("%" + filter + "%")) && 
                x.Status == Status.Ativo)
                .Take(takePesquisa).List();
        }
    }
}