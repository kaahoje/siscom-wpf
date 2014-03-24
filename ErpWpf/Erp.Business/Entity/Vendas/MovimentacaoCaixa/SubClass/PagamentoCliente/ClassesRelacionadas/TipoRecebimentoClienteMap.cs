using FluentNHibernate.Mapping;

namespace Erp.Business.Entity.Vendas.MovimentacaoCaixa.SubClass.PagamentoCliente.ClassesRelacionadas
{
    public class TipoRecebimentoClienteMap : ClassMap<TipoRecebimentoCliente>
    {
        public TipoRecebimentoClienteMap()
        {
            Id(x => x.Id).Not.Nullable().Unique().GeneratedBy.Sequence("sqTipoRecebimentoCliente");

            Map(x => x.PrazoCompensacao).Not.Nullable();
            Map(x => x.Status);

            Map(x => x.Descricao).Not.Nullable().Unique();

            References(x => x.TipoTitulo).Not.Nullable();
        }
    }
}