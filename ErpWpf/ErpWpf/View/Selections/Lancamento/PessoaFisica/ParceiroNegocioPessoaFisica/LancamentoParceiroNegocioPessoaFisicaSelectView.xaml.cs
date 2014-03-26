namespace Erp.View.Selections.Lancamento.PessoaFisica.ParceiroNegocioPessoaFisica
{
    /// <summary>
    /// Interaction logic for LancamentoParceiroNegocioPessoaFisicaSelectView.xaml
    /// </summary>
    public partial class LancamentoParceiroNegocioPessoaFisicaSelectView 
    {
        private SelectionDefaultActions Actions { get; set; }
        public LancamentoParceiroNegocioPessoaFisicaSelectView()
        {
            InitializeComponent();
            Actions = new SelectionDefaultActions(this);
        }
    }
}
