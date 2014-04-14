namespace Erp.View.Selections.Titulos.PessoaFisica.ParceiroNegocioPessoaFisica
{
    /// <summary>
    /// Interaction logic for TituloParceiroNegocioPessoaFisicaSelect.xaml
    /// </summary>
    public partial class TituloParceiroNegocioPessoaFisicaSelectView 
    {
        private SelectionDefaultActions Actions { get; set; }
        public TituloParceiroNegocioPessoaFisicaSelectView()
        {
            InitializeComponent();
            Actions = new SelectionDefaultActions(this, txtFiltro);
        }
    }
}
