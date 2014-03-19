using System;
using System.Windows.Forms;
using WindowsControls.Forms;

namespace WindowsControls.Controls
{
    public class CommandUpdate : CommandBase
    {
        public CommandUpdate()
        {
            InitializeComponent();
        }

        private void InitializeComponent()
        {
            SuspendLayout();
            // 
            // CommandInsert
            // 
            Atalho = Keys.F8;
            KeyDown += CommandInsert_KeyDown;
            ResumeLayout(false);
            Text = "Alterar";
        }

        private void CommandInsert_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyData == Atalho)
            {
                UpdateObject();
            }
        }

        private void UpdateObject()
        {
            BeforeOperation();
            try
            {
                Form.Form.DialogResult = DialogResult.None;
                Form.FormState = FormState.Updating;
                Form.Form.Activated += Form_Activated;
                Form.Update(Form.CurrentObject);
            }
            catch (Exception ex)
            {
                ExibeErro("Erro ao atualizar item.\n" + ex.Message);
            }
            AfterOperation();
        }

        private void Form_Activated(object sender, EventArgs e)
        {
            AfterOperation();
        }

        public override void Actived()
        {
            //if (Form == null)
            //{
            //    return;
            //}
            //PermissaoForm perm = SegurancaUtils.GetPermissaoForm(Form.Form.Name);
            //if (Form != null && Form.Permissao != null && perm.PermissaoUpdate)
            //{
            //    Enabled = true;
            //}
            //else
            //{
            //    Enabled = false;
            //}
        }
    }
}