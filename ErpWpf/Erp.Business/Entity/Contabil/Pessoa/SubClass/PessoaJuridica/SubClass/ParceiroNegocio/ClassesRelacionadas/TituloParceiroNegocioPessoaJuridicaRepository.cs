using System;
using System.Collections.Generic;
using Erp.Business.Enum;
using NHibernate.Criterion;

namespace Erp.Business.Entity.Contabil.Pessoa.SubClass.PessoaJuridica.SubClass.ParceiroNegocio.ClassesRelacionadas
{
    public class TituloParceiroNegocioPessoaJuridicaRepository : RepositoryBase<TituloParceiroNegocioPessoaJuridica>
    {
        public static void BaixarTitulo(TituloParceiroNegocioPessoaJuridica titulo)
        {
            var l = new LancamentoParceiroNegocioPessoaJuridica();
            LancamentoRepository.MountLancamentoByTitulo(l, titulo);
            l.ParceiroNegocioPessoaJuridica = titulo.ParceiroNegocioPessoaJuridica;
            
            var s = NHibernateHttpModule.Session;
            
            using (var t = s.BeginTransaction())
            {
                try
                {
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

        public static IList<TituloParceiroNegocioPessoaJuridica> GetByRange(string filter, int takePesquisa)
        {
            if (filter.Length == Validation.Validation.GetOnlyNumber(filter).Length)
            {
                return GetQueryOver().Where(x => x.Status == Status.Ativo).JoinQueryOver(custo => custo.ParceiroNegocioPessoaJuridica)
                    .Where(parceiroNegocio => parceiroNegocio.Cnpj.IsInsensitiveLike(StartStringFilter(filter)))
                    .Take(takePesquisa).List();
            }
            return GetQueryOver().Where(x => x.Status == Status.Ativo).JoinQueryOver(custo => custo.ParceiroNegocioPessoaJuridica)
                    .Where(parceiroNegocio => parceiroNegocio.RazaoSocial.IsInsensitiveLike(ContainsStringFilter(filter)) ||
                        parceiroNegocio.NomeFantasia.IsInsensitiveLike(ContainsStringFilter(filter)))
                    .Take(takePesquisa).List();
        }
    }
}
