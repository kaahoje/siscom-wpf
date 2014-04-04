using System;
using NHibernate;

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
    }
}
