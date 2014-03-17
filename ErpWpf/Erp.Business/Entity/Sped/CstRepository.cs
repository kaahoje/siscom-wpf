using System.Collections.Generic;
using FluentNHibernate.Conventions;

namespace Erp.Business.Entity.Sped
{
    public class CstRepository : RepositoryBase<Cst>
    {
        public static Cst GetByCodigo(string codigo)
        {
            IList<Cst> list = GetQueryOver().Where(cst => cst.Codigo == codigo).List();
            if (list.IsEmpty())
            {
                return null;
            }
            return list[0];
        }
    }
}