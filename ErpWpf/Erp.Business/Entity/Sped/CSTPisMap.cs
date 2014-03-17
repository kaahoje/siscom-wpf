using FluentNHibernate.Mapping;

namespace Erp.Business.Entity.Sped
{
    public class CstPisMap : ClassMap<CstPis>
    {
        public CstPisMap()
        {
            Id(x => x.Id).Not.Nullable().Unique().GeneratedBy.Sequence("sqCstPis");
            Map(x => x.Descricao);
            Map(x => x.Cst);
        }
    }
}