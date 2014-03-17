using FluentNHibernate.Mapping;

namespace Erp.Business.Entity.Sped
{
    public class NcmMap : ClassMap<Ncm>
    {
        public NcmMap()
        {
            Id(x => x.Id).Not.Nullable().Unique().GeneratedBy.Sequence("sqNcm");

            Map(x => x.Codigo);
            Map(x => x.Descricao).Length(1000);
            Map(x => x.TributosNacionalIbpt);
            Map(x => x.TributosImportadoIbpt);
            Map(x => x.ExcessaoFiscal);
            Map(x => x.Tabela);


            
        }
    }
}