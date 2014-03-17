using FluentNHibernate.Mapping;

namespace Erp.Business.Entity.Fiscal.ClassesRelacionadas
{
    public class NaturezaInternaMap : ClassMap<NaturezaInterna>
    {
        public NaturezaInternaMap()
        {
            Id(x => x.Id).GeneratedBy.Sequence("sqNaturezaInterna").Not.Not.Unique();

            Map(x => x.Descricao).Not.Nullable();
            References(x => x.Cfop).LazyLoad();
        }
    }
}