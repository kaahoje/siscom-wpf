using System;
using System.Collections.Generic;
using Erp.Business.Entity.Sped;
using Erp.Business.Entity.Vendas.Pedido;
using NHibernate;

namespace Erp.Business.Entity.Contabil
{
    public class LancamentoRepository : RepositoryBase<Lancamento>, IDisposable
    {
        public void Dispose()
        {
        }

        public static void GeraPartida(Lancamento lanc)
        {
            //PartidasLancamento pValor = VerificaPartida(lanc, lanc.TipoLancmento.ContaPartidaValor);
            //PartidasLancamento cpValor = VerificaPartida(lanc, lanc.TipoLancmento.ContaContraPartidaValor);
            //PartidasLancamento pDesconto = VerificaPartida(lanc, lanc.TipoLancmento.ContaPartidaDesconto);
            //PartidasLancamento cpDesconto = VerificaPartida(lanc, lanc.TipoLancmento.ContaContraPartidaDesconto);
            //PartidasLancamento pJuros = VerificaPartida(lanc, lanc.TipoLancmento.ContaPartidaJuros);
            //PartidasLancamento cpJuros = VerificaPartida(lanc, lanc.TipoLancmento.ContaContraPartidaJuros);

            //pValor.Valor += lanc.Valor;
            //cpValor.Valor += lanc.Valor;
            //if (lanc.Juros > 0)
            //{
            //    if (pJuros == null)
            //    {
            //        pValor.Valor += lanc.Juros;
            //    }
            //    else
            //    {
            //        pJuros.Valor += lanc.Juros;
            //    }
            //    if (cpJuros == null)
            //    {
            //        cpValor.Valor += lanc.Juros;
            //    }
            //    else
            //    {
            //        cpJuros.Valor += lanc.Juros;
            //    }
            //}
            //if (lanc.Desconto > 0)
            //{
            //    if (pDesconto == null)
            //    {
            //        pValor.Valor -= lanc.Desconto;
            //    }
            //    else
            //    {
            //        pDesconto.Valor -= lanc.Desconto;
            //    }
            //    if (cpDesconto == null)
            //    {
            //        cpValor.Valor += lanc.Desconto;
            //    }
            //    else
            //    {
            //        cpDesconto.Valor += lanc.Desconto;
            //    }
            //}
        }

        public static PartidasLancamento VerificaPartida(Lancamento lanc, PlanoContaReferencial planoConta)
        {
            if (planoConta == null)
            {
                return null;
            }
            foreach (PartidasLancamento partida in lanc.Partidas)
            {
                if (partida.PlanoConta.Codigo.Equals(planoConta.Codigo))
                {
                    return partida;
                }
            }
            // Caso não encontre uma partida correspondente ao código no lançamento cria uma nova partida.
            RepositoryBase<PlanoContaReferencial>.Session = RepositoryBase<Pedido>.Session;
            var p = new PartidasLancamento
            {
                PlanoConta = PlanoContaReferencialRepository.GetByCodigoConta(planoConta.Codigo)
            };
            lanc.Partidas.Add(p);
            return p;
        }

        public new static void Save(Lancamento entity)
        {
            ISession session = NHibernateHttpModule.Session;
            ITransaction transaction = session.BeginTransaction();
            try
            {
                GeraPartida(entity);
                session.Save(entity);
                transaction.Commit();
            }
            catch (Exception)
            {
                transaction.Rollback();
                throw;
            }
        }

        public static IList<Lancamento> GetListByPeriodoLancamento(DateTime inicio, DateTime fim)
        {
            return GetListAtivos(GetQueryOver().Where(lancamento =>
                lancamento.DataLancamento >= inicio && lancamento.DataLancamento <= fim));
        }

        public static IList<Lancamento> GetListByPeriodoVencimento(DateTime inicio, DateTime fim)
        {
            return null;
        }

        public static IList<Lancamento> GetListByMesLancamento(int mes, int ano)
        {
            return GetListAtivos(GetQueryOver().Where(lancamento =>
                lancamento.DataLancamento.Month == mes && lancamento.DataLancamento.Year == ano));
        }

        public static IList<Lancamento> GetListByMesVencimento(int mes, int ano)
        {
            //return GetListAtivos(GetQueryOver().Where(lancamento =>
            //    lancamento.Vencimento.Month == mes && lancamento.Vencimento.Year == ano));
            return null;
        }

        public static IList<Lancamento> GetListEntradasPeriodo(DateTime inicio, DateTime fim)
        {
            TipoTitulo t = null;

            //IQueryOver<Lancamento, TipoTitulo> c = GetQueryOver()
            //    .Where(lancamento => lancamento.DataLancamento >= inicio &&
            //                         lancamento.DataLancamento <= fim)
            //    .Inner.JoinQueryOver(
            //        lancamento => lancamento.TipoTitulo, () => t)
            //    .Where(lancamento => lancamento.Credito);
            //return c.List<Lancamento>();
            return null;
        }
    }
}