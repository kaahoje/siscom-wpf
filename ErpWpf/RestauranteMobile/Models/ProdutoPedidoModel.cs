using System;
using System.ComponentModel.DataAnnotations;

namespace RestauranteMobile.Models
{
    public class ProdutoPedidoModel
    {
        [Display(Name = "Qtd.", Description = "Quantidade")]
        public decimal Quantidade { get; set; }

        [Display(Name = "Produto",Description = "Produto")]
        public int IdProduto { get; set; }

        [Display(Name = "Composição", Description = "Composição do pedido que está em edição.")]
        public Guid ComposicaoEdit { get; set; }
        [Display(Name = "Composicao", Description = "Composicao do produto para alterações")]
        public Guid Composicao { get; set; }

        public Guid Produto { get; set; }
    }
}