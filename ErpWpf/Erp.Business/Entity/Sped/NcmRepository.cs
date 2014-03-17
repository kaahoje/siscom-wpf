using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using DevExpress.Web.ASPxEditors;
using NHibernate.Criterion;

namespace Erp.Business.Entity.Sped
{
    public class NcmRepository : RepositoryBase<Ncm>
    {
        public static Ncm GetByCodigo(string ncm)
        {
            return GetQueryOver().Where(n => n.Codigo == ncm ).List().SingleOrDefault();
        }


        public static object GetNcmRange(ListEditItemsRequestedByFilterConditionEventArgs args)
        {
            var beginIndex = args.BeginIndex;
            var endIndex = args.EndIndex - args.BeginIndex + 1;
            return GetQueryOver().Where(ncm => ncm.Codigo.IsInsensitiveLike(args.Filter + "%") ||
                ncm.Descricao.IsInsensitiveLike(args.Filter + "%"))
                .Skip(beginIndex).Take(endIndex).List<Ncm>();
            //return GetList();
        }

        public static object GetNcmByValue(ListEditItemRequestedByValueEventArgs args)
        {
            if (args.Value == null)
            {
                return new List<Ncm>();
            }
            return GetQueryOver().Where(ncm => ncm.Id == int.Parse(args.Value.ToString())).List<Ncm>();
        }

        public static IList<Ncm> GetByRange(string filter, int takePesquisa)
        {
            if (Validation.Validation.GetOnlyNumber(filter).Length == filter.Length)
            {
                return
                    GetQueryOver()
                        .Where(x => x.Codigo.IsInsensitiveLike(ContainsStringFilter(filter)))
                        .Take(takePesquisa).List();
            }
            else
            {
                return
                    GetQueryOver()
                        .Where(x => x.Descricao.IsInsensitiveLike(ContainsStringFilter(filter)))
                        .Take(takePesquisa).List();
            }
        }
    }
}