using System;
using Erp.Business.Entity.Contabil;
using Erp.Business.Entity.Vendas.Pedido.Restaurante;

namespace Erp.Business.Entity.Vendas.Pedido.ClassesRelacionadas
{
    public class PagamentoPedidoRepository : RepositoryBase<PagamentoPedido>
    {
        public static bool LancarPagamentoRestaurante(PedidoRestaurante pedido)
        {
            var s = NHibernateHttpModule.Session;

            var totalProdutos = PedidoRestauranteRepository.GetTotalProdutos(pedido);
            var totalMercadorias = PedidoRestauranteRepository.GetTotalMercadorias(pedido);
            var totalServicos = PedidoRestauranteRepository.GetTotalServicos(pedido);

            foreach (PagamentoPedido pag in pedido.Pagamento)
            {
                LancarProdutos(pedido.ValorPedido, totalProdutos, pag);
                LancarMercadorias(pedido.ValorPedido, totalMercadorias, pag);
                LancarServicos(pedido.ValorPedido, totalServicos, pag);
            }
            return true;
        }

        private static void LancarProdutos(decimal totalPedido, decimal totalProdutos, PagamentoPedido pag)
        {
            var percentualProdutos= Utils.GetPercentual(totalProdutos, pag.ValorTotal);
            var tituloProduto = TituloRepository.GerarTitulo(
                    true,
                    DateTime.Now.Date,
                    Utils.CalculaProporcao(totalProdutos,),
                    pag.Juros,
                    pag.Desconto,
                    pag.FormaPagamento.TipoTituloProduto);
        }
        private static void LancarMercadorias(decimal totalPedido, decimal totalMercadorias, PagamentoPedido pag)
        {
             var percentualMercadorias = Utils.GetPercentual(totalMercadorias, pag.ValorTotal);
            var tituloMercadoria=TituloRepository.GerarTitulo(
                    true,
                    DateTime.Now.Date,
                    Utils.GetValorDoPercentual(percentualMercadorias,totalMercadorias),
                    pag.)
                if (!pag.FormaPagamento.AVista)
                {
                    
                }
        }
        private static void LancarServicos(decimal totalPedido, decimal totalServicos, PagamentoPedido pag)
        {
            var percentualServicos = Utils.GetPercentual(totalServicos, pag.ValorTotal);
        }


    }
}