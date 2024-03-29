﻿using System.Collections.Generic;
using DevExpress.Web.ASPxEditors;
using Erp.Business.Enum;
using NHibernate.Criterion;

namespace Erp.Business.Entity.Estoque.Produto.ClassesRelacionadas
{
    public class SubGrupoProdutoRepository : RepositoryBase<SubGrupoProduto>
    {
        public static object GetRange(ListEditItemsRequestedByFilterConditionEventArgs args)
        {
            var skip = args.BeginIndex;
            var take = args.EndIndex - skip + 1;
            return GetQueryOver().Where(sub=> sub.Descricao.IsInsensitiveLike(args.Filter + "%"))
                .Skip(skip)
                .Take(take).List<SubGrupoProduto>();
        }

        
        public static object GetByValue(ListEditItemRequestedByValueEventArgs args)
        {
            if (args.Value == null)
            {
                return new List<SubGrupoProduto>();
            }
            return GetQueryOver().Where(produto => produto.Id == int.Parse(args.Value.ToString())).List<SubGrupoProduto>();
        }

        public static IList<SubGrupoProduto> GetByRange(string filter, int takePesquisa)
        {
            
            return GetQueryOver().Where(x => x.Descricao.IsInsensitiveLike(ContainsStringFilter(filter))
                && x.Status == Status.Ativo).Take(takePesquisa).List();
        }
    }

}