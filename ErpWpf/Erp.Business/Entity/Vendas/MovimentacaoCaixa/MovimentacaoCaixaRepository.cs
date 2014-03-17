using System;
using Erp.Business.Entity.Contabil.Pessoa.SubClass.PessoaJuridica;
using Erp.Business.Entity.Vendas.MovimentacaoCaixa.SubClass.LancamentoInicial;
using Erp.Business.Entity.Vendas.MovimentacaoCaixa.SubClass.RecebimentoVenda;
using Erp.Business.Entity.Vendas.MovimentacaoCaixa.SubClass.Sangria;
using Erp.Business.Entity.Vendas.Pedido.ClassesRelacionadas;
using NHibernate;

namespace Erp.Business.Entity.Vendas.MovimentacaoCaixa
{
    public class MovimentacaoCaixaRepository : RepositoryBase<MovimentacaoCaixa>
    {
        public static bool LancarMovmentacaoPedido(ISession session, Pedido.Pedido pedido)
        {
            Session = session;
            foreach (PagamentoPedido pag in pedido.Pagamento)
            {
                // Pega o fator de multiplicação da parcela.
                decimal fator = pedido.ValorPedido/pag.Valor;
                // Cria o lançamento
                var lanc = new RecebimentoVenda
                {
                    
                    DataMovimento = pedido.DataPedido,
                    Caixa = pedido.Caixa,
                    Usuario = Utils.UsuarioAtual,
                    FormaPagamento = pag.FormaPagamento,
                    Historico = "Pagamento do pedido: " + pedido.Id
                                + " parcela: " + pag.Parcela,
                    Valor = pag.Valor
                };

                session.Save(lanc);
            }
            return true;
        }

        public static bool LancarSangria(Decimal valor, String historico,int caixa, DateTime dia, PessoaJuridica empresa)
        {
            var lanc = new Sangria
            {
                DataMovimento = dia,
                Caixa = caixa,
                Usuario = Utils.UsuarioAtual,
                Empresa = empresa,
                Historico = historico,
                Valor = valor
            };

            Session.Save(lanc);

            return true;
        }

        public static bool LancarInicial(Decimal valor,int caixa, DateTime dia , PessoaJuridica empresa)
        {
            var lanc = new LancamentoInicial
            {
                DataMovimento = dia,
                Empresa = empresa,
                Caixa = caixa,
                Usuario = Utils.UsuarioAtual,
                Historico = "LANCAMENTO INICIAL",
                Valor = valor
            };

            Session.Save(lanc);
            return true;
        }
    }
}