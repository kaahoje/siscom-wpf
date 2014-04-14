using FluentNHibernate.Mapping;

namespace Erp.Business.Entity.Contabil
{
    public class TituloMap : ClassMap<Titulo>
    {
        public TituloMap()
        {
            Id(x => x.Id).Not.Nullable().Unique().GeneratedBy.Sequence("sqTitulo");

            Map(x => x.DataLancamento).Not.Nullable();
            Map(x => x.DataVencimento).Not.Nullable();
            Map(x => x.Baixa);
            Map(x => x.NumeroOrdem);
            Map(x => x.Valor).Not.Nullable();
            Map(x => x.Acrescimos);
            Map(x => x.Desconto);
            Map(x => x.DescontoAte);
            Map(x => x.AReceber);
            Map(x => x.Historico);
            Map(x => x.Baixado);
            Map(x => x.Status);

            
            References(x => x.TipoTitulo).Not.Nullable();
            References(x => x.NotaFiscal);
            References(x => x.Lancamento).Column("lancamento_id");
        }
    }
}