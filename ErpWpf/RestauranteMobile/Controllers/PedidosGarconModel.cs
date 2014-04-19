using System.Collections.Generic;
using System.Linq;
using Erp.Business.Entity.Contabil.Pessoa.SubClass.PessoaFisica.SubClass.ParceiroNegocio;
using Erp.Business.Entity.Vendas.Pedido.Restaurante;
using Erp.Business.Enum;
using RestauranteMobile.Models;

namespace RestauranteMobile.Controllers
{
    public class PedidosGarconModel : ModelBase<ParceiroNegocioPessoaFisica>
    {
        public IList<PedidoRestaurante> GetPedidosAbertos(int idGarcon)
        {
            return new global::RestauranteService.RestauranteService().GetPedidosGarcon(idGarcon);
        } 
    }
}