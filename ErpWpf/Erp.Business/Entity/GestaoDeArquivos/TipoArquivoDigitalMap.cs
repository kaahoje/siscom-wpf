using FluentNHibernate.Mapping;

namespace Erp.Business.Entity.GestaoDeArquivos
{
    public class TipoArquivoDigitalMap : ClassMap<TipoArquivoDigital>
    {
        public TipoArquivoDigitalMap()
        {
            Id(x => x.Id).GeneratedBy.Sequence("sqTipoArquivoDigital").Not.Nullable().Unique();

            Map(x => x.Descricao).Not.Nullable();
            Map(x => x.Status);
        }
    }
}