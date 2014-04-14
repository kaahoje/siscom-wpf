using Erp.Model.Forms.Pessoa.PessoaJuridica;

namespace Erp.View.Forms.Pessoa.PessoaJuridica
{
    /// <summary>
    /// Interaction logic for PessoaJuridicaFormView.xaml
    /// </summary>
    public partial class PessoaJuridicaFormView 
    {
        private FormDefaultActions<Business.Entity.Contabil.Pessoa.Pessoa> FormActions { get; set; } 
        public PessoaJuridicaFormView()
        {
            
            InitializeComponent();
            DataContext = new PessoaJuridicaFormModel();
            RestCommands.DataContext = DataContext;
            FormActions = new FormDefaultActions<Business.Entity.Contabil.Pessoa.Pessoa>(this,ctrDadoPessoaJuridica){IsEnableShortcuts = false};
        }
    }
}
