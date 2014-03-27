using FluentNHibernate.Mapping;

namespace Erp.Business.Entity.Contabil.Pessoa.SubClass.PessoaFisica.ClassesRelacionadas
{
    public class PermissaoRelatorioPessoaFisicaMap : ClassMap<PermissaoRelatorioPessoaFisica>
    {

        public PermissaoRelatorioPessoaFisicaMap()
        {
            Id(x => x.Id).Not.Nullable().Unique().GeneratedBy.Sequence("sqPermissaoRelatorioPessoaFisica");

            Map(x => x.Relatorio).CustomType<int>().Not.Nullable();
            Map(x => x.Permitido).Not.Nullable();
        }
    }
}
