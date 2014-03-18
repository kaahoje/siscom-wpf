using System;
using System.Linq;
using Erp.Business.Entity.Contabil.Pessoa.SubClass.PessoaJuridica;

namespace Erp.Business.Entity.Vendas.MovimentacaoCaixa.SubClass.LancamentoInicial
{
    public class LancamentoInicialRepository : RepositoryBase<LancamentoInicial>
    {
        public static LancamentoInicial DiaLancado(int caixa, DateTime dia, PessoaJuridica empresa)
        {
            return GetList().SingleOrDefault(l => l.Caixa == caixa && l.DataMovimento == dia && l.Empresa == empresa);
        }
    }
}