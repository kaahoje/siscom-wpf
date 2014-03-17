using FluentNHibernate.Mapping;

namespace Erp.Business.Entity.Sped
{
    public class CstCofinsMap : ClassMap<CstCofins>
    {
        public CstCofinsMap()
        {
            Id(x => x.Id).Not.Nullable().Unique().GeneratedBy.Sequence("sqCstCofins");
            Map(x => x.Codigo).Not.Nullable();
            Map(x => x.Descricao).Not.Nullable();
        }
    }
}