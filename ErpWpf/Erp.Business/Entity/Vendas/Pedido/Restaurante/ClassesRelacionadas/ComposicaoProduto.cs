using System;
using System.Collections.Generic;
using Erp.Business.Entity.Vendas.Pedido.ClassesRelacionadas;

namespace Erp.Business.Entity.Vendas.Pedido.Restaurante.ClassesRelacionadas
{
    [Serializable]
    public class ComposicaoProduto : ProdutoPedido
    {
        public ComposicaoProduto()
        {
            Composicao = new List<ProdutoPedido>();
        }

        public virtual IList<ProdutoPedido> Composicao { get; set; }
    }
}