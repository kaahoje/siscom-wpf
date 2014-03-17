using FluentNHibernate.Mapping;

namespace Erp.Business.Entity.Vendas.Pedido.Mercearia
{
    public class MerceariaMap : SubclassMap<Mercearia>
    {
        public MerceariaMap()
        {
            HasMany(x => x.Produtos).Cascade.All();
        }
    }
}