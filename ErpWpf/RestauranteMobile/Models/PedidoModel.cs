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
        public ProdutoPedidoModel ProdutoPedido { get; set; }
    }
}