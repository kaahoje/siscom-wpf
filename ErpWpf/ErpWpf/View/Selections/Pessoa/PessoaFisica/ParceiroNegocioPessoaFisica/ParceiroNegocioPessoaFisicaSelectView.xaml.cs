using Erp.Annotations;

namespace Erp.View.Selections.Pessoa.PessoaFisica.ParceiroNegocioPessoaFisica
{
    /// <summary>
    /// Interaction logic for ParceiroNegocioPessoaFisicaSelectView.xaml
    /// </summary>
    public partial class ParceiroNegocioPessoaFisicaSelectView 
    {
        private SelectionDefaultActions SelectionDefault { [UsedImplicitly] get; set; }
        public ParceiroNegocioPessoaFisicaSelectView()
        {
            InitializeComponent();
            SelectionDefault = new SelectionDefaultActions(this);
        }
    }
}
