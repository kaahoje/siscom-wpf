using Erp.Model.Forms.Pessoa.PessoaFisica;

namespace Erp.View.Forms.Pessoa.PessoaFisica
{
    /// <summary>
    /// Interaction logic for PessoaFisicaFormView.xaml
    /// </summary>
    public partial class PessoaFisicaFormView 
    {
        private FormDefaultActions<Business.Entity.Contabil.Pessoa.Pessoa> FormActions { get; set; } 
        public PessoaFisicaFormView()
        {
            InitializeComponent();
            DataContext = new PessoaFisicaFormModel();
            
            RestCommands.DataContext = DataContext;
            FormActions = new FormDefaultActions<Business.Entity.Contabil.Pessoa.Pessoa>(this,this);
        }
    }
}
