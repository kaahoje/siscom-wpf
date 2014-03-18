using System;
using System.Windows.Forms;
using WindowsControls.Forms;

namespace WindowsControls.Controls
{
    public class CommandDelete : CommandBase
    {
        public CommandDelete()
        {
            InitializeComponent();
        }

        private void InitializeComponent()
        {
            SuspendLayout();
            // 
            // CommandDelete
            // 
            Atalho = Keys.F6;
            Text = "Excluir";
            Click += CommandDelete_Click;
            KeyDown += CommandInsert_KeyDown;
            ResumeLayout(false);
        }

        private void CommandInsert_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyData == Atalho)
            {
                Delete();
            }
        }

        private void Delete()
        {
            BeforeOperation();
            try
            {
                string msg = "Deseja realmente excluir este registro";
                if (MessageBox.Show(msg, "Atenção", MessageBoxButtons.YesNo) == DialogResult.Yes)
                {
                    if (Form.Delete(Form.CurrentObject))
                    {
                        Form.Form.DialogResult = DialogResult.OK;
                        Form.Form.Close();
                    }
                    else
                    {
                        Form.Form.DialogResult = DialogResult.OK;
                    }
                }
            }
            catch (Exception ex)
            {
                ExibeErro("Erro ao excluir item.\n");
            }
            AfterOperation();
        }

        private void CommandDelete_Click(object sender, EventArgs e)
        {
            Delete();
        }

        public override void Actived()
        {
            //if (Form == null)
            //{
            //    return;
            //}
            //if (Form.FormState == FormState.Inserting)
            //{
            //    Enabled = false;
            //}
            //PermissaoForm prem = SegurancaUtils.GetPermissaoForm(Form.Form.Name);
            //if (Form != null && Form.Permissao != null && prem.PermissaoDelete)
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