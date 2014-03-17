using Erp.Annotations;
using Erp.Model.Grids;

namespace Erp.View.Selections
{
    /// <summary>
    /// Interaction logic for FormaPagamentoSelectView.xaml
    /// </summary>
    public partial class FormaPagamentoSelectView
    {
        private SelectionDefaultActions SelectionDefault { [UsedImplicitly] get; set; }
        public FormaPagamentoSelectView()
        {
            InitializeComponent();
            DataContext = new FormaPagamentoSelectModel();
            SelectionDefault = new SelectionDefaultActions(this);
        }
    }
}
