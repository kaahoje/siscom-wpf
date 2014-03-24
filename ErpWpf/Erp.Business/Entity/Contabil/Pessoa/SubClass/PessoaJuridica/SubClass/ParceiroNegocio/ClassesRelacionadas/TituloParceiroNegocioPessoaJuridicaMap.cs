using FluentNHibernate.Mapping;

namespace Erp.Business.Entity.Contabil.Pessoa.SubClass.PessoaJuridica.SubClass.ParceiroNegocio.ClassesRelacionadas
{
    public class TituloParceiroNegocioPessoaJuridicaMap : SubclassMap<TituloParceiroNegocioPessoaJuridica>
    {
        public TituloParceiroNegocioPessoaJuridicaMap()
        {
            References(x => x.ParceiroNegocioPessoaJuridica).Not.Nullable();
        }
    }
}
