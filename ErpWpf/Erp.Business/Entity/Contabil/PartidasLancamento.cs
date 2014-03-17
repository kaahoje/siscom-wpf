using System;
using System.ComponentModel.DataAnnotations;
using Erp.Business.Annotations;
using Erp.Business.Entity.Sped;
using Erp.Business.Enum;

namespace Erp.Business.Entity.Contabil
{
    public class PartidasLancamento
    {
        public virtual int Id { get; set; }
        [Required(ErrorMessage = Constants.MessageRequiredError)]
        [Display(Description = "Pessoa", Name = "Pessoa com que se relacionou a empresa originando o relacionamento", Order = 8)]
        [Range(Constants.MinValorMonetario,Constants.MaxValorMonetario,ErrorMessage = Constants.MessageRangeValorError)]
        [GridAnnotation(Order = 8, Visible = true, Width = 200, FieldName = "Id")]
        public virtual Decimal Valor { get; set; }

        public virtual PlanoContaReferencial PlanoConta { get; set; }

        public virtual Status Status { get; set; }
    }
}