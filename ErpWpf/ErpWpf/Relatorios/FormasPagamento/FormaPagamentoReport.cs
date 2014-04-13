using Erp.Business.Entity.Vendas.Pedido.ClassesRelacionadas;

namespace Erp.Relatorios.FormasPagamento
{
    public partial class FormaPagamentoReport : BaseLandscape
    {
        public FormaPagamentoReport()
        {
            InitializeComponent();
            bindingSource.DataSource = FormaPagamentoRepository.GetListAtivos();
        }

    }
}
