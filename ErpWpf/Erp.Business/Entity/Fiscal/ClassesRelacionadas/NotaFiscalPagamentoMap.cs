using FluentNHibernate.Mapping;

namespace Erp.Business.Entity.Fiscal.ClassesRelacionadas
{
    public class NotaFiscalPagamentoMap : ClassMap<NotaFiscalPagamento>
    {
        public NotaFiscalPagamentoMap()
        {
            Id(x => x.Id).Not.Nullable().Unique().GeneratedBy.Sequence("sqNotaFiscalPagamento");

            Map(x => x.Sequencia).Not.Nullable();
            Map(x => x.Valor).Not.Nullable();
            Map(x => x.Vencimento).Not.Nullable();

            References(x => x.FormaPagamento).Not.Nullable();
            References(x => x.NotaFiscal).Not.Nullable();
        }
    }
}