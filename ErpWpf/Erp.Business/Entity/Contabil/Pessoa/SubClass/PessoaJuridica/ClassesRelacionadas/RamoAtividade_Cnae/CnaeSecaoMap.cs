using FluentNHibernate.Mapping;

namespace Erp.Business.Entity.Contabil.Pessoa.SubClass.PessoaJuridica.ClassesRelacionadas.RamoAtividade_Cnae
{
    public class CnaeSecaoMap : ClassMap<CnaeSecao>
    {
        public CnaeSecaoMap()
        {
            Id(x => x.Id).GeneratedBy.Native();

            Map(x => x.Codigo).Not.Nullable().Length(50);

            Map(x => x.Denominacao).Not.Nullable().Length(500);
            
            HasMany(x => x.Divisoes).KeyColumn("cnae_secao_id");
        }
    }
}
