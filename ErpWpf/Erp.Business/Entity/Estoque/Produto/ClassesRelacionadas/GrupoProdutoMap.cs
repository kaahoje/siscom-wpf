using FluentNHibernate.Mapping;

namespace Erp.Business.Entity.Estoque.Produto.ClassesRelacionadas
{
    public class GrupoProdutoMap : ClassMap<GrupoProduto>
    {
        public GrupoProdutoMap()
        {
            Id(x => x.Id).Unique().Not.Nullable().GeneratedBy.Sequence("sqGrupoProduto");

            Map(x => x.Descricao).Not.Nullable();

            Map(x => x.Status);
        }
    }
}