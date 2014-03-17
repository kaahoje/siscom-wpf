using System;
using Erp.Business.Entity.Vendas.Pedido.ClassesRelacionadas;

namespace Erp.Business.Entity.Fiscal.ClassesRelacionadas
{
    public class NotaFiscalPagamento
    {
        public virtual int Id { get; set; }
        public virtual int Sequencia { get; set; }
        public virtual FormaPagamento FormaPagamento { get; set; }
        public virtual DateTime Vencimento { get; set; }
        public virtual decimal Valor { get; set; }
        public virtual NotaFiscal NotaFiscal { get; set; }
    }
}