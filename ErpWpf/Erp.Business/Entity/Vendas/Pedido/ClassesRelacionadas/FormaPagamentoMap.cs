using FluentNHibernate.Mapping;

namespace Erp.Business.Entity.Vendas.Pedido.ClassesRelacionadas
{
    public class FormaPagamentoMap : ClassMap<FormaPagamento>
    {
        public FormaPagamentoMap()
        {
            Id(x => x.Id).Not.Nullable().GeneratedBy.Sequence("sqFormaPagamento").Unique();

            Map(x => x.Descricao).Not.Nullable().Length(100);
            Map(x => x.AVista).Not.Nullable();
            Map(x => x.TaxaJurosCliente);
            Map(x => x.TaxaAdministracao).Default("0.0");
            Map(x => x.PrazoCompensacao).Default("0");
            Map(x => x.ExigeIdentificacaoCliente);
            Map(x => x.PodeReceber);
            Map(x => x.MovimentaLimiteCliente);

            Map(x => x.Status);

            References(x => x.TipoTituloMercadoria);
            References(x => x.TipoTituloProduto);
            References(x => x.TipoTituloServico);
            References(x => x.TipoTituloAPrazo);
            References(x => x.TipoTituloRecebimentoCliente);
        }
    }
}