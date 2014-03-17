using FluentNHibernate.Mapping;

namespace Erp.Business.Entity.Estoque.Produto.ClassesRelacionadas
{
    public class UnidadeMap : ClassMap<Unidade>
    {
        public UnidadeMap()
        {
            Id(x => x.Id).GeneratedBy.Sequence("sqUnidade").Not.Nullable().Unique();

            Map(x => x.Descricao).Not.Nullable();
            Map(x => x.Sigla).Not.Nullable();
            Map(x => x.Quantidade).Not.Nullable();
            Map(x => x.Status);
        }
    }
}