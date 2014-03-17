using FluentNHibernate.Mapping;

namespace Erp.Business.Entity.Vendas.MovimentacaoCaixa
{
    public class MovimentacaoCaixaMap : ClassMap<MovimentacaoCaixa>
    {
        public MovimentacaoCaixaMap()
        {
            Id(x => x.Id).Not.Nullable().Unique().GeneratedBy.Sequence("sqMovimentacaoCaixa");
            Map(x => x.DataMovimento).Not.Nullable();
            Map(x => x.Historico).Not.Nullable().Length(100);
            Map(x => x.Valor).Not.Nullable();
            Map(x => x.Caixa);
            Map(x => x.Status);

            References(x => x.Usuario).Not.Nullable();
            References(x => x.Empresa).Not.Nullable();
        }
    }
}