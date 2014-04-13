using System.Windows.Input;
using Erp.Enum;
using Erp.View.Model.Forms.Pessoa;

namespace Erp.View.Forms.Pessoa
{
    /// <summary>
    /// Interaction logic for SelecaoTipoPessoaView.xaml
    /// </summary>
    public partial class TipoPessoaSelectView 
    {
        public TipoPessoaSelectView(TipoCadastroPessoa tipoCadastro)
        {
            InitializeComponent();
            ((TipoCadastroSelectFormModel) DataContext).TipoCadastroPessoa = tipoCadastro;
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
