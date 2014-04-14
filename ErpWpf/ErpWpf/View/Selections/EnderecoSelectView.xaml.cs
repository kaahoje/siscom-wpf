namespace Erp.View.Selections
{
    /// <summary>
    /// Interaction logic for EnderecoSelectView.xaml
    /// </summary>
    public partial class EnderecoSelectView 
    {
        private SelectionDefaultActions Actions { get; set; }
        public EnderecoSelectView()
        {
            InitializeComponent();
            Actions = new SelectionDefaultActions(this, txtFiltro);
        }
    }
}
