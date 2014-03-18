using FluentNHibernate.Mapping;

namespace Erp.Business.Entity.Vendas.Pedido.ClassesRelacionadas
{
    public class CondicaoPagamentoMap : ClassMap<CondicaoPagamento>
    {
        public CondicaoPagamentoMap()
        {
            Id(x => x.Id).GeneratedBy.Sequence("sqCondicaoPagamento").Not.Nullable().Unique();

            Map(x => x.Descricao).Not.Nullable().Length(100);
            Map(x => x.Status);

            HasMany(x => x.Prazos).Cascade.All();
        }
    }
}