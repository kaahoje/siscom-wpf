using System.Windows.Input;
using DevExpress.Xpf.Grid.LookUp;
using Erp.Business.Entity.Contabil.Pessoa.SubClass.PessoaJuridica.SubClass.ParceiroNegocio.ClassesRelacionadas;
using Erp.Model.Forms.Titulo.PessoaJuridica.ParceiroNegocioPessoaJuridica;

namespace Erp.View.Forms.Titulo.PessoaJuridica.ParceiroNegocioPessoaJuridica
{
    /// <summary>
    /// Interaction logic for TituloParceiroNegocioPessoaJuridicaFormView.xaml
    /// </summary>
    public partial class TituloParceiroNegocioPessoaJuridicaFormView 
    {
        private TituloParceiroNegocioPessoaJuridicaFormModel Model
        {
            get { return (TituloParceiroNegocioPessoaJuridicaFormModel) DataContext; }
        }

        private FormDefaultActions<TituloParceiroNegocioPessoaJuridica> Actions { get; set; }
        public TituloParceiroNegocioPessoaJuridicaFormView()
        {
            InitializeComponent();
            DataContext = new TituloParceiroNegocioPessoaJuridicaFormModel();
            RestCommands.DataContext = DataContext;
            Actions = new FormDefaultActions<TituloParceiroNegocioPessoaJuridica>(this){IsEnableShortcuts = false};
            
        }

        private void UIElement_OnPreviewKeyUp(object sender, KeyEventArgs e)
        {
            var combo = sender as LookUpEdit;
            if (combo != null)
            {
                if (combo.Name.Equals(cboPessoa.Name))
                {
                    Model.ParceiroNegocioPessoaJuridicaLargeData.Filter = cboPessoa.DisplayText;
                }
                if (combo.Name.Equals(cboTipoTitulo.Name))
                {
                    Model.TipoTituloLargeData.Filter = cboTipoTitulo.DisplayText;
                }
            }
        }

    }
}
