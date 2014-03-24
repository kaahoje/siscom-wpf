using System;
using System.Collections.Generic;
using Erp.Business.Entity.Contabil;
using Erp.Business.Entity.Contabil.Pessoa.SubClass.PessoaJuridica;
using NHibernate;
using NHibernate.Criterion;

namespace Erp.Business.Entity.Vendas.MovimentacaoCaixa.SubClass.PagamentoCliente
{
    public class PagamentoClienteRepository : RepositoryBase<PagamentoCliente>
    {
        public static IList<PagamentoCliente> PagamentosDia(int caixa, DateTime dia, PessoaJuridica empresa)
        {
            return NHibernateHttpModule.Session.CreateCriteria<PagamentoCliente>().Add(
                Restrictions.Where<PagamentoCliente>(
                    cliente => cliente.DataMovimento == dia &&
                               cliente.Caixa == caixa && cliente.Empresa == empresa)).List<PagamentoCliente>();
        }

        public static PagamentoCliente Save(PagamentoCliente pag, Pedido.Pedido pedido)
        {
            ITransaction t = NHibernateHttpModule.Session.BeginTransaction();
            try
            {
                if (pag.Valor < 0)
                {
                    pag.Valor *= -1;
                }

                pag.Caixa = pedido.Caixa;
                pag.DataMovimento = pedido.DataPedido;
                pag.Usuario = pedido.Usuario;

                //var lanc = new Lancamento
                //{
                //    DataLancamento = pag.DataMovimento,
                //    TipoTitulo = pag.TipoRecebimento.TipoTitulo,
                //    Pessoa = pag.Cliente,
                //    Valor = pag.Valor,
                //    Desconto = pag.Descontos,
                //    Historico = pag.Historico,
                //    Documento = pag.Documento
                //};
                //LancamentoRepository.GeraPartida(lanc);
                NHibernateHttpModule.Session.Save(pag);
                //NHibernateHttpModule.Session.Save(lanc);
            }
            catch (Exception)
            {
                t.Rollback();
                throw;
            }
            return pag;
        }
    }
}