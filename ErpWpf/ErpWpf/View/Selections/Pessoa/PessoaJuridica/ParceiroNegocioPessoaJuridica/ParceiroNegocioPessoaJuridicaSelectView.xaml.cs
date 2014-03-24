using Erp.Annotations;

namespace Erp.View.Selections.Pessoa.PessoaJuridica.ParceiroNegocioPessoaJuridica
{
    /// <summary>
    /// Interaction logic for ParceiroNegocioPessoaJuridicaSelectView.xaml
    /// </summary>
    public partial class ParceiroNegocioPessoaJuridicaSelectView 
    {
        private SelectionDefaultActions SelectionDefault { [UsedImplicitly] get; set; }
        public ParceiroNegocioPessoaJuridicaSelectView()
        {
            InitializeComponent();
            SelectionDefault = new SelectionDefaultActions(this);
        }
    }
}
