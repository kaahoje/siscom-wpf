using FluentNHibernate.Mapping;

namespace Erp.Business.Entity.Vendas.Pedido.ClassesRelacionadas
{
    public class PrazoPagamentoCondicaoPagamentoMap : ClassMap<PrazoPagamentoCondicaoPagamento>
    {
        public PrazoPagamentoCondicaoPagamentoMap()
        {
            Id(x => x.Id).GeneratedBy.Sequence("sqPrazoPagamento").Not.Nullable().Unique();

            Map(x => x.Prazo).Not.Nullable().Column("prazo");
            Map(x => x.Status);
        }
    }
}