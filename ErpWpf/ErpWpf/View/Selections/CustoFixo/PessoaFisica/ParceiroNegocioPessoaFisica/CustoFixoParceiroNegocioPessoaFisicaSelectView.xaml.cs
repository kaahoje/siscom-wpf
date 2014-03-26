namespace Erp.View.Selections.CustoFixo.PessoaFisica.ParceiroNegocioPessoaFisica
{
    /// <summary>
    /// Interaction logic for CustoFixoParceiroNegocioPessoaFisicaSelectView.xaml
    /// </summary>
    public partial class CustoFixoParceiroNegocioPessoaFisicaSelectView 
    {
        private SelectionDefaultActions Actions { get; set; }
        public CustoFixoParceiroNegocioPessoaFisicaSelectView()
        {
            InitializeComponent();
            Actions = new SelectionDefaultActions(this);
        }
    }
}
