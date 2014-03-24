using FluentNHibernate.Mapping;

namespace Erp.Business.Entity.Contabil
{
    public class TipoTituloMap : ClassMap<TipoTitulo>
    {
        public TipoTituloMap()
        {
            Id(x => x.Id).Unique().GeneratedBy.Sequence("sqTipoLancamento").Not.Nullable();
            Map(x => x.Descricao).Not.Nullable().Column("descricao");


            References(x => x.ContaContraPartidaValor).Not.Nullable();
            References(x => x.ContaPartidaValor).Not.Nullable();
            Map(x => x.Status);
            References(x => x.ContaContraPartidaAcressimos).Not.Nullable();
            References(x => x.ContaContraPartidaDesconto).Not.Nullable();
            References(x => x.ContaContraPartidaJuros).Not.Nullable();

            References(x => x.ContaPartidaAcressimos).Not.Nullable();
            References(x => x.ContaPartidaDesconto).Not.Nullable();
            References(x => x.ContaPartidaJuros).Not.Nullable();
        }
    }
}