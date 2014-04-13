using Erp.Business.Entity.Vendas.Pedido.ClassesRelacionadas;

namespace Erp.Relatorios.CondicoesPagamento
{
    public partial class CondicaoPagamentoReport : BaseLandscape
    {
        public CondicaoPagamentoReport()
        {
            InitializeComponent();
            bindingSource.DataSource = CondicaoPagamentoRepository.GetListAtivos();
            
        }

    }
}
