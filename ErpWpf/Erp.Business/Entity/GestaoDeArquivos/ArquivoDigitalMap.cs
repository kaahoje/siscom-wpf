using FluentNHibernate.Mapping;

namespace Erp.Business.Entity.GestaoDeArquivos
{
    public class ArquivoDigitalMap : ClassMap<ArquivoDigital>
    {
        public ArquivoDigitalMap()
        {
            Id(x => x.Id).Unique().Not.Nullable().GeneratedBy.Native("sqArquivoDigital").Unique();

            Map(x => x.Historico);
            Map(x => x.Arquivo).Not.Nullable().Column("arquivo");
            Map(x => x.Md5).Index("idxArquivoDigitalMd5").Column("md5");
            Map(x => x.Status);
            References(x => x.Tipo).Not.Nullable().Column("tipo_id");

        }
    }
}