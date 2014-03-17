using Erp.Annotations;
using Erp.Model.Forms;

namespace Erp.View.Forms
{
    /// <summary>
    /// Interaction logic for GrupoProdutoFormView.xaml
    /// </summary>
    public partial class GrupoProdutoFormView
    {
        private FormDefaultActions FormDefaultActions { [UsedImplicitly] get; set; }
        public GrupoProdutoFormView()
        {
            InitializeComponent();
            DataContext = new GrupoProdutoFormModel();
            RestCommands.DataContext = DataContext;
            FormDefaultActions = new FormDefaultActions(this) {IsEnableShortcuts = false};
        }
    }
}
