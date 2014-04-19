using FluentNHibernate.Mapping;

namespace Erp.Business.Entity.Trabalhista
{
    public class FuncionarioMap // : ClassMap<Funcionario>
    {
        public FuncionarioMap()
        {
            //Id(x => x.Id).Not.Nullable().Unique().GeneratedBy.Sequence("sqFuncionario");

            //Map(x => x.CargaHoraria).Not.Nullable();
            //Map(x => x.Gratificacao).Not.Nullable();
            //Map(x => x.Salario).Not.Nullable();
            //Map(x => x.Status).Not.Nullable();

            //References(x => x.Cargo).Not.Nullable();
            //References(x => x.PessoaFisica).Not.Nullable();
        }
    }
}
