using FluentNHibernate.Mapping;

namespace Erp.Business.Entity.Sistema.Menu
{
    public class SistemaMenuMap : ClassMap<SistemaMenu>
    {
        public SistemaMenuMap()
        {
            Id(x => x.Id).GeneratedBy.Sequence("sqSistemaMenu").Not.Nullable().Unique();

            Map(x => x.Nome).Not.Nullable().Length(60).Unique();

            Map(x => x.Descricao).Not.Nullable().Length(60);

            Map(x => x.PathIcone).Nullable().Length(100);

            Map(x => x.Url).Nullable().Length(100);

            References(x => x.MenuMaster).Cascade.SaveUpdate().Column("menu_master_id");

            HasMany(x => x.SubMenus).Cascade.SaveUpdate().KeyColumn("menu_master_id");

            Table("SistemaMenu");
        }
    }
}
