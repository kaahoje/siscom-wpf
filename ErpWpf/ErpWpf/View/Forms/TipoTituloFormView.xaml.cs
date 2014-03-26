using System.Windows;
using System.Windows.Input;
using DevExpress.Xpf.Grid.LookUp;
using Erp.Business.Entity.Contabil;
using Erp.Model.Forms;

namespace Erp.View.Forms
{
    /// <summary>
    /// Interaction logic for TipoTituloFormView.xaml
    /// </summary>
    public partial class TipoTituloFormView
    {
        public TipoTituloFormModel Model
        {
            get { return (TipoTituloFormModel)DataContext; }
        }

        private FormDefaultActions<TipoTitulo> Actions { get; set; }
        public TipoTituloFormView()
        {
            InitializeComponent();
            DataContext = new TipoTituloFormModel();
            RestCommands.DataContext = DataContext;
            Actions = new FormDefaultActions<TipoTitulo>(this) { IsEnableShortcuts = false };

        }

        private void UIElement_OnPreviewKeyUp(object sender, KeyEventArgs e)
        {
            var combo = sender as LookUpEdit;

            if (combo != null)
            {
                if (cboValorPartida.Name == combo.Name)
                {
                    Model.ContaValorPartida.Filter = cboValorPartida.DisplayText;
                }
                if (cboValorContraPartida.Name == combo.Name)
                {
                    Model.ContaValorContraPartida.Filter = cboValorContraPartida.DisplayText;
                }
                if (cboAcrescimosPartida.Name == combo.Name)
                {
                    Model.ContaAcrescimoPartida.Filter = cboAcrescimosPartida.DisplayText;
                }
                if (cboAcrescimosContraPartida.Name == combo.Name)
                {
                    Model.ContaAcrescimoContraPartida.Filter = cboAcrescimosContraPartida.DisplayText;
                }
                if (cboDescontoPartida.Name == combo.Name)
                {
                    Model.ContaDescontoPartida.Filter = cboDescontoPartida.DisplayText;
                }
                if (cboDescontoContraPartida.Name == combo.Name)
                {
                    Model.ContaDescontoContraPartida.Filter = cboDescontoContraPartida.DisplayText;
                }
            }
        }


        private void CboDescontoContraPartida_OnGotFocus(object sender, RoutedEventArgs e)
        {
            ResetPlanoConta();
        }

        private void ResetPlanoConta()
        {

        }

        private void CboDescontoPartida_OnGotFocus(object sender, RoutedEventArgs e)
        {
            ResetPlanoConta();
        }

        private void CboAcrescimosContraPartida_OnGotFocus(object sender, RoutedEventArgs e)
        {
            ResetPlanoConta();
        }

        private void CboAcrescimosPartida_OnGotFocus(object sender, RoutedEventArgs e)
        {
            ResetPlanoConta();
        }

        private void CboValorContraPartida_OnGotFocus(object sender, RoutedEventArgs e)
        {
            ResetPlanoConta();
        }

        private void CboValorPartida_OnGotFocus(object sender, RoutedEventArgs e)
        {
            ResetPlanoConta();
        }
    }
}
