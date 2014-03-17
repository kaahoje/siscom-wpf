using FluentNHibernate.Mapping;

namespace Erp.Business.Entity.Contabil.Pessoa.SubClass.PessoaJuridica.ClassesRelacionadas.RamoAtividade_Cnae
{
    public class CnaeSubClasseMap : ClassMap<CnaeSubClasse>
    {
        public CnaeSubClasseMap()
        {
            Id(x => x.Id).GeneratedBy.Native();

            Map(x => x.Codigo).Not.Nullable().Length(50);

            Map(x => x.Denominacao).Not.Nullable().Length(500);

            References(x => x.Classe).Column("cnae_classe_id").Not.Nullable();

            HasMany(x => x.Empresas).KeyColumn("cnae_subclasse_id");
        }
    }
}
