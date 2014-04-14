using Erp.Annotations;

namespace Erp.View.Selections
{
    /// <summary>
    /// Interaction logic for GrupoProdutoSelectView.xaml
    /// </summary>
    public partial class GrupoProdutoSelectView 
    {
        private SelectionDefaultActions SelectionDefault { [UsedImplicitly] get; set; }
        public GrupoProdutoSelectView()
        {
            InitializeComponent();
            SelectionDefault = new SelectionDefaultActions(this, txtFiltro);
            
        }
    }
}
