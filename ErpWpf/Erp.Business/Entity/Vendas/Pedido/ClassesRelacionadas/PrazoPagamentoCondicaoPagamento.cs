using System;
using System.ComponentModel.DataAnnotations;
using Erp.Business.Enum;

namespace Erp.Business.Entity.Vendas.Pedido.ClassesRelacionadas
{
    [Serializable]
    public class PrazoPagamentoCondicaoPagamento
    {
        public virtual int Id { get; set; }

        public virtual Guid IdGuid { get; set; }

        [Display(Name = "Prazo", Description = "Prazo concedido para pagamento")]
        [Range(Constants.MinDia, Constants.MaxDia,
            ErrorMessage = Constants.MessageRangeValorError + " dias")]
        [Required(ErrorMessage = Constants.MessageRequiredError )]
        public virtual int Prazo { get; set; }
        public virtual Status Status { get; set; }
    }
}