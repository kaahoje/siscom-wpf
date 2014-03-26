using FluentNHibernate.Mapping;

namespace Erp.Business.Entity.Contabil
{
    public class LancamentoMap : ClassMap<Lancamento>
    {
        public LancamentoMap()
        {
            Id(x => x.Id).Not.Nullable().Unique().GeneratedBy.Sequence("sqLancamento");

            Map(x => x.DataLancamento).Not.Nullable();
            Map(x => x.Documento);
            Map(x => x.Valor).Not.Nullable();
            Map(x => x.Acrescimos).Not.Nullable();
            Map(x => x.Desconto).Not.Nullable();
            Map(x => x.Historico);
            Map(x => x.Status);
            References(x => x.Titulo).Not.Nullable();
            

            HasMany(x => x.Partidas);

            Table(NomesTabela.Lancamento);
        }
    }
}