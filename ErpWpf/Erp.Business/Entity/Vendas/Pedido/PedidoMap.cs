using FluentNHibernate.Mapping;

namespace Erp.Business.Entity.Vendas.Pedido
{
    public class PedidoMap : ClassMap<Pedido>
    {
        public PedidoMap()
        {
            Id(x => x.Id).GeneratedBy.Sequence("sqPedido").Not.Nullable().Unique();

            Map(x => x.Coo);
            Map(x => x.Caixa);
            Map(x => x.DataPedido).Not.Nullable();
            Map(x => x.Acressimos);
            Map(x => x.Descontos);
            Map(x => x.Frete);
            Map(x => x.ValorPedido);
            Map(x => x.Observacoes);
            Map(x => x.Status);

            References(x => x.NotaFiscal);
            References(x => x.CondicaoPagamento);
            References(x => x.Usuario).Not.Nullable();
            References(x => x.Cliente).Not.Nullable();
            References(x => x.Empresa).Not.Nullable().Column("empresa_id");
        }
    }
}