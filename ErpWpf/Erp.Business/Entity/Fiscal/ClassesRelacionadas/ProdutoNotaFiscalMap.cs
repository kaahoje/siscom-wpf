using FluentNHibernate.Mapping;

namespace Erp.Business.Entity.Fiscal.ClassesRelacionadas
{
    public class ProdutoNotaFiscalMap : ClassMap<ProdutoNotaFiscal>
    {
        public ProdutoNotaFiscalMap()
        {
            Id(x => x.Id).GeneratedBy.Sequence("sqProdutoNotaFiscal").Not.Nullable().Unique();

            Map(x => x.Sequencia);
            Map(x => x.CodigoFornecedor);
            Map(x => x.Quantidade);
            Map(x => x.ValorUnitario);
            Map(x => x.BaseIcms);
            Map(x => x.ValorIcms);
            Map(x => x.ValorIpi);
            Map(x => x.TipoOperacaoNotaDaGente).CustomType<int>();
            Map(x => x.IndicadorTotalizacao).CustomType<int>();

            References(x => x.Produto);
            References(x => x.NCM);
            References(x => x.CST);
            References(x => x.CFOP);
            References(x => x.Unidade);
            References(x => x.NotaFiscal).Not.Nullable().Column("notafiscal_id");
        }
    }
}