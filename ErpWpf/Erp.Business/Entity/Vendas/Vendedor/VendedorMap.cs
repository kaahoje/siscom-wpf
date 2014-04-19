using FluentNHibernate.Mapping;

namespace Erp.Business.Entity.Vendas.Vendedor
{
    public class VendedorMap // : ClassMap<Vendedor>
    {
        public VendedorMap()
        {
            //Id(x => x.Id).Not.Nullable().Unique().GeneratedBy.Sequence("sqVendedor");
            //Map(x => x.Escalado).Not.Nullable();
            //Map(x => x.Comissao).Not.Nullable();
            //Map(x => x.Status).Not.Nullable();
            //References(x => x.Funcionario).Not.Nullable();
        }
    }
}
