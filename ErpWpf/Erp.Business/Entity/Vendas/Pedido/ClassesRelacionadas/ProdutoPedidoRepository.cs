using Erp.Business.Entity.Estoque.Produto;

namespace Erp.Business.Entity.Vendas.Pedido.ClassesRelacionadas
{
    public class ProdutoPedidoRepository : RepositoryBase<ProdutoPedido>
    {
        public static ProdutoPedido CreateProdutoPedido(Produto produto, decimal quantidade)
        {
            var prodPedido = new ProdutoPedido();
            prodPedido.Quantidade = quantidade;
            return prodPedido;
        }

        public static ProdutoPedido CalculaProdutoPedido(ProdutoPedido prodPedido)
        {
            prodPedido.ValorUnitario = prodPedido.Produto.PrecoVenda;
            prodPedido.Valor = prodPedido.Produto.PrecoVenda*prodPedido.Quantidade;
            return prodPedido;
        }
    }
}