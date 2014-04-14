using Erp.Annotations;

namespace Erp.View.Selections.Pessoa.PessoaJuridica
{
    /// <summary>
    /// Interaction logic for PessoaJuridicaSelectView.xaml
    /// </summary>
    public partial class PessoaJuridicaSelectView 
    {
        private SelectionDefaultActions SelectionDefault { [UsedImplicitly] get; set; }
        public PessoaJuridicaSelectView()
        {
            InitializeComponent();
            SelectionDefault = new SelectionDefaultActions(this, txtFiltro);
        }
    }
}
