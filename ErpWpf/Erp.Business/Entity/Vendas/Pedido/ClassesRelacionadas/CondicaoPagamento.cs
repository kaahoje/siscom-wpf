using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using Erp.Business.Enum;

namespace Erp.Business.Entity.Vendas.Pedido.ClassesRelacionadas
{
    [Serializable]
    public class CondicaoPagamento
    {
        public CondicaoPagamento()
        {
            Prazos = new List<PrazoPagamentoCondicaoPagamento>();
        }

        public virtual int Id { get; set; }
        
        [Display(Name = "Descrição", Description = "Descrição da condição de pagamento",Order = 1)]
        [Required(ErrorMessage = Constants.MessageRequiredError)]
        [StringLength(Constants.MaxLengthDescriptions, MinimumLength = Constants.MinLengthDescriptions,
            ErrorMessage = Constants.MessageLengthDescriptionError)]
        public virtual string Descricao { get; set; }

        public virtual IList<PrazoPagamentoCondicaoPagamento> Prazos { get; set; }
        public virtual Status Status { get; set; }
    }
}