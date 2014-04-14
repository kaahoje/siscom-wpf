using System.Windows;
using System.Windows.Input;
using DevExpress.Xpf.Grid.LookUp;
using Erp.Business.Entity.Contabil.Pessoa.SubClass.PessoaJuridica.SubClass.ParceiroNegocio.ClassesRelacionadas;
using Erp.Model.Forms.CustoFixo.PessoaJuridica.ParceiroNegocioPessoaJuridica;

namespace Erp.View.Forms.CustoFixo.PessoaJuridica.ParceiroNegocioPessoaJuridica
{
    /// <summary>
    /// Interaction logic for CustoFixoParceiroNegocioPessoaJuridicaFormView.xaml
    /// </summary>
    public partial class CustoFixoParceiroNegocioPessoaJuridicaFormView 
    {
        CustoFixoParceiroNegocioPessoaJuridicaFormModel Model { get { return (CustoFixoParceiroNegocioPessoaJuridicaFormModel) DataContext; } }
        private FormDefaultActions<CustoFixoParceiroNegocioPessoaJuridica> Actions { get; set; }
        public CustoFixoParceiroNegocioPessoaJuridicaFormView()
        {
            InitializeComponent();
            DataContext = new CustoFixoParceiroNegocioPessoaJuridicaFormModel();
            RestCommands.DataContext = DataContext;
            Actions = new FormDefaultActions<CustoFixoParceiroNegocioPessoaJuridica>(this,spnDia) { IsEnableShortcuts = false };
        }

        private void UIElement_OnPreviewKeyUp(object sender, KeyEventArgs e)
        {
            var combo = sender as LookUpEdit;
            if (combo != null)
            {
                if (combo.Name.Equals(cboPessoa.Name))
                {
                    Model.ParceiroNegocioPessoaJuridicaLargeData.Filter = combo.DisplayText;
                }
                if (combo.Name.Equals(cboTipoTitulo.Name))
                {
                    Model.TipoTituloLargeData.Filter = combo.DisplayText;
                }
            }
        }

        private void CustoFixoParceiroNegocioPessoaJuridicaFormView_OnLoaded(object sender, RoutedEventArgs e)
        {
            
        }
    }
}
