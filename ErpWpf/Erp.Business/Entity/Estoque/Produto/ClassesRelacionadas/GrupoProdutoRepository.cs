using System.Collections.Generic;
using DevExpress.Web.ASPxEditors;
using NHibernate.Criterion;

namespace Erp.Business.Entity.Estoque.Produto.ClassesRelacionadas
{
    public class GrupoProdutoRepository : RepositoryBase<GrupoProduto>
    {
        public static object GetRange(ListEditItemsRequestedByFilterConditionEventArgs args)
        {
            var skip = args.BeginIndex;
            var take = args.EndIndex - skip + 1;
            return GetQueryOver().Where(grupo => grupo.Descricao.IsInsensitiveLike(args.Filter + "%"))
                .Skip(skip).Take(take).List<GrupoProduto>();
        }

        public static object GetByValue(ListEditItemRequestedByValueEventArgs args)
        {
            if (args.Value == null)
            {
                return new List<GrupoProduto>();
            }
            return GetQueryOver().Where(grupo => grupo.Id == int.Parse(args.Value.ToString())).List<GrupoProduto>();

        }

        public static IList<GrupoProduto> GetByRange(string filter, int minLenghtPesquisa)
        {
            return GetQueryOver().Where(x => x.Descricao.IsInsensitiveLike(ContainsStringFilter(filter)))
                .Take(minLenghtPesquisa).List();
        }
    }
}