using System;
using System.Collections.Generic;
using Erp.Business.Entity.Contabil.Pessoa.SubClass.PessoaJuridica;
using Erp.Business.Entity.Vendas.Pedido.ClassesRelacionadas;
using NHibernate.Criterion;

namespace Erp.Business.Entity.Vendas.MovimentacaoCaixa.SubClass.RecebimentoVenda
{
    public class RecebimentoVendaRepository : RepositoryBase<RecebimentoVenda>
    {
        public static IList<RecebimentoVenda> RecebimentosDia(int caixa, DateTime dia, PessoaJuridica empresa)
        {
            return NHibernateHttpModule.Session.CreateCriteria<RecebimentoVenda>().Add(
                Restrictions.Where<RecebimentoVenda>(venda =>
                    venda.DataMovimento == dia &&
                    venda.Caixa == caixa && venda.Empresa == empresa)).List<RecebimentoVenda>();
        }

        public static RecebimentoVenda CreateRecebimentoVendaByPedido(PagamentoPedido pag, Pedido.Pedido pedido)
        {
            return new RecebimentoVenda
            {
                DataMovimento = pedido.DataPedido,
                Caixa = pedido.Caixa,
                Usuario = pedido.Usuario,
                Empresa = pedido.Empresa,
                FormaPagamento = pag.FormaPagamento,
                Historico = "RECEBIMENTO DO PEDIDO " + pag.Pedido.Id + " PARCELA " + pag.Parcela,
                Valor = pag.ValorTotal
            };
        }
    }
}