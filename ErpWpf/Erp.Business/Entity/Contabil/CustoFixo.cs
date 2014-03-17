using System.ComponentModel.DataAnnotations;
using Erp.Business.Annotations;
using Erp.Business.Enum;

namespace Erp.Business.Entity.Contabil
{
    public class CustoFixo
    {
        public virtual int Id { get; set; }
        [Required(ErrorMessage = Constants.MessageRequiredError)]
        [Display(Description = "Vencimento", Name = "Dia de vencimento", Order = 0)]
        [GridAnnotation(Order = 0, Visible = true, Width = 150)]
        public virtual int DiaVencimento { get; set; }
        public virtual Pessoa.Pessoa Pessoa { get; set; }
        [Required(ErrorMessage = Constants.MessageRequiredError)]
        [Display(Description = "Tipo de lançamento", Name = "Tipo de lançamento", Order = 1)]
        [GridAnnotation(Order = 1, Visible = true, Width = 250)]
        public virtual TipoLancamento TipoLancamento { get; set; }

        [Required(ErrorMessage = Constants.MessageRequiredError)]
        [Display(Description = "Valor", Name = "Valor", Order = 3)]
        [GridAnnotation(Order = 3, Visible = true, Width = 150)]
        public virtual decimal Valor { get; set; }
        [Required(ErrorMessage = Constants.MessageRequiredError)]
        [Display(Description = "Observações", Name = "Observações do custo", Order = 4)]
        [GridAnnotation(Order = 4, Visible = true, Width = 200)]
        public virtual string Observacoes { get; set; }

        public virtual Status Status { get; set; }
    }
}
