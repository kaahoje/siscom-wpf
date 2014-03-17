using FluentNHibernate.Mapping;

namespace Erp.Business.Entity.Sped
{
    public class PlanoContaReferencialMap : ClassMap<PlanoContaReferencial>
    {
        public PlanoContaReferencialMap()
        {
            Id(x => x.Id).Not.Nullable().Unique().GeneratedBy.Sequence("sqPlanoContaReferencialSped");
            Map(x => x.Codigo).Not.Nullable().Unique();
            Map(x => x.Descricao).Not.Nullable();
            Map(x => x.Orientacoes);
            Map(x => x.Tipo).Column("tipo");
            Map(x => x.NaturezaConta).CustomType<int>();
        }
    }
}