using FluentNHibernate.Mapping;

namespace Erp.Business.Entity.Vendas.Pedido.ClassesRelacionadas
{
    public class ControlePedidoMap : ClassMap<ControlePedido>
    {
        public ControlePedidoMap()
        {
            Id(x => x.Id).GeneratedBy.Sequence("sqControlePedido").Not.Nullable().Unique();

            Map(x => x.Chave).Not.Nullable();
            Map(x => x.Controle).Not.Nullable();
        }
    }
}