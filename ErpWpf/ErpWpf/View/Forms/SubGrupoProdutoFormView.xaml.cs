namespace Erp.View.Forms
{
    /// <summary>
    /// Interaction logic for SubGrupoProdutoFormView.xaml
    /// </summary>
    public partial class SubGrupoProdutoFormView
    {
        private FormDefaultActions FormDefaultActions { get; set; }
        public SubGrupoProdutoFormView()
        {
            InitializeComponent();
            RestCommands.DataContext = DataContext;
            FormDefaultActions = new FormDefaultActions(this) {IsEnableShortcuts = false};
        }
    }
}
