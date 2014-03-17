using FluentNHibernate.Mapping;

namespace Erp.Business.Entity.Vendas.Pedido.Restaurante.ClassesRelacionadas
{
    public class ComposicaoProdutoMap : SubclassMap<ComposicaoProduto>
    {
        public ComposicaoProdutoMap()
        {
            HasMany(x => x.Composicao);
        }
    }
}