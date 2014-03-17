using System.Collections.Generic;
using FluentNHibernate.Conventions;

namespace Erp.Business.Entity.Vendas.Ecf
{
    public class ReducaoZRepository : RepositoryBase<ReducaoZ>
    {
        public static bool VerificaExistenciaReducaoZ(ReducaoZ reducao)
        {
            IList<ReducaoZ> list = GetQueryOver().Where(z => z.Crz == reducao.Crz &&
                                                             z.Coo == reducao.Crz).List();
            if (list.IsEmpty())
            {
                return false;
            }
            return true;
        }
    }
}