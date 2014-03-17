using FluentNHibernate.Mapping;

namespace Erp.Business.Entity.Contabil.Pessoa.SubClass.PessoaJuridica.SubClass.ParceiroNegocio
{
    public class ParceiroNegocioPessoaJuridicaMap : SubclassMap<ParceiroNegocioPessoaJuridica>
    {
        public ParceiroNegocioPessoaJuridicaMap()
        {
            Map(x => x.LimiteCredito);
        }
    }
}
