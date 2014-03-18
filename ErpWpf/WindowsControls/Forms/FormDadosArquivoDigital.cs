using System;
using System.Windows.Forms;
using Erp.Business.Entity.GestaoDeArquivos;

namespace WindowsControls.Forms
{
    public partial class FormDadosArquivoDigital : FormDefault
    {
        public FormDadosArquivoDigital()
        {
            InitializeComponent();
        }

        public string GetHistorico()
        {
            return txtHistorico.Text;
        }

        public TipoArquivoDigital GetTipo()
        {
            return (TipoArquivoDigital) cboTipo.EditValue;
        }

        private void cmdCancelar_Click(object sender, EventArgs e)
        {
            DialogResult = DialogResult.Cancel;
            Hide();
        }
    }
}