using FluentNHibernate.Mapping;

namespace Erp.Business.Entity.Contabil.Pessoa.SubClass.PessoaFisica.SubClass.ParceiroNegocio
{
    public class ParceiroNegocioPessoaFisicaMap : SubclassMap<ParceiroNegocioPessoaFisica>
    {
        public ParceiroNegocioPessoaFisicaMap()
        {
            Map(x => x.LimiteCredito);
        }
    }
}