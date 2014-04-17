using System;
using System.ComponentModel.DataAnnotations;
using Erp.Business.Entity.Estoque.Produto;
using Erp.Business.Enum;

namespace Erp.Business.Entity.Vendas.Pedido.ClassesRelacionadas
{
    [Serializable]
    public class ProdutoPedido
    {
        public ProdutoPedido()
        {
            IdGuid = Guid.NewGuid();
        }
        public virtual int Id { get; set; }

        public virtual Guid IdGuid { get; set; }

        [Display(Name = "Sq", Description = "Sequencia do produto")]
        [Required(ErrorMessage = Constants.MessageRequiredError)]
        public virtual int Sequencia { get; set; }

        [Display(Name = "Produto", Description = "Produto a ser vendido")]
        [Required(ErrorMessage = Constants.MessageRequiredError)]
        public virtual Produto Produto { get; set; }

        [Display(Name = "Quantidade", Description = "Quantidade vendida")]
        [Range(Constants.MinQuantidade, Constants.MaxQuantidade,
            ErrorMessage = Constants.MessageRangeValorError)]
        [Required(ErrorMessage = Constants.MessageRequiredError)]
        public virtual decimal Quantidade { get; set; }

        [Display(Name = "Valor", Description = "Valor do produto")]
        [Range(Constants.MinValorMonetario, Constants.MaxValorMonetario,
            ErrorMessage = Constants.MessageRangeValorError)]
        [Required(ErrorMessage = Constants.MessageRequiredError)]
        public virtual decimal Valor { get; set; }

        [Display(Name = "Valor unitário", Description = "Valor unitário do produto")]
        [Range(Constants.MinValorMonetario, Constants.MaxValorMonetario,
            ErrorMessage = Constants.MessageRangeValorError)]
        [Required(ErrorMessage = Constants.MessageRequiredError)]
        public virtual decimal ValorUnitario { get; set; }

        [Display(Name = "Diferênça", Description = "Diferênça calculada do produto")]
        [Range(Constants.MinValorMonetario, Constants.MaxValorMonetario,
            ErrorMessage = Constants.MessageRangeValorError)]
        [Required(ErrorMessage = Constants.MessageRequiredError)]
        public virtual decimal Diferenca { get; set; }
        public virtual Status Status { get; set; }
    }
}