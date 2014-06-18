using System;
using Erp.Business.Entity.Contabil;
using Erp.Business.Entity.Contabil.Pessoa;
using Erp.Business.Entity.Contabil.Pessoa.SubClass.PessoaJuridica;
using Erp.Business.Entity.Estoque.Produto.ClassesRelacionadas;
using Erp.Business.Entity.Vendas.Pedido.ClassesRelacionadas;
using Erp.Business.Enum;

namespace Erp.Business.Entity.Configuracao
{
    public class ConfiguracaoGeral
    {
        #region Configurações gerais.
        public virtual PessoaJuridica Proprietaria { get; set; }
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
        /// <summary>
        /// Limite usado para adentrar na composição do produto para efetuar a baixa do mesmo.
        /// </summary>
        public virtual int LimiteArvoreBaixaEstoque { get; set; }

        #endregion

        #region Configurações de venda

        /// <summary>
        ///     Pessoa padrão usada para efetuar as operações de venda.
        /// </summary>
        public virtual Pessoa PessoaPadrao { get; set; }
        /// <summary>
        /// Diz ao sistema se deverá avisar quando o produto não tiver quantidade disponível.
        /// </summary>
        public virtual bool AvisaProdutoSemQuantidade { get; set; }

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
        /// Número que indica a quantidade de mesas que contém o estabelecimento.
        /// </summary>
        public virtual int LimiteMesas { get; set; }
        /// <summary>
        ///     Se esta opão estiver marcada como true o programa vai entender que só há composição
        ///     de produtos próprios e o que for mercadoria de terceiros não formarão composição.
        /// </summary>
        public virtual bool LimitarComposicaoParaProprios { get; set; }
        /// <summary>
        /// O sistema deve trabalhar em modo de comissão. Sendo assim haverá separação em telas e poderá
        /// ser feita a apuração de comissões para garçons.
        /// </summary>
        public virtual bool SistemaComissao { get; set; }

        
        #endregion
    }
}