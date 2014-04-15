using FluentNHibernate.Mapping;

namespace Erp.Suporte.Business.Entity.Licenca.PessoaFisica
{
    public class LicencaUsoPessoaFisicaMap : SubclassMap<LicencaUsoPessoaFisica>
    {
        public LicencaUsoPessoaFisicaMap()
        {
            References(x => x.ParceiroNegocioPessoaFisica).Not.Nullable();
        }
    }
}
