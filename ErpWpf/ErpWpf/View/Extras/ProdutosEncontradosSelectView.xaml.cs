using DevExpress.Xpf.Core;
using Erp.View.Selections;

namespace Erp.View.Extras
{
    /// <summary>
    /// Interaction logic for ProdutosEncontradosSelectView.xaml
    /// </summary>
    public class ProdutosEncontradosSelectView : DXWindow
    {
        private SelectionDefaultActions DefaultActions { get; set; }
        public ProdutosEncontradosSelectView()
        {
            //InitializeComponent();
            DefaultActions = new SelectionDefaultActions(this,null);
        }
    }
}
