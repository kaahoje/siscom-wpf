namespace Erp.View.Selections.CustoFixo.PessoaJuridica.ParceiroNegocioPessoaJuridica
{
    /// <summary>
    /// Interaction logic for CustoFixoParceiroNegocioPessoaJuridicaSelectView.xaml
    /// </summary>
    public partial class CustoFixoParceiroNegocioPessoaJuridicaSelectView 
    {
        private SelectionDefaultActions Actions { get; set; }
        public CustoFixoParceiroNegocioPessoaJuridicaSelectView()
        {
            InitializeComponent();
            Actions = new SelectionDefaultActions(this);
        }
    }
}
