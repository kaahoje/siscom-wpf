using Erp.Annotations;
using Erp.Model.Grids;

namespace Erp.View.Selections
{
    /// <summary>
    /// Interaction logic for CondicaoPagamentoSelectView.xaml
    /// </summary>
    public partial class CondicaoPagamentoSelectView
    {
        private SelectionDefaultActions SelectionDefault { [UsedImplicitly] get; set; }
        public CondicaoPagamentoSelectView()
        {
            InitializeComponent();
            SelectionDefault = new SelectionDefaultActions(this);
        }
    }
}
