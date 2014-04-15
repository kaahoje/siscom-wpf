using FluentNHibernate.Mapping;

namespace Erp.Suporte.Business.Entity.Suporte
{
    public class SolicitacaoSuporteMap : ClassMap<SolicitacaoSuporte>
    {
        public SolicitacaoSuporteMap()
        {
            Id(x => x.Id).Not.Nullable().Unique().GeneratedBy.Sequence("sqSolicitacaoSuporte");
            Map(x => x.DataAcesso);
            Map(x => x.DataEntrada).Not.Nullable();
            Map(x => x.DataOcorrencia);
            Map(x => x.DataTerminoAtendimento);
            Map(x => x.Nota);
            Map(x => x.ProtocoloAtendimento).Not.Nullable();
            Map(x => x.RelatoProblema).Not.Nullable();

            References(x => x.EmpresaSolicitante).Not.Nullable();
            References(x => x.Solicitante).Not.Nullable();

            HasMany(x => x.Atendentes).LazyLoad().Cascade.All();

        }
    }
}
