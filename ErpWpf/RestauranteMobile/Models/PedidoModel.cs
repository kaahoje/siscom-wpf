using System.ComponentModel.DataAnnotations;
using System.Web.Mvc;
using Erp.Business.Entity.Estoque.Produto;
using Erp.Business.Entity.Vendas.Pedido.Restaurante;

namespace RestauranteMobile.Models
{
    public class PedidoModel :ModelBase<PedidoRestaurante>
    {
        public PedidoModel()
        {
            
        }
        [Display(Name = "Qtd.",Description = "Quantidade")]
        public decimal Quantidade { get; set; }

        public int IdProduto { get; set; }
        [Display(Name = "Produto", Description = "Descrição do produto")]
        public string Produto { get; set; }
    }
}