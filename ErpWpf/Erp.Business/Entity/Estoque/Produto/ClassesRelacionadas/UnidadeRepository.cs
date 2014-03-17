﻿using System.Collections.Generic;
using DevExpress.Web.ASPxEditors;
using NHibernate.Criterion;

namespace Erp.Business.Entity.Estoque.Produto.ClassesRelacionadas
{
    public class UnidadeRepository : RepositoryBase<Unidade>
    {
        public static IList<Unidade> GetByRange(ListEditItemsRequestedByFilterConditionEventArgs args)
        {
            var skip = args.BeginIndex;
            var take = args.EndIndex - skip + 1;
            return GetQueryOver().Where(unidade => unidade.Descricao.IsInsensitiveLike(args.Filter + "%") || 
                unidade.Sigla.IsInsensitiveLike(args.Filter + "%"))
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