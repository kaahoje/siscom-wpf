using System;
using System.Diagnostics;
using System.Windows.Forms;
using DevExpress.XtraEditors;
using Erp.Business;
using Erp.Business.Entity.Contabil.Pessoa.SubClass.PessoaFisica;

namespace WindowsControls.Forms
{
    public partial class FormLogin : XtraForm
    {
        public FormLogin()
        {
            InitializeComponent();
            
        }

        

        private void FormLogin_FormClosed(object sender, FormClosedEventArgs e)
        {
            if (Util.Utils.UsuarioAtual == null)
            {
                Process.GetCurrentProcess().Kill();
            }
        }

        private void cmdCancelar_Click(object sender, EventArgs e)
        {
            Process.GetCurrentProcess().Kill();
        }

        private void cmdOk_Click(object sender, EventArgs e)
        {
            try
            {
                if (usuarioTextEdit.Text.Equals(""))
                {
                    MessageBox.Show("Informe o usuário.", "Atenção");
                    return;
                }
                if (senhaTextEdit.Text.Equals(""))
                {
                    MessageBox.Show("Informe a senha.", "Atenção");
                    return;
                }

                if (PessoaFisicaRepository.AutenticarUsuario(usuarioTextEdit.Text,senhaTextEdit.Text))
                {
                    Hide();
                }
                
            }
            catch (Exception ex)
            {

                MessageBox.Show("Erro ao fazer login." + ex.Message);
            }
            
        }

        private void cmdConfiguracoes_Click(object sender, EventArgs e)
        {
            
        }

        private void FormLogin_Load(object sender, EventArgs e)
        {
            if (Utils.UsuarioAtual != null)
            {
                Close();
            }
        }


        public bool AcessarTelaVenda()
        {
            return rdiTipoTelaVenda.SelectedIndex == 0;
        }

        public bool AcessarMenuFiscal()
        {
            return rdiTipoTelaVenda.SelectedIndex == 1;
        }

        public void MostraOpcoesVenda()
        {
            rdiTipoTelaVenda.Visible = true;
        }

        private void FormLogin_KeyDown(object sender, KeyEventArgs e)
        {
        }
    }
}