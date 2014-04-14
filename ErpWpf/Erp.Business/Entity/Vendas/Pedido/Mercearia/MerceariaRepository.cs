using System;
using System.Linq;
using Erp.Business.Entity.Contabil.Pessoa.SubClass.PessoaFisica.SubClass.ParceiroNegocio;
using Erp.Business.Entity.Estoque.Produto;
using Erp.Business.Entity.Estoque.Produto.ClassesRelacionadas;
using Erp.Business.Entity.Vendas.MovimentacaoCaixa.SubClass.RecebimentoVenda;
using Erp.Business.Entity.Vendas.Pedido.ClassesRelacionadas;
using Erp.Business.Enum;
using NHibernate;

namespace Erp.Business.Entity.Vendas.Pedido.Mercearia
{
    public class MerceariaRepository : RepositoryBase<Mercearia>
    {
        public new static Mercearia Save(Mercearia pedido)
        {
            ISession session = SessionFactory.OpenSession();
            ITransaction transaction = session.BeginTransaction();
            try
            {
                //pedido.Usuario = Utils.UsuarioAtual;
                decimal saldoADebitar =
                    pedido.Pagamento.Where(pag => pag.FormaPagamento.AVista).Sum(pag => pag.ValorTotal);
                if (saldoADebitar > 0)
                {
                    if (!ParceiroNegocioPessoaFisicaRepository.IsLimiteDisponivel(pedido.Cliente.Id, saldoADebitar))
                    {
                        throw new Exception("O cliente não possui limite disponível.");
                    }
                }
                session.Save(pedido);
                RepositoryBase<RecebimentoVenda>.Session = session;
                foreach (PagamentoPedido pag in pedido.Pagamento)
                {
                    RepositoryBase<RecebimentoVenda>.Save(
                        RecebimentoVendaRepository.CreateRecebimentoVendaByPedido(pag, pedido));
                }

                EfetuarLancamentoMercearia(session, pedido);
                BaixaEstoque(session, pedido);
                transaction.Commit();
            }
            catch (Exception ex)
            {
                transaction.Rollback();
                throw ex;
            }

            return pedido;
        }

        public static Boolean EfetuarLancamentoMercearia(ISession session, Mercearia pedido)
        {
            Session = session;

            foreach (PagamentoPedido pag in pedido.Pagamento)
            {
                decimal fator = pag.ValorTotal / pedido.ValorPedido;
                //Lancamento lanc = PedidoRepository.CriaLancamento(pedido, PedidoRepository.CriaHistorico(pedido));
                //lanc.Valor = fator * pag.Valor;
                //lanc.Desconto = pag.Desconto;
                //lanc.Juros = pag.Juros;
                //foreach (ProdutoPedido prod in pedido.Produtos)
                //{
                //    PedidoRepository.DeterminarPartida(lanc, prod.Produto, pag.FormaPagamento);
                //}
                //if (!pag.FormaPagamento.AVista)
                //{
                //    PedidoRepository.LancaTitulo(pag);
                //}
                //Session.Save(lanc);
            }

            return true;
        }

        private static void BaixaEstoque(ISession session, Mercearia pedido)
        {
            foreach (ProdutoPedido prods in pedido.Produtos)
            {
                if (prods.Produto.Ippt == Ippt.Propria)
                {
                    if (prods.Produto.Receitas.Count > 0)
                    {
                        foreach (Receita itemReceita in prods.Produto.Receitas)
                        {
                            decimal qtd = itemReceita.Quantidade * (prods.Quantidade *
                                                                  prods.Produto.UnidadeVenda.Quantidade);
                            ProdutoRepository.BaixarQuantidadeProduto(session, itemReceita.MateriaPrima, qtd);
                        }
                    }
                    else
                    {
                        ProdutoRepository.BaixarQuantidadeProduto(session, prods.Produto, prods.Quantidade);
                    }
                }
                else
                {
                    ProdutoRepository.BaixarQuantidadeProduto(session, prods.Produto, prods.Quantidade);
                }
            }
        }

        public static decimal CalcularPedido(Mercearia mercearia)
        {
            decimal totalProd = mercearia.Produtos.Sum(prod => prod.Valor);
            return totalProd - mercearia.Descontos + mercearia.Acressimos + mercearia.Frete;
        }

        public static decimal CalculaTotalProduto(Mercearia mercearia)
        {
            return mercearia.Produtos.Sum(pedido => pedido.Valor);
        }
    }
}