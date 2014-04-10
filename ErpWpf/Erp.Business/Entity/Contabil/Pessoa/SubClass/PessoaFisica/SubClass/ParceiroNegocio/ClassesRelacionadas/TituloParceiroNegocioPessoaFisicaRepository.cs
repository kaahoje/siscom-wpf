using System;
using System.Collections.Generic;
using Erp.Business.Enum;
using NHibernate.Criterion;

namespace Erp.Business.Entity.Contabil.Pessoa.SubClass.PessoaFisica.SubClass.ParceiroNegocio.ClassesRelacionadas
{
    public class TituloParceiroNegocioPessoaFisicaRepository : RepositoryBase<TituloParceiroNegocioPessoaFisica>
    {
        public static void BaixarTitulo(TituloParceiroNegocioPessoaFisica titulo)
        {
            var l = new LancamentoParceiroNegocioPessoaFisica();
            LancamentoRepository.MountLancamentoByTitulo(l, titulo);
            l.ParceiroNegocioPessoaFisica= titulo.ParceiroNegocioPessoaFisica;

            var s = NHibernateHttpModule.Session;

            using (var t = s.BeginTransaction())
            {
                try
                {
                    LancamentoRepository.Session = s;
                    LancamentoRepository.Save(l);
                    titulo.Lancamento = l;
                    titulo.Baixa = DateTime.Now;
                    titulo.Baixado = true;
                    titulo.DataLancamento = l.DataLancamento;
                    s.Update(titulo);
                    t.Commit();
                }
                catch (Exception)
                {
                    t.Rollback();
                    throw;
                }

            }
        }

        public static IList<TituloParceiroNegocioPessoaFisica> GetByRange(string filter, int takePesquisa)
        {
            if (filter.Length == Validation.Validation.GetOnlyNumber(filter).Length)
            {
                return GetQueryOver().Where(x => x.Status == Status.Ativo).JoinQueryOver(custo => custo.ParceiroNegocioPessoaFisica)
                    .Where(parceiroNegocio => parceiroNegocio.Cpf.IsInsensitiveLike(StartStringFilter(filter)))
                    .Take(takePesquisa).List();
            }
            return GetQueryOver().Where(x => x.Status == Status.Ativo).JoinQueryOver(custo => custo.ParceiroNegocioPessoaFisica)
                    .Where(parceiroNegocio => parceiroNegocio.Nome.IsInsensitiveLike(ContainsStringFilter(filter)) ||
                        parceiroNegocio.Alias.IsInsensitiveLike(ContainsStringFilter(filter)))
                    .Take(takePesquisa).List();
        }
    }
}
