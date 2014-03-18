using System;
using System.Windows.Forms;
using DevExpress.XtraEditors;

namespace WindowsControls.Forms
{
    public partial class FormDataLancamento : XtraForm
    {
        public FormDataLancamento(DateTime dataTitulo)
        {
            InitializeComponent();
            dataLancamentoDateEdit.DateTime = dataTitulo;
        }

        private void FormDataLancamento_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyData == Keys.Enter)
            {
                DialogResult = DialogResult.OK;
                Hide();
            }
            if (e.KeyData == Keys.Escape)
            {
                DialogResult = DialogResult.Cancel;
                Hide();
            }
        }

        public DateTime DataLancamento()
        {
            return dataLancamentoDateEdit.DateTime;
        }

        public static DateTime? DataLancamento(DateTime dataTitulo)
        {
            var d = new FormDataLancamento(dataTitulo);
            d.ShowDialog();
            if (d.DialogResult == DialogResult.Cancel)
            {
                return null;
            }
            return d.DataLancamento();
        }
    }
}