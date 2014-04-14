using System;
using System.Collections.Generic;
using DevExpress.Web.ASPxEditors;
using Erp.Business.Enum;
using NHibernate.Criterion;

namespace Erp.Business.Entity.Estoque.Produto.ClassesRelacionadas
{
    public class UnidadeRepository : RepositoryBase<Unidade>
    {
        public static IList<Unidade> GetByRange(ListEditItemsRequestedByFilterConditionEventArgs args)
        {
            var skip = args.BeginIndex;
            var take = args.EndIndex - skip + 1;
            return GetByRange(args.Filter, skip, take);
        }

        public static IList<Unidade> GetByRange(String filter,int skip, int take)
        {
            return GetQueryOver().Where(x => (x.Descricao.IsInsensitiveLike(ContainsStringFilter(filter)) ||
                x.Sigla.IsInsensitiveLike(ContainsStringFilter(filter))) && x.Status == Status.Ativo)
                .Skip(skip)
                .Take(take).List<Unidade>();
        } 
        public static IList<Unidade> GetByValue(ListEditItemRequestedByValueEventArgs args)
        {
            if (args.Value == null)
            {
                return new List<Unidade>();
            }
            return GetQueryOver().Where(un => un.Id == int.Parse(args.Value.ToString())).List<Unidade>();
        } 
    }
}