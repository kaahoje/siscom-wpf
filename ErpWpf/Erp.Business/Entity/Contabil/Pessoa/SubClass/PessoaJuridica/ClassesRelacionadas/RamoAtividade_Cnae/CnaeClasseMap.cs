using FluentNHibernate.Mapping;

namespace Erp.Business.Entity.Contabil.Pessoa.SubClass.PessoaJuridica.ClassesRelacionadas.RamoAtividade_Cnae
{
    public class CnaeClasseMap : ClassMap<CnaeClasse>
    {
        public CnaeClasseMap()
        {
            Id(x => x.Id).GeneratedBy.Native();

            Map(x => x.Codigo).Not.Nullable().Length(50);

            Map(x => x.Denominacao).Not.Nullable().Length(500);

            References(x => x.Grupo).Column("cnae_grupo_id").Not.Nullable();

            HasMany(x => x.SubClasses).KeyColumn("cnae_classe_id");
        }
    }
}
