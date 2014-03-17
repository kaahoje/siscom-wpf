using System;
using System.ComponentModel.DataAnnotations;
using Erp.Business.Enum;

namespace Erp.Business.Entity.Vendas.Pedido.ClassesRelacionadas
{
    [Serializable]
    public class PagamentoPedido
    {
        public virtual int Id { get; set; }

        [Display(Name = "Pedido", Description = "Pedido que originou o pagamento.")]
        [Required(ErrorMessage = Constants.MessageRequiredError)]
        public virtual Pedido Pedido { get; set; }

        [Display(Name = "Parcela", Description = "Informação da parcela do pagamento do pedido.")]
        [Range(Constants.MinParcelas, Constants.MaxParcelas, ErrorMessage = Constants.MessageRangeError)]
        [Required(ErrorMessage = Constants.MessageRequiredError)]
        public virtual int Parcela { get; set; }

        [Display(Name = "Vencimento", Description = "Data em que vence o título desta parcela")]
        [Required(ErrorMessage = Constants.MessageRequiredError)]
        public virtual DateTime Vencimento { get; set; }

        [Display(Name = "Forma de pagamento", Description = "Forma de pagamento usada para quitar a parcela")]
        [Required(ErrorMessage = Constants.MessageRequiredError)]
        public virtual FormaPagamento FormaPagamento { get; set; }

        [Display(Name = "Valor", Description = "Valor da parcela")]
        [Range(Constants.MinValorMonetario, Constants.MaxValorMonetario,
            ErrorMessage = Constants.MessageRangeValorError)]
        [Required(ErrorMessage = Constants.MessageRequiredError)]
        public virtual Decimal Valor { get; set; }

        [Display(Name = "Juros", Description = "Juros cobrados na parcela")]
        [Range(Constants.MinValorMonetario, Constants.MaxValorMonetario,
            ErrorMessage = Constants.MessageRangeValorError)]
        [Required(ErrorMessage = Constants.MessageRequiredError)]
        public virtual decimal Juros { get; set; }

        [Display(Name = "Desconto", Description = "Desconto concedido na parcela")]
        [Range(Constants.MinValorMonetario, Constants.MaxValorMonetario,
            ErrorMessage = Constants.MessageRangeValorError)]
        [Required(ErrorMessage = Constants.MessageRequiredError)]
        public virtual decimal Desconto { get; set; }

        [Display(Name = "Total", Description = "Valor total da parcela")]
        [Range(Constants.MinValorMonetario, Constants.MaxValorMonetario,
            ErrorMessage = Constants.MessageRangeValorError)]
        [Required(ErrorMessage = Constants.MessageRequiredError)]
        public virtual decimal ValorTotal { get; set; }
        public virtual Status Status { get; set; }
    }
}