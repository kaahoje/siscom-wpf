using System;

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
    }
}
