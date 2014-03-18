using Erp.Business.Entity.Vendas.Pedido.ClassesRelacionadas;
using Erp.Model.Forms;

namespace Erp.View.Forms
{
    /// <summary>
    /// Interaction logic for FormaPagamentoFormView.xaml
    /// </summary>
    public partial class FormaPagamentoFormView 
    {
        private FormDefaultActions<FormaPagamento> FormDefaultActions { get; set; }
        public FormaPagamentoFormView()
        {
            InitializeComponent();
            DataContext = new FormaPagamentoFormModel();
            RestCommands.DataContext = DataContext;
            FormDefaultActions = new FormDefaultActions<FormaPagamento>(this) {IsEnableShortcuts = false};
        }
    }
}
