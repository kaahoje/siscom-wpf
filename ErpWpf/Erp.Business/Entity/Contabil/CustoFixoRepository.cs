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

    }
}