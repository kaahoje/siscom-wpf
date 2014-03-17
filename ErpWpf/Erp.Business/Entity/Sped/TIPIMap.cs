using FluentNHibernate.Mapping;

namespace Erp.Business.Entity.Sped
{
    public class TipiMap : ClassMap<Tipi>
    {
        public TipiMap()
        {
            Id(x => x.Id);
        }
    }
}