using Erp.Business.Enum;
using FluentNHibernate.Mapping;

namespace Erp.Business.Entity.Estoque.Produto.ClassesRelacionadas
{
    public class MovimentacaoProdutoMap : ClassMap<MovimentacaoProduto>
    {
        public MovimentacaoProdutoMap()
        {
            Id(x => x.Id).Unique().Not.Nullable().GeneratedBy.Sequence("sqMovimentacao");

            Map(x => x.DataMovimentacao).Not.Nullable();
            Map(x => x.Documento);
            Map(x => x.EntradaSaida).CustomType<EntradaSaida>();
            Map(x => x.Observacao);
            Map(x => x.Quantidade);
            Map(x => x.Valor);
            Map(x => x.Status);

            References(x => x.Produto).Not.Nullable();
        }
    }
}