using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web.Mvc;
using Erp.Business.Entity.Estoque.Produto;
using Erp.Business.Entity.Vendas.Pedido.Restaurante;

namespace RestauranteMobile.Models
{
    public class PedidoModel :ModelBase<PedidoRestaurante>
    {
        
        public PedidoModel()
        {
            Entity = new PedidoRestaurante();
        }
        public ProdutoPedidoModel ProdutoPedido { get; set; }
        [Display(Name = "V. produtos", Description = "Valor dos produtos")]
        public decimal ValorProduto
        {
            get
            {
                if (Entity == null)
                {
                    return 0;
                }
                if (Entity.Produtos == null)
                {
                    return 0;
                }
                return Entity.Produtos.Sum(x=> x.Valor);
            }
            
        }
    }
}