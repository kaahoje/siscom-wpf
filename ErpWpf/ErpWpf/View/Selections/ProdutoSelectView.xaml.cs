using Erp.Annotations;

namespace Erp.View.Selections
{
    /// <summary>
    /// Interaction logic for ProdutoSelectView.xaml
    /// </summary>
    public partial class ProdutoSelectView 
    {
        private SelectionDefaultActions SelectionDefault { [UsedImplicitly] get; set; }
        public ProdutoSelectView()
        {
            InitializeComponent();
            SelectionDefault = new SelectionDefaultActions(this, txtFiltro);
        }
    }
}
