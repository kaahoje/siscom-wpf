using FluentNHibernate.Mapping;

namespace Erp.Suporte.Business.Entity.Licenca
{
    public class LicencaUsoMap : ClassMap<LicencaUso>
    {
        public LicencaUsoMap()
        {
            Id(x => x.Id).Not.Nullable().Unique().GeneratedBy.Sequence("sqLicencaUso");

            Map(x => x.DataConcessao).Not.Nullable();
            Map(x => x.DataRevogacao);
            Map(x => x.CodigoLicenca).Not.Nullable();
            Map(x => x.Status);
        }
    }
}
