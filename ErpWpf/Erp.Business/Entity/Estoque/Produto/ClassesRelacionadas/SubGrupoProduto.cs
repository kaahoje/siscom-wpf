using System;
using System.ComponentModel.DataAnnotations;
using Erp.Business.Enum;

namespace Erp.Business.Entity.Estoque.Produto.ClassesRelacionadas
{
    [Serializable]
    public class SubGrupoProduto
    {
        public virtual int Id { get; set; }

        [Required(ErrorMessage = Constants.MessageRequiredError)]
        [StringLength(25, MinimumLength = 3, ErrorMessage = Constants.MessageLengthDescriptionError)]
        [Display(Name = "Descrição",Description = "Descrição do subgrupo",Order = 1)]
        public virtual string Descricao { get; set; }

        [Display(Name = "Imprime comanda", Description = "Imprime em comanda de restaurante", Order = 2)]
        public virtual bool ImprimeEmComandaRestaurante { get; set; }
        [Display(Name = "Impressora", Description = "Impressora", Order = 3)]
        public virtual string Impressora { get; set; }

        [Required(ErrorMessage = Constants.MessageRequiredError)]
        [Display(Name = "Descrição", Description = "Descrição do subgrupo", Order = 4)]
        public virtual GrupoProduto Grupo { get; set; }
        public virtual Status Status { get; set; }
    }
}