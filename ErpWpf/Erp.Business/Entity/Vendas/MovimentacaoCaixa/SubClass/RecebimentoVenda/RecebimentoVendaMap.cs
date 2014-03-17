using FluentNHibernate.Mapping;

namespace Erp.Business.Entity.Vendas.MovimentacaoCaixa.SubClass.RecebimentoVenda
{
    public class RecebimentoVendaMap : SubclassMap<RecebimentoVenda>
    {
        public RecebimentoVendaMap()
        {
            References(x => x.FormaPagamento);
            
        }
    }
}