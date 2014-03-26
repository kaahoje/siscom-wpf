using System.Windows.Input;
using DevExpress.Xpf.Grid.LookUp;
using Erp.Business.Entity.Contabil.Pessoa.SubClass.PessoaJuridica.SubClass.ParceiroNegocio.ClassesRelacionadas;
using Erp.Model.Forms.Lancamento.PessoaJuridica.ParceiroNegocioPessoaJuridica;

namespace Erp.View.Forms.Lancamento.PessoaJuridica.ParceiroNegocioPessoaJuridica
{
    /// <summary>
    /// Interaction logic for LancamentoParceiroNegocioPessoaJuridicaFormView.xaml
    /// </summary>
    public partial class LancamentoParceiroNegocioPessoaJuridicaFormView 
    {
        private LancamentoParceiroNegocioPessoaJuridicaFormModel Model
        {
            get { return (LancamentoParceiroNegocioPessoaJuridicaFormModel) DataContext; }
        }

        private FormDefaultActions<LancamentoParceiroNegocioPessoaJuridica> Actions { get; set; } 
        public LancamentoParceiroNegocioPessoaJuridicaFormView()
        {
            InitializeComponent();
            Actions = new FormDefaultActions<LancamentoParceiroNegocioPessoaJuridica>(this){IsEnableShortcuts = false};
            DataContext = new LancamentoParceiroNegocioPessoaJuridicaFormModel();
            RestCommands.DataContext = DataContext;
        }

        private void ContentElement_OnPreviewKeyUp(object sender, KeyEventArgs e)
        {
            
        }
    }
}
