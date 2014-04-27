using FluentNHibernate.Mapping;

namespace Erp.Business.Entity.Configuracao
{
    public class ConfiguracaoGeralMap : ClassMap<ConfiguracaoGeral>
    {
        public ConfiguracaoGeralMap()
        {
            Id(x => x.Id).Not.Nullable().Unique().GeneratedBy.Sequence("sqConfiguracao");


            Map(x => x.DiaProcessamento);
            Map(x => x.LimitarComposicaoDeProdutoEm);
            Map(x => x.LimitarComposicaoParaProprios);
            Map(x => x.CobrarComposicaoPorMaiorValor).Column("cobrarcomposicaopormaiorvalor");
            Map(x => x.Ambiente).CustomType<int>().Not.Nullable();
            //Map(x => x.SistemaComissao).Not.Nullable();
            Map(x => x.LimiteMesas).Not.Nullable();


            References(x => x.PessoaPadrao).LazyLoad();
            References(x => x.FormaPagamentoPadrao).LazyLoad();
            References(x => x.CondicaoPagamentoPadrao).LazyLoad();
            References(x => x.UnidadeProdutoPadrao).LazyLoad();
            References(x => x.TipoTituloTransferencia).LazyLoad();
        }
    }
}