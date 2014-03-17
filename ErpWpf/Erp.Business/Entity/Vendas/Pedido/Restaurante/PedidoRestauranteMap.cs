using FluentNHibernate.Mapping;

namespace Erp.Business.Entity.Vendas.Pedido.Restaurante
{
    public class PedidoRestauranteMap : SubclassMap<PedidoRestaurante>
    {
        public PedidoRestauranteMap()
        {
            Map(x => x.Local).CustomType<int>();
            Map(x => x.Mesa);
            References(x => x.Controle);

            HasMany(x => x.Produtos).Cascade.All();
        }
    }
}