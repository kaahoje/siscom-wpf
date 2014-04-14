using Erp.Model.Forms.Pessoa.PessoaFisica.ParceiroNegocioPessoaFisica;

namespace Erp.View.Forms.Pessoa.PessoaFisica.ParceiroNegocioPessoaFisica
{
    /// <summary>
    /// Interaction logic for ParceiroNegocioPessoaFisicaFormView.xaml
    /// </summary>
    public partial class ParceiroNegocioPessoaFisicaFormView 
    {
        private FormDefaultActions<Business.Entity.Contabil.Pessoa.Pessoa> FormActions { get; set; } 
        public ParceiroNegocioPessoaFisicaFormView()
        {
            InitializeComponent();
            DataContext = new ParceiroNegocioPessoaFisicaFormModel();
            PessoaUserControl.DataContext = DataContext;
            RestCommands.DataContext = DataContext;
            FormActions = new FormDefaultActions<Business.Entity.Contabil.Pessoa.Pessoa>(this,txtNome) { IsEnableShortcuts = false };
        }
    }
}
