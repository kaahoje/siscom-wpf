using System;
using System.Windows.Forms;
using WindowsControls.Forms;
using Erp.Business.Validation;

namespace WindowsControls.Controls
{
    public class CommandSave : CommandBase
    {
        public CommandSave()
        {
            InitializeComponent();
        }

        private void InitializeComponent()
        {
            SuspendLayout();
            // 
            // CommandInsert
            // 
            Text = "Inserir";
            Atalho = Keys.F7;
            Click += CommandInsert_Click;
            KeyDown += CommandInsert_KeyDown;
            ResumeLayout(false);
        }

        private void CommandInsert_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyData == Atalho)
            {
                Save();
            }
        }

        private void Save()
        {
            BeforeOperation();
            try
            {
                if (Form == null)
                {
                    return;
                }
                EntityValidationResult valid = Form.Validate();
                if (valid.HasError)
                {
                    throw new Exception(valid.MensagemErro());
                }
                Form.Save();
                Form.Form.DialogResult = DialogResult.OK;
                Form.Form.Close();
            }
            catch (Exception ex)
            {
                ExibeErro("Erro ao salvar dados.\n" + ex.Message);
            }
            AfterOperation();
        }

        private void CommandInsert_Click(object sender, EventArgs e)
        {
            Save();
        }

        public override void Actived()
        {
            //if (Form == null)
            //{
            //    return;
            //}
            //PermissaoForm perm = SegurancaUtils.GetPermissaoForm(Form.Form.Name);
            //if (Form.FormState == FormState.Inserting)
            //{
            //    if (Form != null && Form.Permissao != null && perm.PermissaoInsert)
            //    {
            //        Enabled = true;
            //    }
            //    else
            //    {
            //        Enabled = false;
            //    }
            //}
            //if (Form.FormState == FormState.Updating)
            //{
            //    if (Form != null && Form.Permissao != null && perm.PermissaoUpdate)
            //    {
            //        Enabled = true;
            //    }
            //    else
            //    {
            //        Enabled = false;
            //    }
            //}
        }
    }
}