using System.Collections.Generic;
using System.Linq;
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
            decimal total = nf.Produtos.Sum(prod => prod.ValorUnitario*prod.Quantidade);

            total += nf.Frete + nf.OutrasDespesasAcessorias + nf.Seguro - nf.Desconto;
            return total;
        }

        public static IList<NotaFiscal> GetByRangeEntrada(string filter, int takePesquisa)
        {
            throw new System.NotImplementedException();
        }

        public static IList<NotaFiscal> GetByRangeSaida(string filter, int takePesquisa)
        {
            throw new System.NotImplementedException();
        }
    }
}