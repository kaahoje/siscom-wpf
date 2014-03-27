using System.Windows;
using Erp.Business.Entity.Contabil.Pessoa.SubClass.PessoaFisica.SubClass.ParceiroNegocio.ClassesRelacionadas;
using Erp.Model.Forms.Lancamento.PessoaFisica.ParceiroNegocioPessoaFisica;

namespace Erp.View.Forms.Lancamento.PessoaFisica.ParceiroNegocioPessoaFisica
{
    /// <summary>
    /// Interaction logic for LancamentoParceiroNegocioPessoaFisicaFormView.xaml
    /// </summary>
    public partial class LancamentoParceiroNegocioPessoaFisicaFormView 
    {
        private FormDefaultActions<LancamentoParceiroNegocioPessoaFisica> Actions { get; set; }

        private LancamentoParceiroNegocioPessoaFisicaFormModel Model
        {
            get { return (LancamentoParceiroNegocioPessoaFisicaFormModel) DataContext; }
        }

        public LancamentoParceiroNegocioPessoaFisicaFormView()
        {
            InitializeComponent();
            Actions = new FormDefaultActions<LancamentoParceiroNegocioPessoaFisica>(this){IsEnableShortcuts = false};
            DataContext = new LancamentoParceiroNegocioPessoaFisicaFormModel();
            RestCommands.DataContext = DataContext;
        }

        private void LancamentoParceiroNegocioPessoaFisicaFormView_OnLoaded(object sender, RoutedEventArgs e)
        {
            
        }
    }
}
