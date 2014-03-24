using System.Windows.Input;

namespace Erp.View.Forms.Pessoa
{
    /// <summary>
    /// Interaction logic for SelecaoTipoPessoaView.xaml
    /// </summary>
    public partial class TipoPessoaSelectView 
    {
        public TipoPessoaSelectView()
        {
            InitializeComponent();
        }

        private void ParceiroNegocioSelectView_OnPreviewKeyDown(object sender, KeyEventArgs e)
        {
            if (e.Key == Key.Escape)
            {
                Close();
            }
        }
    }
}
