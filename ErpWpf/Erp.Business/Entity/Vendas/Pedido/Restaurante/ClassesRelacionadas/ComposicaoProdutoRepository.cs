using Erp.Business.Entity.Estoque.Produto;
using Erp.Business.Entity.Vendas.Pedido.ClassesRelacionadas;

namespace Erp.Business.Entity.Vendas.Pedido.Restaurante.ClassesRelacionadas
{
    public class ComposicaoProdutoRepository : RepositoryBase<ComposicaoProduto>
    {
        public static ComposicaoProduto CreateComposicaoProduto(Produto produto, decimal quantidade)
        {
            var comp = new ComposicaoProduto();
            comp.Produto = produto;
            comp.Quantidade = quantidade;
            ProdutoPedidoRepository.CalculaProdutoPedido(comp);
            comp.Composicao.Add(comp);
            return comp;
            
        }
    }
}