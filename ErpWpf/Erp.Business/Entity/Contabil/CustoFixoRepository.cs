using System;
using Erp.Business.Entity.Contabil.ClassesRelacoinadas;
using NHibernate;

namespace Erp.Business.Entity.Contabil
{
    public class CustoFixoRepository : RepositoryBase<CustoFixo>, IDisposable
    {
        public void Dispose()
        {
        }

        public Titulo GerarTitulo(ISession session, CustoFixo custo, MesGerado mes)
        {
            var t = new Titulo
            {
                DataVencimento = new DateTime(mes.Ano, mes.Mes, custo.DiaVencimento),
                Valor = custo.Valor,
                TipoLancamento = custo.TipoLancamento,
                Pessoa = custo.Pessoa
            };
            session.Save(t);
            return t;
        }

        public Titulo GerarTitulo(CustoFixo custo, MesGerado mes)
        {
            ISession s = NHibernateHttpModule.Session;
            ITransaction t = s.BeginTransaction();

            Titulo tit = GerarTitulo(s, custo, mes);

            t.Commit();
            return tit;
        }
    }
}