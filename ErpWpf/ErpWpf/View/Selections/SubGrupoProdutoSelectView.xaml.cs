using Erp.Annotations;

namespace Erp.View.Selections
{
    /// <summary>
    /// Interaction logic for SubGrupoProdutoSelectView.xaml
    /// </summary>
    public partial class SubGrupoProdutoSelectView 
    {
        private SelectionDefaultActions SelectionDefault { [UsedImplicitly] get; set; }
        public SubGrupoProdutoSelectView()
        {
            InitializeComponent();
            SelectionDefault = new SelectionDefaultActions(this, txtFiltro);
        }
    }
}
