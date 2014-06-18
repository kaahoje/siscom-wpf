using System.Collections.Generic;
using Erp.Business.Enum;
using NHibernate.Criterion;

namespace Erp.Business.Entity.Estoque.Produto
{
    public class ProdutoRepository : RepositoryBase<Produto>
    {
        public static void BaixarQuantidadeProduto( Produto produto, decimal quantidade)
        {
            if (quantidade > 0)
            {
                quantidade = quantidade*-1;
            }
            var prod = GetById(produto.Id);
            prod.QuantidadeAtual -= quantidade;
            Session.Save(prod);
        }

        public static IList<Produto> GetByDescricao(string param)
        {
            return GetList(Restrictions.InsensitiveLike("Descricao", "%" + param + "%"));
        }

        public static IList<Produto> GetByCodBarra(string param)
        {
            return GetList(Restrictions.InsensitiveLike("CodBarra", param));
        }

        public static IList<Produto> GetByReferencia(string param)
        {
            return GetList(Restrictions.InsensitiveLike("Referencia", param));
        }


        public static IList<Produto> GetProducaoPropriaByDescricao(string descricao)
        {
            Junction crit = Restrictions.Conjunction().
                Add(Restrictions.InsensitiveLike("Descricao", "%" + descricao + "%"))
                .Add(Restrictions.Eq("Ippt", Ippt.Propria));
            return GetList(crit);
        }

        public static IList<Produto> GetProducaoPropriaByReferencia(string referencia)
        {
            Junction crit = Restrictions.Conjunction().
                Add(Restrictions.InsensitiveLike("Referencia", referencia))
                .Add(Restrictions.Eq("Ippt", Ippt.Propria));
            return GetList(crit);
        }

        public static IList<Produto> GetProducaoPropriaByCodBarra(string codBarra)
        {
            Junction crit = Restrictions.Conjunction().
                Add(Restrictions.InsensitiveLike("CodBarra", codBarra))
                .Add(Restrictions.Eq("Ippt", Ippt.Propria));
            return GetList(crit);
        }

        public static IList<Produto> GetByRange(string filtro)
        {
            return GetByRange(filtro, -1);
        }
        public static IList<Produto> GetByRange(string filtro, int takePesquisa)
        {
            if (Validation.Validation.GetOnlyNumber(filtro).Length == 13)
            {
                return
                GetQueryOver()
                    .Where(prod => prod.CodBarra.IsInsensitiveLike(filtro) &&
                        prod.Status == Status.Ativo)
                    .List();
            }
            return
               GetQueryOver()
                   .Where(prod => (prod.Descricao.IsInsensitiveLike(ContainsStringFilter(filtro))
                       || prod.Referencia.IsInsensitiveLike(ContainsStringFilter(filtro))
                       || prod.CodBarra.IsInsensitiveLike(StartStringFilter(filtro))) && 
                       prod.Status == Status.Ativo)
                       .List();
        }
    }
}