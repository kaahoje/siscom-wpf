using FluentNHibernate.Mapping;

namespace Erp.Business.Entity.Contabil.Pessoa.SubClass.PessoaJuridica.ClassesRelacionadas.RamoAtividade_Cnae
{
    /// <summary>
    /// Classe que mapeia um endereço para o banco de dados.
    /// </summary>
    public class CnaeGrupoMap : ClassMap<CnaeGrupo>
    {
        public CnaeGrupoMap()
        {

            Id(x => x.Id).GeneratedBy.Native();

            Map(x => x.Codigo).Not.Nullable().Length(50);

            Map(x => x.Denominacao).Not.Nullable().Length(500);

            References(x => x.Divisao).Column("cnae_divisao_id").Not.Nullable();

            HasMany(x => x.Classes).KeyColumn("cnae_grupo_id");
        }
    }
}
