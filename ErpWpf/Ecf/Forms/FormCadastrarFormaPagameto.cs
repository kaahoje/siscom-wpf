using System;
using WindowsControls.Forms;

namespace Ecf.Forms
{
    public partial class FormCadastrarFormaPagameto : FormDefault
    {
        public FormCadastrarFormaPagameto()
        {
            InitializeComponent();
        }

        private void cmdSair_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void cmdCadastrar_Click(object sender, EventArgs e)
        {
            EcfHelper.Ecf.CadastrarFormaPagamento(txtFormaPag.Text);
        }
    }
}
