using FluentNHibernate.Mapping;

namespace Erp.Business.Entity.Contabil.Pessoa.SubClass.PessoaJuridica.ClassesRelacionadas.RamoAtividade_Cnae
{
    public class CnaeDivisaoMap : ClassMap<CnaeDivisao>
    {
        public CnaeDivisaoMap()
        {
            Id(x => x.Id).GeneratedBy.Native();

            Map(x => x.Codigo).Not.Nullable().Length(50);

            Map(x => x.Denominacao).Not.Nullable().Length(500);

            References(x => x.Secao).Column("cnae_secao_id").Not.Nullable();

            HasMany(x => x.Grupos).KeyColumn("cnae_divisao_id");
        }
    }
}
