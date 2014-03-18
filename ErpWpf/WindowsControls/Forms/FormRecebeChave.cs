using System;
using System.Diagnostics;
using DevExpress.XtraEditors;

namespace WindowsControls.Forms
{
    public partial class FormRecebeChave : XtraForm
    {
        public FormRecebeChave()
        {
            InitializeComponent();
        }

        private void cmdCancelar_Click(object sender, EventArgs e)
        {
            Process.GetCurrentProcess().Kill();
        }

        private void chaveTextEdit_EditValueChanged(object sender, EventArgs e)
        {
        }

        private void cmdGravar_Click(object sender, EventArgs e)
        {
            Close();
        }
    }
}