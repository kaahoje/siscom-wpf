using System;
using System.Windows.Forms;

namespace WindowsControls.Controls
{
    public class CommandReload : CommandBase
    {
        public CommandReload()
        {
            InitializeComponent();
        }

        private void InitializeComponent()
        {
            SuspendLayout();
            // 
            // CommandDelete
            // 
            Text = "Atualizar";
            Atalho = Keys.F5;
            Click += CommandDelete_Click;
            KeyDown += CommandInsert_KeyDown;
            ResumeLayout(false);
        }

        private void CommandInsert_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyData == Atalho)
            {
                Refresh();
            }
        }

        private void Refresh()
        {
            BeforeOperation();
            try
            {
                Form.Reload();
            }
            catch (Exception ex)
            {
                ExibeErro("Erro ao atualizar item.\n");
            }
            AfterOperation();
        }

        private void CommandDelete_Click(object sender, EventArgs e)
        {
            Refresh();
        }
    }
}