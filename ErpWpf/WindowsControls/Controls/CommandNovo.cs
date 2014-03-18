using System;
using System.Windows.Forms;
using WindowsControls.Forms;

namespace WindowsControls.Controls
{
    public class CommandNovo : CommandBase
    {
        public CommandNovo()
        {
            InitializeComponent();
        }

        private void InitializeComponent()
        {
            SuspendLayout();
            // 
            // CommandDelete
            // 
            Text = "Novo";
            Atalho = Keys.F7;
            Click += CommandDelete_Click;
            KeyDown += CommandInsert_KeyDown;
            ResumeLayout(false);
        }

        private void CommandInsert_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyData == Atalho)
            {
                Novo();
            }
        }

        private void Novo()
        {
            try
            {
                Form.FormState = FormState.Inserting;
                Form.Form.DialogResult = DialogResult.None;
                Form.New();
            }
            catch (Exception ex)
            {
                ExibeErro("Erro ao criar item.\n");
            }
        }

        private void CommandDelete_Click(object sender, EventArgs e)
        {
            Novo();
        }

        public override void Actived()
        {
            //if (Form == null)
            //{
            //    return;
            //}
            //try
            //{
            //    PermissaoForm prem = SegurancaUtils.GetPermissaoForm(Form.Form.Name);
            //    if (Form != null && Form.Permissao != null && prem.PermissaoInsert)
            //    {
            //        Enabled = true;
            //    }
            //    else
            //    {
            //        Enabled = false;
            //    }
            //}
            //catch (Exception)
            //{
            //    Enabled = false;
            //}
        }
    }
}