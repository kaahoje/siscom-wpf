using FluentNHibernate.Mapping;

namespace Erp.Business.Entity.Sped
{
    public class CstMap : ClassMap<Cst>
    {
        public CstMap()
        {
            Id(x => x.Codigo).Not.Nullable().Unique();

            Map(x => x.Descricao).Not.Nullable();
            Map(x => x.AliquotaIcms);
            Map(x => x.Origem);
            Map(x => x.TributacaoIcms);
            Map(x => x.ValorBaseIcms);
            Map(x => x.ValorBaseIcmsST);
            Map(x => x.ValorIcms);
            Map(x => x.ValorIcmsST);
            Map(x => x.ValorReduzidoBase);
        }
    }
}