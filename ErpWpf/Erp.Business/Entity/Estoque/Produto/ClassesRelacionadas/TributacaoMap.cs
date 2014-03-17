using FluentNHibernate.Mapping;

namespace Erp.Business.Entity.Estoque.Produto.ClassesRelacionadas
{
    public class TributacaoNcmMap : ClassMap<Tributacao>
    {
        public TributacaoNcmMap()
        {
            Id(x => x.Id).GeneratedBy.Sequence("sqTributacaoNcm").Not.Nullable().Unique();


            Map(x => x.PisPercentCompra);
            Map(x => x.CofinsPercentCompra);
            Map(x => x.IpiPrecentCompra);
            Map(x => x.OperacaoNotaDaGente).CustomType<int>();
            Map(x => x.Regime).CustomType<int>();
            Map(x => x.QtdUnidadeTributavel);

            Map(x => x.IcmsDevedor).Column("icmsdevedor");
            Map(x => x.IssDevedor).Column("issdevedor");
            Map(x => x.TipoTributacaoIcms).CustomType<int>().Column("tipotributacaoicms");
            Map(x => x.TipoTributacaoIss).CustomType<int>().Column("tipotributacaoiss");

            References(x => x.SitTribPisCompra);
            References(x => x.SitTribCofinsCompra);
            References(x => x.SitTribIpiCompra);
            References(x => x.CodigoCst);
            References(x => x.ExtTipi);
            References(x => x.UnidadeTributavel);
        }
    }
}