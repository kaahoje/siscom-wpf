using FluentNHibernate.Mapping;

namespace Erp.Business.Entity.Contabil.Pessoa.SubClass.PessoaFisica.SubClass.ParceiroNegocio.ClassesRelacionadas
{
    public class CustoFixoParceiroNegocioPessoaFisicaMap : SubclassMap<CustoFixoParceiroNegocioPessoaFisica>
    {
        public CustoFixoParceiroNegocioPessoaFisicaMap()
        {
            References(x => x.ParceiroNegocioPessoaFisica).Fetch.Join().Not.Nullable();
        }
    }
}
