namespace Erp.View.Selections
{
    /// <summary>
    /// Interaction logic for TipoTituloSelectView.xaml
    /// </summary>
    public partial class TipoTituloSelectView 
    {
        private SelectionDefaultActions DefaultActions { get; set; }
        public TipoTituloSelectView()
        {
            InitializeComponent();
            DefaultActions = new SelectionDefaultActions(this, txtFiltro);
        }
    }
}
