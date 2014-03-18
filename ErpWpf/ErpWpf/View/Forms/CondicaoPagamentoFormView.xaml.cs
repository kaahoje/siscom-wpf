using Erp.Business.Entity.Vendas.Pedido.ClassesRelacionadas;

namespace Erp.View.Forms
{
    /// <summary>
    /// Interaction logic for CondicaoPagamentoFormView.xaml
    /// </summary>
    public partial class CondicaoPagamentoFormView 
    {
        private FormDefaultActions<CondicaoPagamento> FormDefaultActions { get; set; }
        public CondicaoPagamentoFormView()
        {
            InitializeComponent();
            RestCommands.DataContext = DataContext;

            FormDefaultActions = new FormDefaultActions<CondicaoPagamento>(this) { IsEnableShortcuts = false };
        }
    }
}
