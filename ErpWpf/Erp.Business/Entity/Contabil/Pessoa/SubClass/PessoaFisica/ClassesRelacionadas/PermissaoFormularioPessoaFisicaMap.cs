using FluentNHibernate.Mapping;

namespace Erp.Business.Entity.Contabil.Pessoa.SubClass.PessoaFisica.ClassesRelacionadas
{
    public class PermissaoFormularioPessoaFisicaMap : ClassMap<PermissaoFormularioPessoaFisica>
    {
        public PermissaoFormularioPessoaFisicaMap()
        {
            Id(x => x.Id).Not.Nullable().Unique().GeneratedBy.Sequence("sqPermissaoFormularioPessoaFisica");

            Map(x => x.Formulario).CustomType<int>().Not.Nullable();
            Map(x => x.Pesquisa).Not.Nullable();
            Map(x => x.Insere).Not.Nullable();
            Map(x => x.Exclui).Not.Nullable();
            Map(x => x.Edita).Not.Nullable();
        }
    }
}
