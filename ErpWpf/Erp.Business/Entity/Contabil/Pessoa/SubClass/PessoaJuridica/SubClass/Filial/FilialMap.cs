using FluentNHibernate.Mapping;

namespace Erp.Business.Entity.Contabil.Pessoa.SubClass.PessoaJuridica.SubClass.Filial
{
    public class FiliaiMap : SubclassMap<Filial>
    {
        public FiliaiMap()
        {
            Map(x => x.EntidadePlanoContaReferencial).Not.Nullable().CustomType<int>();
            Map(x => x.Regime);
            Map(x => x.LogoEmpresa);

            References(x => x.Matriz).Cascade.All();
        }
    }
}