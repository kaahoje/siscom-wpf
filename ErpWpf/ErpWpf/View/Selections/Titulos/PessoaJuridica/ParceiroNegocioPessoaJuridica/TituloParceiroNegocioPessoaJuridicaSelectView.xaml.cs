namespace Erp.View.Selections.Titulos.PessoaJuridica.ParceiroNegocioPessoaJuridica
{
    /// <summary>
    /// Interaction logic for TituloParceiroNegocioPessoaJuridicaSelectView.xaml
    /// </summary>
    public partial class TituloParceiroNegocioPessoaJuridicaSelectView 
    {
        private SelectionDefaultActions Actions { get; set; }
        public TituloParceiroNegocioPessoaJuridicaSelectView()
        {
            InitializeComponent();
            Actions = new SelectionDefaultActions(this);
        }
    }
}
