using FluentNHibernate.Mapping;

namespace Erp.Business.Entity.Estoque.Produto.SubClass.Filme.ClassesRelacionadas
{
    public class GeneroMap : ClassMap<Genero>
    {
        public GeneroMap()
        {
            Id(x => x.Id).GeneratedBy.Sequence("sqGenero");
        }
    }
}