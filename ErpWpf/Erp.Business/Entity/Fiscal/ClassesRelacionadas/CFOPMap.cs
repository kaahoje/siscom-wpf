using FluentNHibernate.Mapping;

namespace Erp.Business.Entity.Fiscal.ClassesRelacionadas
{
    public class CfopMap : ClassMap<Cfop>
    {
        public CfopMap()
        {
            Id(x => x.Id).Not.Nullable().GeneratedBy.Sequence("sqCfop");
            Map(x => x.CodigoCfop).Not.Nullable();
            Map(x => x.Aplicacao).Length(500);
        }
    }
}