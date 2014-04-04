using System;
using NHibernate;

namespace Erp.Business.Entity.Contabil
{
    public class TransferenciaRepository : RepositoryBase<Transferencia>, IDisposable
    {
        public void Dispose()
        {
        }

        public new static void Save(Transferencia entity)
        {
            var s = NHibernateHttpModule.Session;
            var t = s.BeginTransaction();
            try
            {
                SaveInTransaction(s, entity);
                t.Commit();
            }
            catch (Exception)
            {
                t.Rollback();
                throw;
            }
        }

        public static void SaveInTransaction(ISession session, Transferencia entity)
        {
            var lancamento = new Lancamento();
            var partida = new PartidasLancamento();
            var contraPartida = new PartidasLancamento();

            // Criação do lançamento.
            //lancamento.Pessoa = Utils.Configuracao.PessoaPadrao;
            lancamento.DataLancamento = DateTime.Now;
            
            lancamento.Valor = entity.Valor;

            // Criação das partidas.
            partida.PlanoConta = entity.ContaOrigem;
            partida.Valor = entity.Valor;

            contraPartida.PlanoConta = entity.ContaDestino;
            contraPartida.Valor = entity.Valor;

            // Coloca as partidas no lançamento.
            lancamento.Partidas.Add(partida);
            lancamento.Partidas.Add(contraPartida);

            // Salva o lançamento.
            using (new LancamentoRepository())
            {
                LancamentoRepository.Save(lancamento);
            }
            // Passa o lançamento para a transferência.
            entity.Lancamentos.Add(lancamento);

            // Salva a transferência.
            session.Save(entity);
        }
    }
}