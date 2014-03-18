using System.Windows.Input;

namespace Vendas.Component.View.Telas
{
    /// <summary>
    /// Interaction logic for EcfDadosClienteView.xaml
    /// </summary>
    public partial class EcfDadosClienteView 
    {
        
        public EcfDadosClienteView()
        {
            InitializeComponent();
            CboTipoPessoa.Focus();
        }

        private void EcfDadosClienteView_OnPreviewKeyDown(object sender, KeyEventArgs e)
        {
            if (e.Key == Key.Escape)
            {
                Hide();
            }
        }
    }
}
