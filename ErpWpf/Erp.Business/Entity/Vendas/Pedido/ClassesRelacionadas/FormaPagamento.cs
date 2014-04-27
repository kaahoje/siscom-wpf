using System;
using System.ComponentModel.DataAnnotations;
using Erp.Business.Entity.Contabil;
using Erp.Business.Enum;

namespace Erp.Business.Entity.Vendas.Pedido.ClassesRelacionadas
{
    /// <summary>
    ///     Classe que define uma forma de pagamento usada pelo estabelecimento.
    /// </summary>
    [Serializable]
    public class FormaPagamento
    {
        public virtual int Id { get; set; }
        [Display(Name = "Descrição", Description = "Descrição da forma de pagamento",Order = 1)]
        [Required(ErrorMessage = Constants.MessageRequiredError)]
        [StringLength(Constants.MaxLengthDescriptions,MinimumLength = 4,
            ErrorMessage = Constants.MessageLengthDescriptionError)]
        public virtual string Descricao { get; set; }

        public virtual Status Status { get; set; }
        /// <summary>
        ///     Taxa de juros cobrada do cliente nessa forma de pagamento.
        /// </summary>
        [Display(Name = "Taxa", Description = "Taxa de juros cobrada do cliente ao utilizar esta forma de pagamento",Order=2)]
        public virtual decimal TaxaJurosCliente { get; set; }

        [Display(Name = "À vista", Description = "Indica se a forma de pagamento é à vista",Order = 3)]
        public virtual bool AVista { get; set; }

        [Display(Name = "Taxa de administração", Description = "Taxa de cobrada por administradoras de títulos",Order = 4)]
        public virtual decimal TaxaAdministracao { get; set; }

        [Display(Name = "Prazo de compensação", Description = "Praço para compensação geralmente usado por operadoras de catão de crédito.",Order = 5)]
        public virtual int PrazoCompensacao { get; set; }

        [Display(Name = "Exige identificação", Description = "Define se a forma de pagamento exige a identificação do cliente",Order = 6)]
        public virtual bool ExigeIdentificacaoCliente { get; set; }

        [Display(Name = "Movimenta limite", Description = "Define se a forma de pagamento movimenta o limiete do cliente",Order = 7)]
        public virtual bool MovimentaLimiteCliente { get; set; }

        /// <summary>
        ///     Diz se a forma de pagamento pode ser utilizada como forma de pagamento pelos clientes da empresa.
        /// </summary>
        [Display(Name = "Pode receber", Description = "Se esta opção estiver marcada o cliente poderá pagar com esta forma de pagamento",Order = 8)]
        public virtual bool PodeReceber { get; set; }

        public virtual TipoTitulo TipoTituloProduto { get; set; }

        public virtual TipoTitulo TipoTituloMercadoria { get; set; }

        /// <summary>
        /// <br>Tipo de título para lançamento de serviços.</br>
        /// </summary>
        public virtual TipoTitulo TipoTituloServico { get; set; }

        public virtual TipoTitulo TipoTituloAPrazo { get; set; }
        /// <summary>
        /// Tipo de título usado para o recebimento de valores de clientes.
        /// </summary>
        public virtual TipoTitulo TipoTituloRecebimentoCliente { get; set; }
    }
}