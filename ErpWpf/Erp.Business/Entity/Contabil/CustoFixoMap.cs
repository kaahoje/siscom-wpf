using FluentNHibernate.Mapping;

namespace Erp.Business.Entity.Contabil
{
    public class CustoFixoMap : ClassMap<CustoFixo>
    {
        public CustoFixoMap()
        {
            Id(x => x.Id).Not.Nullable().Unique().GeneratedBy.Sequence("sqCustoFixo");

            Map(x => x.DiaVencimento);
            Map(x => x.Valor);
            Map(x => x.Observacoes);
            Map(x => x.Status);
            References(x => x.Pessoa).Not.Nullable();
            References(x => x.TipoLancamento).Not.Nullable();
        }
    }
}