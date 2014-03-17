using FluentNHibernate.Mapping;

namespace Erp.Business.Entity.Estoque.Produto.ClassesRelacionadas
{
    public class ReceitaMap : ClassMap<Receita>
    {
        public ReceitaMap()
        {
            Id(x => x.Id).Not.Nullable().Unique().GeneratedBy.Sequence("sqReceitaProduto");

            Map(x => x.Quantidade).Not.Nullable();
            Map(x => x.Status);

            References(x => x.MateriaPrima).Not.Nullable();
        }
    }
}