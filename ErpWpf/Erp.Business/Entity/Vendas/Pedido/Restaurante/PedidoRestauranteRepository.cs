using System;
using System.Collections.Generic;
using System.Linq;
using Erp.Business.Entity.Contabil;
using Erp.Business.Entity.Contabil.Pessoa.SubClass.PessoaJuridica;
using Erp.Business.Entity.Estoque.Produto;
using Erp.Business.Entity.Estoque.Produto.ClassesRelacionadas;
using Erp.Business.Entity.Vendas.MovimentacaoCaixa.SubClass.RecebimentoVenda;
using Erp.Business.Entity.Vendas.Pedido.ClassesRelacionadas;
using Erp.Business.Entity.Vendas.Pedido.Restaurante.ClassesRelacionadas;
using Erp.Business.Enum;
using NHibernate;

namespace Erp.Business.Entity.Vendas.Pedido.Restaurante
{
    public class PedidoRestauranteRepository : RepositoryBase<PedidoRestaurante>
    {

        public new static PedidoRestaurante Save(PedidoRestaurante pedido)
        {
            ISession session = NHibernateHttpModule.Session;
            ITransaction transaction = session.BeginTransaction();
            try
            {
                if (pedido.Empresa == null)
                {
                    throw new Exception("Informe a empresa do pedido.");
                }
                foreach (PagamentoPedido pag in pedido.Pagamento)
                {
                    pag.FormaPagamento = FormaPagamentoRepository.GetById(
                        pag.FormaPagamento.Id);
                }
                foreach (ComposicaoProduto comp in pedido.Produtos)
                {
                    comp.Produto = ProdutoRepository.GetById(comp.Produto.Id);
                    foreach (ProdutoPedido prod in comp.Composicao)
                    {
                        prod.Produto = ProdutoRepository.GetById(prod.Produto.Id);
                    }
                }
                session.Save(pedido);

                foreach (PagamentoPedido pag in pedido.Pagamento)
                {
                    pag.Pedido = pedido;
                    // Cria o recebimento da venda para o caixa.
                    session.Save(RecebimentoVendaRepository
                        .CreateRecebimentoVendaByPedido(pag, pedido));
                    
                }
                // Efetua o lançamento no contávil.
                PagamentoPedidoRepository.LancarPagamentoRestaurante(pedido);
                // Baixa as quantidades no estoque.
                BaixaEstoque(session, pedido);
                transaction.Commit();
            }
            catch (Exception)
            {
                transaction.Rollback();
                throw;
            }

            return pedido;
        }


        public static decimal GetTotalServicos(PedidoRestaurante pedido)
        {
            
            foreach (PagamentoPedido pag in pedido.Pagamento)
            {
                decimal fator = pag.ValorTotal / pedido.ValorPedido;
                //Lancamento lanc = PedidoRepository.CriaLancamento(pedido, PedidoRepository.CriaHistorico(pedido));
                //lanc.Valor = fator * pag.Valor;
                //lanc.Desconto = pag.Desconto;
                //lanc.Juros = pag.Juros;
                //foreach (ComposicaoProduto prod in pedido.Produtos)
                //{
                //    PedidoRepository.DeterminarPartida(lanc, prod.Produto, pag.FormaPagamento);
                //}
                //if (!pag.FormaPagamento.AVista)
                //{
                //    PedidoRepository.LancaTitulo(pag);
                //}
                //session.Save(lanc);
            }
            //return true;
            throw new NotImplementedException();
        }

        public static decimal GetTotalMercadorias(PedidoRestaurante pedido)
        {
            throw new NotImplementedException();
        }

        public static decimal GetTotalProdutos(PedidoRestaurante pedido)
        {
            throw new NotImplementedException();
        }

        private static void BaixaEstoque(ISession session, PedidoRestaurante pedido)
        {
            // Entra dentro dos produtos.
            foreach (ComposicaoProduto prods in pedido.Produtos)
            {
                // Entra dentro das composições do produto.
                // Observação: os produtos são baixados por meio de sua composição nos pedidos de restaurante,
                // sejam eles produção própria ou de terceiros.
                foreach (ProdutoPedido composicao in prods.Composicao)
                {
                    if (composicao.Produto.Ippt == Ippt.Propria)
                    {
                        if (composicao.Produto.Receitas.Count > 0)
                        {
                            foreach (Receita itemReceita in composicao.Produto.Receitas)
                            {
                                decimal qtd = itemReceita.Quantidade * (composicao.Quantidade *
                                                                      composicao.Produto.UnidadeVenda.Quantidade);
                                ProdutoRepository.BaixarQuantidadeProduto( itemReceita.MateriaPrima, qtd);
                            }
                        }
                        else
                        {
                            decimal qtd = (composicao.Quantidade *
                                           composicao.Produto.UnidadeVenda.Quantidade);
                            ProdutoRepository.BaixarQuantidadeProduto( composicao.Produto, qtd);
                        }
                    }
                    else
                    {
                        decimal qtd = (composicao.Quantidade *
                                       composicao.Produto.UnidadeVenda.Quantidade);
                        ProdutoRepository.BaixarQuantidadeProduto( composicao.Produto, qtd);
                    }
                }
            }
        }

        public static decimal CalcularValorPedidoRestaurante(PedidoRestaurante pedido)
        {
            decimal total = 0;
            foreach (ComposicaoProduto prod in pedido.Produtos)
            {
                total += prod.Valor;
            }
            return total;
        }

        public static IList<PedidoRestaurante> GetVendasDia(int caixa, DateTime dataMovimento, PessoaJuridica proprietaria)
        {
            return
                GetList()
                    .Where(x => x.Empresa == proprietaria && x.Caixa == caixa && x.DataPedido == dataMovimento)
                    .ToList();
        }
    }
}