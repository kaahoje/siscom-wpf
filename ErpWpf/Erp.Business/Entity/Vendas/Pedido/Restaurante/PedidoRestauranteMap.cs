using FluentNHibernate.Mapping;

namespace Erp.Business.Entity.Vendas.Pedido.Restaurante
{
    public class PedidoRestauranteMap : SubclassMap<PedidoRestaurante>
    {
        public PedidoRestauranteMap()
        {
            Map(x => x.Local).CustomType<int>();
            Map(x => x.Mesa);
            Map(x => x.HoraEntrada).Not.Nullable();
            Map(x => x.HoraEntrega);
            Map(x => x.HoraProducao);
            References(x => x.Controle);

            HasMany(x => x.Produtos).Cascade.All();
        }
    }
}