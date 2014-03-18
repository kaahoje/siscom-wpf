using Erp.Annotations;
using Erp.Business.Entity.Estoque.Produto.ClassesRelacionadas;
using Erp.Model.Forms;

namespace Erp.View.Forms
{
    /// <summary>
    /// Interaction logic for GrupoProdutoFormView.xaml
    /// </summary>
    public partial class GrupoProdutoFormView
    {
        private FormDefaultActions<GrupoProduto> FormDefaultActions { [UsedImplicitly] get; set; }
        public GrupoProdutoFormView()
        {
            InitializeComponent();
            DataContext = new GrupoProdutoFormModel();
            RestCommands.DataContext = DataContext;
            FormDefaultActions = new FormDefaultActions<GrupoProduto>(this) {IsEnableShortcuts = false};
        }
    }
}
