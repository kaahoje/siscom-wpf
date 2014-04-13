using FluentNHibernate.Mapping;

namespace Erp.Business.Entity.Contabil.Pessoa.SubClass.PessoaJuridica.SubClass.ParceiroNegocio.ClassesRelacionadas
{
    public class CustoFixoParceiroNegocioPessoaJuridicaMap : SubclassMap<CustoFixoParceiroNegocioPessoaJuridica>
    {
        public CustoFixoParceiroNegocioPessoaJuridicaMap()
        {
            References(x => x.ParceiroNegocioPessoaJuridica).Not.Nullable();
        }
    }
}
