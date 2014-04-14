namespace Erp.View.Forms.Pessoa.PessoaJuridica.ParceiroNegocioPessoaJuridica
{
    /// <summary>
    /// Interaction logic for ParceiroNegocioPessoaJuridicaFormView.xaml
    /// </summary>
    public partial class ParceiroNegocioPessoaJuridicaFormView 
    {
        private FormDefaultActions<Business.Entity.Contabil.Pessoa.Pessoa> FormActions { get; set; } 
        public ParceiroNegocioPessoaJuridicaFormView()
        {
            InitializeComponent();
            //DataContext = new ParceiroNegocioPessoaJuridicaFormModel();
            PessoaUserControl.DataContext = DataContext;
            RestCommand.DataContext = DataContext;
            FormActions = new FormDefaultActions<Business.Entity.Contabil.Pessoa.Pessoa>(this,txtRazaoSocial){IsEnableShortcuts = false};
        }
    }
}
