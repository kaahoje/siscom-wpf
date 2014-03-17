using FluentNHibernate.Mapping;

namespace Erp.Business.Entity.Vendas.Pedido.ClassesRelacionadas
{
    public class PagamentoPedidoMap : ClassMap<PagamentoPedido>
    {
        public PagamentoPedidoMap()
        {
            Id(x => x.Id).GeneratedBy.Sequence("sqPagamentoPedido").Not.Nullable().Unique();

            Map(x => x.Parcela).Not.Nullable();
            Map(x => x.Vencimento).Not.Nullable();
            Map(x => x.Valor).Not.Nullable().Check("Valor > 0");
            Map(x => x.Juros).Not.Nullable();
            Map(x => x.ValorTotal).Not.Nullable().Check("Valor > 0");
            Map(x => x.Desconto);
            Map(x => x.Status);

            References(x => x.FormaPagamento).Not.Nullable();
            References(x => x.Pedido).Not.Nullable();
        }
    }
}