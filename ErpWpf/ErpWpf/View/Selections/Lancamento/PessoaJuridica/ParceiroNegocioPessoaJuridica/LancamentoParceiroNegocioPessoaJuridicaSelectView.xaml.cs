namespace Erp.View.Selections.Lancamento.PessoaJuridica.ParceiroNegocioPessoaJuridica
{
    /// <summary>
    /// Interaction logic for LancamentoParceiroNegocioPessoaJuridicaSelectView.xaml
    /// </summary>
    public partial class LancamentoParceiroNegocioPessoaJuridicaSelectView 
    {
        private SelectionDefaultActions Actions { get; set; }
        public LancamentoParceiroNegocioPessoaJuridicaSelectView()
        {
            InitializeComponent();
            Actions = new SelectionDefaultActions(this, txtFiltro);
        }
    }
}
