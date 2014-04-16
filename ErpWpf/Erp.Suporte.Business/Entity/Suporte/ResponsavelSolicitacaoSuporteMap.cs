using FluentNHibernate.Mapping;

namespace Erp.Suporte.Business.Entity.Suporte
{
    public class ResponsavelSolicitacaoSuporteMap : ClassMap<ResponsavelSolicitacaoSuporte>
    {
        public ResponsavelSolicitacaoSuporteMap()
        {
            Id(x => x.Id).Not.Nullable().Unique().GeneratedBy.Sequence("sqResponsavelSolicitacaoSuporte");
            Map(x => x.Documento);
            References(x => x.Solicitacao).Not.Nullable();

        }
    }
}
