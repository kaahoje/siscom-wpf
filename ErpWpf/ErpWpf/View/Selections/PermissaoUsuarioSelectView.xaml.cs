namespace Erp.View.Selections
{
    /// <summary>
    /// Interaction logic for PermissaoUsuarioSelectView.xaml
    /// </summary>
    public partial class PermissaoUsuarioSelectView 
    {
        private SelectionDefaultActions Actions { get; set; }
        public PermissaoUsuarioSelectView()
        {
            InitializeComponent();
            Actions = new SelectionDefaultActions(this, txtFiltro);
        }
    }
}
