using System.Windows.Input;
using DevExpress.Xpf.Grid.LookUp;
using Erp.Business.Entity.Contabil.Pessoa.SubClass.PessoaFisica.SubClass.ParceiroNegocio.ClassesRelacionadas;
using Erp.Model.Forms.Titulo.PessoaFisica.ParceiroNegocioPessoaFisica;

namespace Erp.View.Forms.Titulo.PessoaFisica.ParceiroNegocioPessoaFisica
{
    
    /// <summary>
    /// Interaction logic for TituloParceiroNegocioPessoaFisicaFormView.xaml
    /// </summary>
    public partial class TituloParceiroNegocioPessoaFisicaFormView 
    {
        TituloParceiroNegocioPessoaFisicaFormModel Model
        {
            get { return (TituloParceiroNegocioPessoaFisicaFormModel) DataContext; }
        }
        private FormDefaultActions<TituloParceiroNegocioPessoaFisica> Actions { get; set; }
        public TituloParceiroNegocioPessoaFisicaFormView()
        {
            InitializeComponent();
            DataContext = new TituloParceiroNegocioPessoaFisicaFormModel();
            RestCommands.DataContext = DataContext;
            Actions = new FormDefaultActions<TituloParceiroNegocioPessoaFisica>(this,dtVencimento){IsEnableShortcuts = false};
            
        }

        private void UIElement_OnPreviewKeyUp(object sender, KeyEventArgs e)
        {
            var combo = sender as LookUpEdit;
            if (combo != null)
            {
                if (combo.Name.Equals(cboPessoa.Name))
                {
                    Model.ParceiroNegocioPessoaFisicaLargeData.Filter = cboPessoa.DisplayText;
                }
                if (combo.Name.Equals(cboTipoTitulo.Name))
                {
                    Model.TipoTituloLargeData.Filter = cboTipoTitulo.DisplayText;
                }
            }
        }
    }
}
