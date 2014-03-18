using System;
using System.Windows.Forms;

namespace WindowsControls.Controls
{
    public class CommandCancel : CommandBase
    {
        public CommandCancel()
        {
            InitializeComponent();
        }

        private void InitializeComponent()
        {
            SuspendLayout();
            // 
            // CommandCancel
            // 
            Anchor = AnchorStyles.Bottom | AnchorStyles.Right;
            Atalho = Keys.Escape;
            Text = "Cancelar(Esc)";
            Click += CommandDelete_Click;
            KeyDown += CommandInsert_KeyDown;
            ResumeLayout(false);
        }

        private void CommandInsert_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyData == Atalho)
            {
                Cancel();
            }
        }

        private void Cancel()
        {
            try
            {
                if (!Enabled)
                {
                    return;
                }
                if (Form.Form.DialogResult != DialogResult.Cancel)
                {
                    try
                    {
                        Form.Reload();
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show("Erro ao recarregar objeto.\n" +
                                        ex.Message);
                    }
                    Form.Cancel();
                }
            }
            catch (Exception ex)
            {
                ExibeErro("Erro ao cancelar edição de item.\n");
            }
        }

        private void CommandDelete_Click(object sender, EventArgs e)
        {
            Cancel();
        }
    }
}