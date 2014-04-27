using System;
using Erp.Business.Entity.Contabil.Pessoa;
using Erp.Business.Entity.Vendas.MovimentacaoCaixa.SubClass.PagamentoCliente.ClassesRelacionadas;
using Erp.Business.Entity.Vendas.Pedido.ClassesRelacionadas;

namespace Erp.Business.Entity.Vendas.MovimentacaoCaixa.SubClass.PagamentoCliente
{
    public class PagamentoCliente : MovimentacaoCaixa
    {
        

        public virtual Pessoa Cliente { get; set; }

        public virtual Decimal Descontos { get; set; }

        public virtual Decimal Acrescimos { get; set; }

        public virtual String Documento { get; set; }

        public virtual FormaPagamento FormaPagamento { get; set; }
    }
}