using Erp.Business.Entity.Vendas.Pedido.ClassesRelacionadas;

namespace Erp.Business.Entity.Vendas.MovimentacaoCaixa.SubClass.RecebimentoVenda
{
    public class RecebimentoVenda : MovimentacaoCaixa
    {
        public virtual FormaPagamento FormaPagamento { get; set; }
        
    }
}