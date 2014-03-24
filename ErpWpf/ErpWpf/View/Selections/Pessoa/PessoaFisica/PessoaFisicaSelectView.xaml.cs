using Erp.Annotations;

namespace Erp.View.Selections.Pessoa.PessoaFisica
{
    /// <summary>
    /// Interaction logic for PessoaFisicaSelectView.xaml
    /// </summary>
    public partial class PessoaFisicaSelectView 
    {
        private SelectionDefaultActions SelectionDefault { [UsedImplicitly] get; set; }
        public PessoaFisicaSelectView()
        {
            InitializeComponent();
            SelectionDefault = new SelectionDefaultActions(this);
        }
    }
}
