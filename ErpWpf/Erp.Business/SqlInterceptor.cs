using System.Diagnostics;
using NHibernate;
using NHibernate.SqlCommand;

namespace Erp.Business
{
    public class SqlInterceptor : EmptyInterceptor
    {
        public override SqlString OnPrepareStatement(SqlString sql)
        {
            Trace.WriteLine(sql.ToString());
            return base.OnPrepareStatement(sql);
        }
    }
}