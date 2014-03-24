using FluentNHibernate.Mapping;

namespace Erp.Business.Entity.Contabil.Pessoa.SubClass.PessoaJuridica.SubClass.ParceiroNegocio.ClassesRelacionadas
{
    public class LancamentoParceiroNegocioPessoaJuridicaMap : SubclassMap<LancamentoParceiroNegocioPessoaJuridica>
    {
        public LancamentoParceiroNegocioPessoaJuridicaMap()
        {
            References(x => x.ParceiroNegocioPessoaJuridica).Not.Nullable();
        }
    }
}
