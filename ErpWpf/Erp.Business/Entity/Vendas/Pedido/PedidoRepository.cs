using System;
using Erp.Business.Entity.Contabil;
using Erp.Business.Entity.Estoque.Produto;
using Erp.Business.Entity.Vendas.Pedido.ClassesRelacionadas;
using Erp.Business.Enum;
using NHibernate;

namespace Erp.Business.Entity.Vendas.Pedido
{
    public class PedidoRepository : RepositoryBase<Pedido>
    {
        private static string CriaDocumento(Pedido pedido, int parcela)
        {
            return "P" + pedido.Id + "-" + parcela + "/" + pedido.Pagamento.Count;
        }

        internal static string CriaHistorico(Pedido pedido)
        {
            return "Recebimento efetuado por sucesso do pedido: " + pedido.Id;
        }

        //internal static Lancamento CriaLancamento(Pedido pedido, string historico)
        //{
        //    return new Lancamento
        //    {
        //        DataLancamento = pedido.DataPedido,
        //        Historico = historico,
        //        Pessoa = pedido.Cliente,
        //        Vencimento = pedido.DataPedido,
        //    };
        //}

        internal static void DeterminarPartida(Lancamento lanc, Produto prod, FormaPagamento formaPag)
        {
            switch (prod.Tipo)
            {
                case TipoProduto.Mercadoria:
                    
                    LancamentoRepository.GeraPartida(lanc);
                    break;
                case TipoProduto.Produto:
                    
                    LancamentoRepository.GeraPartida(lanc);
                    break;
                case TipoProduto.Servico:
                    
                    LancamentoRepository.GeraPartida(lanc);
                    break;
            }
        }


        //internal static Boolean LancaTitulo(PagamentoPedido pag)
        //{
        //    return LancaTituloInTransaction(pag, Session);
        //}

        //public static Boolean LancaTituloInTransaction(PagamentoPedido pag, ISession session)
        //{
        //    var titulo = new Titulo
        //    {
        //        DataLancamento = pag.Pedido.DataPedido,
        //        DataVencimento = pag.Vencimento,
        //        Historico = CriaHistorico(pag.Pedido),
        //        NotaFiscal = pag.Pedido.NotaFiscal,
        //        NumeroOrdem = CriaDocumento(pag.Pedido, pag.Parcela),
        //        Pessoa = pag.Pedido.Cliente,
        //        Valor = pag.Valor,
        //        Juros = pag.Juros,
        //        TipoTitulo = pag.FormaPagamento.TipoTitulo
        //    };
        //    try
        //    {
        //        session.Save(titulo);
        //    }
        //    catch (Exception)
        //    {
        //        return false;
        //    }
        //    return true;
        //}
    }
}