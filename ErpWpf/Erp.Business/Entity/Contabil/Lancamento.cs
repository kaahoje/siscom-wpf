using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using Erp.Business.Annotations;
using Erp.Business.Common.CustomAttributes;
using Erp.Business.Enum;

namespace Erp.Business.Entity.Contabil
{
    public class Lancamento
    {
        public Lancamento()
        {
            Partidas = new List<PartidasLancamento>();
        }

        public virtual int Id { get; set; }
        [Required(ErrorMessage = Constants.MessageRequiredError)]
        [Display(Description = "Vencimento", Name = "Vencimento do lançamento", Order = 0)]
        [GridAnnotation(Order = 0, Visible = true, Width = 150)]
        [Mask(Constants.MaskDate)]
        public virtual DateTime Vencimento { get; set; }
        [Required(ErrorMessage = Constants.MessageRequiredError)]
        [Display(Description = "Lançamento", Name = "Data de lançamento", Order = 1)]
        [GridAnnotation(Order = 1, Visible = true, Width = 150)]
        [Mask(Constants.MaskDate)]
        public virtual DateTime DataLancamento { get; set; }

        [Required(ErrorMessage = Constants.MessageRequiredError)]
        [Display(Description = "Valor", Name = "Valor do lançamento", Order = 2)]
        [GridAnnotation(Order = 2, Visible = true, Width = 150)]
        public virtual Decimal Valor { get; set; }
        
        [Display(Description = "Juros", Name = "Juros", Order = 3)]
        [GridAnnotation(Order = 3, Visible = true, Width = 150)]
        public virtual Decimal Juros { get; set; }
        [Display(Description = "Descontos", Name = "Descontos", Order = 4)]
        [GridAnnotation(Order = 4, Visible = true, Width = 150)]
        public virtual Decimal Desconto { get; set; }

        [Display(Description = "Documento", Name = "Texto gerado para identificar o lançamento para outros setores", Order = 5)]
        [GridAnnotation(Order = 5, Visible = true, Width = 150)]
        public virtual string Documento { get; set; }
        
        [Display(Description = "Histórico", Name = "Histórico do lançamento", Order = 6)]
        [GridAnnotation(Order = 6, Visible = true, Width = 150)]
        public virtual String Historico { get; set; }
        public virtual Status Status { get; set; }

        [Required(ErrorMessage = Constants.MessageRequiredError)]
        [Display(Description = "Tipo", Name = "Tipo de lançamento", Order = 7)]
        [GridAnnotation(Order = 7, Visible = true, Width = 200, FieldName = "Descricao")]
        public virtual TipoLancamento TipoLancmento { get; set; }

        [Required(ErrorMessage = Constants.MessageRequiredError)]
        [Display(Description = "Pessoa", Name = "Pessoa com que se relacionou a empresa originando o relacionamento", Order = 8)]
        [GridAnnotation(Order = 8, Visible = true, Width = 200, FieldName = "Id")]
        public virtual Pessoa.Pessoa Pessoa { get; set; }

        public virtual IList<PartidasLancamento> Partidas { get; set; }
    }
}