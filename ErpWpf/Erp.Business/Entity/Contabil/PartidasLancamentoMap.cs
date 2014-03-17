using FluentNHibernate.Mapping;

namespace Erp.Business.Entity.Contabil
{
    public class PartidasLancamentoMap : ClassMap<PartidasLancamento>
    {
        public PartidasLancamentoMap()
        {
            Id(x => x.Id).Not.Nullable().GeneratedBy.Native("sqPartidasLancamento").Unique();

            Map(x => x.Valor).Not.Nullable();

            Map(x => x.Status);

            References(x => x.PlanoConta).Not.Nullable();
        }
    }
}