using FluentNHibernate.Mapping;

namespace Erp.Business.Entity.Contabil
{
    public class TransferenciaMap : ClassMap<Transferencia>
    {
        public TransferenciaMap()
        {
            Id(x => x.Id).Not.Nullable().Unique().GeneratedBy.Sequence("sqTransferencia");

            Map(x => x.Valor).Not.Nullable();
            Map(x => x.DataTransferencia).Not.Nullable();
            Map(x => x.Status);

            References(x => x.ContaDestino).Not.Nullable();
            References(x => x.ContaOrigem).Not.Nullable();
            

            HasMany(x => x.Lancamentos).Cascade.All();
        }
    }
}