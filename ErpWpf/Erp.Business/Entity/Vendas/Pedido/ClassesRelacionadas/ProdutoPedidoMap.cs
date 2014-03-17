using FluentNHibernate.Mapping;

namespace Erp.Business.Entity.Vendas.Pedido.ClassesRelacionadas
{
    public class ProdutoPedidoMap : ClassMap<ProdutoPedido>
    {
        public ProdutoPedidoMap()
        {
            Id(x => x.Id).GeneratedBy.Sequence("sqProdutoPedido").Not.Nullable().Unique();

            Map(x => x.Sequencia);
            Map(x => x.Quantidade);
            Map(x => x.Valor);
            Map(x => x.ValorUnitario);
            Map(x => x.Diferenca);
            Map(x => x.Status);

            References(x => x.Produto).Not.Nullable();
        }
    }
}