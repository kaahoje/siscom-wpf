using FluentNHibernate.Mapping;

namespace Erp.Business.Entity.Vendas.MovimentacaoCaixa.SubClass.PagamentoCliente
{
    public class PagamentoClienteMap : SubclassMap<PagamentoCliente>
    {
        public PagamentoClienteMap()
        {
            

            Map(x => x.Acrescimos);

            Map(x => x.Descontos);

            Map(x => x.Documento);

            References(x => x.Cliente).Not.Nullable();

            References(x => x.FormaPagamento).Column("tiporecebimento_id").Not.Nullable();
        }
    }
}