using FluentNHibernate.Mapping;

namespace Erp.Business.Entity.Contabil.Pessoa.SubClass.PessoaFisica.SubClass.ParceiroNegocio.ClassesRelacionadas
{
    public class LancamentoParceiroNegocioPessoaFisicaMap : SubclassMap<LancamentoParceiroNegocioPessoaFisica>
    {
        public LancamentoParceiroNegocioPessoaFisicaMap()
        {
            References(x => x.ParceiroNegocioPessoaFisica).Not.Nullable();
        }
    }
}
