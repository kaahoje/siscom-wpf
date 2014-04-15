using FluentNHibernate.Mapping;

namespace Erp.Suporte.Business.Entity.Licenca.PessoaJuridica
{
    public class LicencaUsoPessoaJuridicaMap : SubclassMap<LicencaUsoPessoaJuridica>
    {
        public LicencaUsoPessoaJuridicaMap()
        {
            References(x => x.ParceiroNegocioPessoaJuridica).Not.Nullable();
        }
    }
}
