using System.Windows;
using System.Windows.Input;
using DevExpress.Xpf.Grid.LookUp;
using Erp.Business.Entity.Contabil.Pessoa.SubClass.PessoaFisica.SubClass.ParceiroNegocio.ClassesRelacionadas;
using Erp.Model.Forms.CustoFixo.PessoaFisica.ParceiroNegocioPessoaFisica;

namespace Erp.View.Forms.CustoFixo.PessoaFisica.ParceiroNegocioPessoaFisica
{
    /// <summary>
    /// Interaction logic for CustoFixoParceiroNegocioPessoaFisicaFormView.xaml
    /// </summary>
    public partial class CustoFixoParceiroNegocioPessoaFisicaFormView 
    {
        CustoFixoParceiroNegocioPessoaFisicaFormModel Model { get { return (CustoFixoParceiroNegocioPessoaFisicaFormModel) DataContext; } }
        private FormDefaultActions<CustoFixoParceiroNegocioPessoaFisica> Actions { get; set; }
        public CustoFixoParceiroNegocioPessoaFisicaFormView()
        {
            InitializeComponent();
            DataContext = new CustoFixoParceiroNegocioPessoaFisicaFormModel();
            RestCommands.DataContext = DataContext;
            Actions = new FormDefaultActions<CustoFixoParceiroNegocioPessoaFisica>(this, spnDia) { IsEnableShortcuts = false };
            
        }
        private void UIElement_OnPreviewKeyUp(object sender, KeyEventArgs e)
        {
            var combo = sender as LookUpEdit;
            if (combo != null)
            {
                if (combo.Name.Equals(cboPessoa.Name))
                {
                    Model.ParceiroNegocioPessoaFisicaLargeData.Filter = combo.DisplayText;
                }
                if (combo.Name.Equals(cboTipoTitulo.Name))
                {
                    Model.TipoTituloLargeData.Filter = combo.DisplayText;
                }
            }
        }

        private void CustoFixoParceiroNegocioPessoaFisicaFormView_OnLoaded(object sender, RoutedEventArgs e)
        {
            
        }
    }
}
