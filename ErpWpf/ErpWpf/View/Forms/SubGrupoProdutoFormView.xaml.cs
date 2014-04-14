using Erp.Business.Entity.Estoque.Produto.ClassesRelacionadas;

namespace Erp.View.Forms
{
    /// <summary>
    /// Interaction logic for SubGrupoProdutoFormView.xaml
    /// </summary>
    public partial class SubGrupoProdutoFormView
    {
        private FormDefaultActions<SubGrupoProduto> FormDefaultActions { get; set; }
        public SubGrupoProdutoFormView()
        {
            InitializeComponent();
            RestCommands.DataContext = DataContext;
            FormDefaultActions = new FormDefaultActions<SubGrupoProduto>(this,txtDescricao) {IsEnableShortcuts = false};
        }
    }
}
