using FluentNHibernate.Mapping;

namespace Erp.Suporte.Business.Entity.Suporte.PessoaFisica
{
    public class SolicitacaoSuportePessoaFisicaMap : SubclassMap<SolicitacaoSuportePessoaFisica>
    {
        public SolicitacaoSuportePessoaFisicaMap()
        {
            References(x => x.Solicitante).Not.Nullable();
        }
    }
}
