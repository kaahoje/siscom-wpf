using FluentNHibernate.Mapping;

namespace Erp.Business.Entity.Contabil.Pessoa.SubClass.PessoaFisica.SubClass.ParceiroNegocio.ClassesRelacionadas
{
    public class TituloParceiroNegocioPessoaFisicaMap : SubclassMap<TituloParceiroNegocioPessoaFisica>
    {
        public TituloParceiroNegocioPessoaFisicaMap()
        {
            References(x => x.ParceiroNegocioPessoaFisica).Not.Nullable();
        }
    }
}
