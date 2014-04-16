using FluentNHibernate.Mapping;

namespace Erp.Suporte.Business.Entity.Suporte.PessoaJuridica
{
    public class SolicitacaoSuportePessoaJuridicaMap : SubclassMap<SolicitacaoSuportePessoaJuridica>
    {
        public SolicitacaoSuportePessoaJuridicaMap()
        {
            References(x => x.Solicitante).Not.Nullable();
        }
    }
}
