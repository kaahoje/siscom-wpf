using FluentNHibernate.Mapping;

namespace Erp.Business.Entity.Estoque.Produto.ClassesRelacionadas
{
    public class SubGrupoProdutoMap : ClassMap<SubGrupoProduto>
    {
        public SubGrupoProdutoMap()
        {
            Id(x => x.Id).Not.Nullable().Unique().GeneratedBy.Sequence("sqSubGrupoProduto");

            Map(x => x.Descricao).Not.Nullable();
            Map(x => x.Impressora);
            Map(x => x.ImprimeEmComandaRestaurante);
            Map(x => x.Status);

            References(x => x.Grupo).Not.Nullable();
        }
    }
}