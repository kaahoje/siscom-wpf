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
            
            References(x => x.ContaContraPartidaAcressimos);
            References(x => x.ContaContraPartidaDesconto);
            

            References(x => x.ContaPartidaAcressimos);
            References(x => x.ContaPartidaDesconto);

            Map(x => x.Status);
            
        }
    }
}