using FluentNHibernate.Mapping;

namespace Erp.Business.Entity.Estoque.Produto.SubClass.Filme
{
    public class FilmeMap : SubclassMap<Filme>
    {
        public FilmeMap()
        {
            HasMany(x => x.Generos);
        }
    }
}