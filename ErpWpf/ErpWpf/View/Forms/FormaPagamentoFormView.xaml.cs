using Erp.Model.Forms;

namespace Erp.View.Forms
{
    /// <summary>
    /// Interaction logic for FormaPagamentoFormView.xaml
    /// </summary>
    public partial class FormaPagamentoFormView 
    {
        private FormDefaultActions FormDefaultActions { get; set; }
        public FormaPagamentoFormView()
        {
            InitializeComponent();
            DataContext = new FormaPagamentoFormModel();
            RestCommands.DataContext = DataContext;
            FormDefaultActions = new FormDefaultActions(this);
        }
    }
}
