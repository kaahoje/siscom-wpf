using System.ComponentModel.DataAnnotations;
using Erp.Business.Enum;

namespace Erp.Business.Entity.Estoque.Produto.ClassesRelacionadas
{
    public class GrupoProduto
    {
        public virtual int Id { get; set; }

        [StringLength(25, MinimumLength = 5, ErrorMessage = Constants.MessageLengthDescriptionError)]
        [Required(ErrorMessage = Constants.MessageRequiredError)]
        [Display(Name = "Descrição",Description = "Descrição do grupo de produto",Order = 1)]
        public virtual string Descricao { get; set; }

        public virtual Status Status { get; set; }
    }
}