using FluentNHibernate.Mapping;

namespace Erp.Business.Entity.Sped
{
    public class CstIpiMap : ClassMap<CstIpi>
    {
        public CstIpiMap()
        {
            Id(x => x.Cst).Not.Nullable().Unique();
        }
    }
}