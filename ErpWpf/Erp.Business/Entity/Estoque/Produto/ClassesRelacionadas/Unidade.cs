using System;
using System.ComponentModel.DataAnnotations;
using System.Security.Cryptography;
using Erp.Business.Enum;

namespace Erp.Business.Entity.Estoque.Produto.ClassesRelacionadas
{
    [Serializable]
    public class Unidade
    {
        public virtual int Id { get; set; }
        [Display(Name = "Sigla", Description = "Sigla da unidade no S.I. ou padrão da empresa.")]
        [Required(ErrorMessage = Constants.MessageRequiredError)]
        public virtual string Sigla { get; set; }
        [Display(Name = "Descrição",Description = "Descrição da unidade")]
        [Required(ErrorMessage = Constants.MessageRequiredError)]
        [StringLength(Constants.MaxLengthNames,MinimumLength = Constants.MinLengthNames, ErrorMessage = Constants.MessageLengthNameError)]
        public virtual string Descricao { get; set; }
        [Display(Name = "Quantidade",Description = "Quantidade movimentada por uma unidade.")]
        [Required(ErrorMessage = Constants.MessageRequiredError)]
        [Range(Constants.MinQuantidade,Constants.MaxQuantidade,ErrorMessage = Constants.MessageRangeError)]
        public virtual decimal Quantidade { get; set; }
        public virtual Status Status { get; set; }
    }
}