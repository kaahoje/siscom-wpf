using Erp.Business.Entity.Estoque.Produto.ClassesRelacionadas;

namespace Erp.View.Forms
{
    /// <summary>
    /// Interaction logic for UnidadeFormView.xaml
    /// </summary>
    public partial class UnidadeFormView
    {
        private FormDefaultActions<Unidade> FormDefaultActions { get; set; }
        public UnidadeFormView()
        {
            InitializeComponent();
            
            RestCommands.DataContext = DataContext;

            FormDefaultActions = new FormDefaultActions<Unidade>(this,txtSigla) { IsEnableShortcuts = false };
        }
    }
}
