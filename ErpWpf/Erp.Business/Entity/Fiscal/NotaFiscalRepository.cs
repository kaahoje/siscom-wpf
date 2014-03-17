using Erp.Business.Entity.Fiscal.ClassesRelacionadas;

namespace Erp.Business.Entity.Fiscal
{
    public class NotaFiscalRepository : RepositoryBase<NotaFiscal>
    {
        public static decimal CalculaNota(NotaFiscal nf)
        {
            if (nf == null)
            {
                return 0;
            }
            decimal total = 0;

            foreach (ProdutoNotaFiscal prod in nf.Produtos)
            {
                total += prod.ValorUnitario*prod.Quantidade;
            }
            total += nf.Frete + nf.OutrasDespesasAcessorias + nf.Seguro - nf.Desconto;
            return total;
        }
    }
}