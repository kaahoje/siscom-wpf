using System;
using Erp.Business.Entity.Contabil;
using Erp.Business.Entity.Contabil.Pessoa;
using Erp.Business.Entity.Estoque.Produto.ClassesRelacionadas;
using Erp.Business.Entity.Vendas.Pedido.ClassesRelacionadas;
using Erp.Business.Enum;

namespace Erp.Business.Entity.Configuracao
{
    public class ConfiguracaoGeral
    {
        #region Configurações gerais.

        public virtual TipoAmbiente Ambiente { get; set; }

        #endregion

        public virtual int Id { get; set; }

        #region Financeiro
        public virtual TipoTitulo TipoTituloTransferencia { get; set; }
        #endregion

        #region Business

        #endregion

        #region Estoque

        public virtual Unidade UnidadeProdutoPadrao { get; set; }

        #endregion

        #region Configurações de venda

        /// <summary>
        ///     Pessoa padrão usada para efetuar as operações de venda.
        /// </summary>
        public virtual Pessoa PessoaPadrao { get; set; }


        /// <summary>
        ///     Data que está sendo processada as vendas do estabelecimento.
        /// </summary>
        public virtual DateTime DiaProcessamento { get; set; }

        /// <summary>
        ///     Define se a cobrança feita em produtos com composição será por
        ///     valor médio ou o valor do maior produto.
        /// </summary>
        public virtual bool CobrarComposicaoPorMaiorValor { get; set; }

        /// <summary>
        ///     Define qual será o máximo de produtos aceitos na composição de um
        ///     produto. O valor '0' indica que não será limitado.
        /// </summary>
        public virtual int LimitarComposicaoDeProdutoEm { get; set; }

        /// <summary>
        ///     Forma de pagamento padrão.
        /// </summary>
        public virtual FormaPagamento FormaPagamentoPadrao { get; set; }

        /// <summary>
        ///     Condição de pagamento padrão.
        /// </summary>
        public virtual CondicaoPagamento CondicaoPagamentoPadrao { get; set; }

        /// <summary>
        ///     Se esta opão estiver marcada como true o programa vai entender que só há composição
        ///     de produtos próprios e o que for mercadoria de terceiros não formarão composição.
        /// </summary>
        public virtual bool LimitarComposicaoParaProprios { get; set; }

        #endregion
    }
}