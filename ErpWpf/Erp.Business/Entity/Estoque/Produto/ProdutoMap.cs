using FluentNHibernate.Mapping;

namespace Erp.Business.Entity.Estoque.Produto
{
    public class ProdutoMap : ClassMap<Produto>
    {
        public ProdutoMap()
        {
            Id(x => x.Id).GeneratedBy.Sequence("sqProduto").Not.Nullable().Unique().Column("id");


            Map(x => x.Descricao).Index("ProdutoDescricaoIndex").Unique();
            Map(x => x.Referencia).Index("ProdutoReferenciaIndex");
            Map(x => x.CodBarra).Index("ProdutoCodBarraIndex");
            Map(x => x.PrecoVenda).Not.Nullable();


            Map(x => x.Iat);
            Map(x => x.Ippt).Not.Nullable();
            Map(x => x.Tipo).Not.Nullable();
            Map(x => x.UltimaCompra);
            Map(x => x.ValorPromocional);
            Map(x => x.SaldoMinimo).Default("0");
            Map(x => x.TemReceita);
            Map(x => x.Origem).Not.Nullable();
            Map(x => x.Status);
            
            References(x => x.Ncm).Not.Nullable().LazyLoad();
            References(x => x.UnidadeCompra).Not.Nullable().LazyLoad();
            References(x => x.UnidadeVenda).Not.Nullable().LazyLoad();
            References(x => x.SubGrupo).Not.Nullable().LazyLoad();
            References(x => x.Tributacao).LazyLoad();


            HasMany(x => x.Receitas).KeyColumn("produto_id").Cascade.All().LazyLoad();


            Table(NomesTabela.Produto);
        }
    }
}