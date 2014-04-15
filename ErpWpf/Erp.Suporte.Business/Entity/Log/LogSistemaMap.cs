using FluentNHibernate.Mapping;

namespace Erp.Suporte.Business.Entity.Log
{
    public class LogSistemaMap : ClassMap<LogSistema>
    {
        public LogSistemaMap()
        {
            Id(x => x.Id).Not.Nullable().Unique().GeneratedBy.Sequence("sqLogSistema");
            Map(x => x.DataComunicacaoCliente);
            Map(x => x.DataCorrecao);
            Map(x => x.DataEntrada).Not.Nullable();
            Map(x => x.DataVisualizacao);
            Map(x => x.StackTrace);
        }
    }
}
