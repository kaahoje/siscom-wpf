using System.Windows.Forms;
using DevExpress.XtraEditors;
using Ecf.Dicionary;
using Ecf.Enum;

namespace Ecf.Forms
{
    public partial class FormCadastrarAliquota : XtraForm
    {
        public FormCadastrarAliquota()
        {
            InitializeComponent();
            
            tipoAliquotaDicionaryBindingSource.DataSource = new TipoAliquotaDicionary();
            LerAliquotas();
        }

        private void LerAliquotas()
        {
            lstAliquotas.Items.Clear();
            var aliquotas = EcfHelper.Ecf.ExibeAliquotasCadastradas();
            foreach (var aliquota in aliquotas)
            {
                lstAliquotas.Items.Add(aliquota.Valor);
            }
        }

        private void cmdCadastrar_Click(object sender, System.EventArgs e)
        {
            var tipo = (TipoAliquota) cboTipoAliquota.EditValue;
            if (EcfHelper.Ecf.CadastrarAliquota(txtAliquota.Value,tipo))
            {
                MessageBox.Show("Alíquota cadastrada com sucesso.");
            }
            LerAliquotas();
        }

        private void cmdSair_Click(object sender, System.EventArgs e)
        {
            Close();
        }
    }
}
