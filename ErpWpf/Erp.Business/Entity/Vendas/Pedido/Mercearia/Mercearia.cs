using System;
using System.Collections.Generic;
using Erp.Business.Entity.Vendas.Pedido.ClassesRelacionadas;

namespace Erp.Business.Entity.Vendas.Pedido.Mercearia
{
    public class Mercearia : Pedido
    {
        public Mercearia()
        {
            DataPedido = DateTime.Now;
            Produtos = new List<ProdutoPedido>();
        }

        public virtual IList<ProdutoPedido> Produtos { get; set; }

        public virtual decimal TotalPedido
        {
            get { return MerceariaRepository.CalcularPedido(this); }
        }

        public virtual decimal TotalProduto
        {
            get { return MerceariaRepository.CalculaTotalProduto(this); }
        }
    }
}