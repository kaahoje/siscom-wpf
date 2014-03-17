using FluentNHibernate.Mapping;

namespace Erp.Business.Entity.Contabil.ClassesRelacoinadas
{
    public class MesGeradoMap : ClassMap<MesGerado>
    {
        public MesGeradoMap()
        {
            Id(x => x.Id).Not.Nullable().Unique().GeneratedBy.Sequence("sqCustoFixoMesGerado");

            Map(x => x.Ano);
            Map(x => x.Mes);
            Map(x => x.Status);

            HasMany(x => x.Titulos).KeyColumn("custo_fixo_mes_gerado_id");
        }
    }
}