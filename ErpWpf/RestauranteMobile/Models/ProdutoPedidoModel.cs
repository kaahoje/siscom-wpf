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

        [Display(Name = "Composição", Description = "Composição do pedido")]
        public Guid Composicao { get; set; }
        
    }
}