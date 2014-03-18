using System.Diagnostics;
using System.Windows;
using System.Windows.Input;
using Vendas.ViewModel.Forms;

namespace Vendas.Component.View.Telas
{
    /// <summary>
    /// Interaction logic for LancamentoInicialView.xaml
    /// </summary>
    public partial class LancamentoInicialView 
    {
        private LancamentoInicialModel Model
        {
            get { return (LancamentoInicialModel) DataContext; }
        }

        public LancamentoInicialView()
        {
            InitializeComponent();
            TxtValor.Focus();
            Model.LancamentoEfetuado += Model_LancamentoEfetuado;
            
        }

        void Model_LancamentoEfetuado(object sender, System.EventArgs e)
        {
            Hide();
        }

        private void CmdCancelar_OnClick(object sender, RoutedEventArgs e)
        {
            Process.GetCurrentProcess().Kill();
        }


        private void LancamentoInicialView_OnPreviewKeyDown(object sender, KeyEventArgs e)
        {
            if (e.Key == Key.Escape)
            {
                Hide();
            }
        }

        private void CmdOk_OnClick(object sender, RoutedEventArgs e)
        {
        }
    }
}
