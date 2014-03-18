using System;
using System.Windows.Forms;
using DevExpress.XtraEditors;

namespace Ecf.Forms
{
    public delegate void TransferirMesaEventHandler(object sender, EventArgs e);

    public delegate void MesasAbertasEventHandler(object sender, EventArgs e);

    public partial class FormMenuFiscal : XtraForm
    {
        private MenuFiscalTipo Tipo { get; set; }
        public FormMenuFiscal(MenuFiscalTipo tipo)
        {
            InitializeComponent();
            EcfHelper.Ecf.VerificaImpressora();
            Tipo = tipo;
        }

        #region Eventos

        public event TransferirMesaEventHandler TransferirMesa;

        protected virtual void OnTransferirMesa()
        {
            TransferirMesaEventHandler handler = TransferirMesa;
            if (handler != null) handler(this, EventArgs.Empty);
        }

        public event MesasAbertasEventHandler MesasAbertas;

        protected virtual void OnMesasAbertas()
        {
            MesasAbertasEventHandler handler = MesasAbertas;
            if (handler != null) handler(this, EventArgs.Empty);
        }

        #endregion

        private void cmdLeituraX_Click(object sender, System.EventArgs e)
        {
            EcfHelper.Ecf.ImprimeLeituraX();
        }

        private void cmdLMFC_Click(object sender, System.EventArgs e)
        {
            new FormLeituraMemoriaFiscal(FormLeituraMemoriaFiscal.TipoDocumento.LeituraMemoriaFiscal).ShowDialog();
        }

        private void cmdLMFS_Click(object sender, System.EventArgs e)
        {
            new FormLeituraMemoriaFiscal(FormLeituraMemoriaFiscal.TipoDocumento.LeituraMemoriaFiscal).ShowDialog();
        }

        private void cmdEspelhoMDF_Click(object sender, System.EventArgs e)
        {
            new FormLeituraMemoriaFiscal(FormLeituraMemoriaFiscal.TipoDocumento.EspelhoMfd).ShowDialog();
        }

        private void cmdEncerrantes_Click(object sender, System.EventArgs e)
        {
            MessageBox.Show(AbstractEcf.MensagemNaoSuportada);
        }

        private void cmdTransfMesas_Click(object sender, EventArgs e)
        {
            if (Tipo == MenuFiscalTipo.Restaurante)
            {
                OnTransferirMesa();
            }
            else
            {
                MessageBox.Show(AbstractEcf.MensagemNaoSuportada);
            }
            
        }

        private void cmdMesasAbertas_Click(object sender, EventArgs e)
        {
            if (Tipo == MenuFiscalTipo.Restaurante)
            {
                OnMesasAbertas();
            }
            else
            {
                MessageBox.Show(AbstractEcf.MensagemNaoSuportada);
            }
            
        }

        private void cmdManifestoFiscalViagem_Click(object sender, EventArgs e)
        {
            MessageBox.Show(AbstractEcf.MensagemNaoSuportada);
        }

        private void cmdArquivoMDF_Click(object sender, EventArgs e)
        {
            new FormLeituraMemoriaFiscal(FormLeituraMemoriaFiscal.TipoDocumento.ArquivoMfd).ShowDialog();
        }

        private void cmdCadAliquota_Click(object sender, EventArgs e)
        {
            new FormCadastrarAliquota().ShowDialog();
        }

        private void mnuFuncoesFiscaisAdicionais_Click(object sender, EventArgs e)
        {
            new FormCadastrarFormaPagameto().ShowDialog();
        }

        private void cmdReducaoZ_Click(object sender, EventArgs e)
        {
            EcfHelper.Ecf.ImprimeReducaoZ();
        }
        public enum MenuFiscalTipo
        {
            Auditoria,
            Mercearia,
            Restaurante
        }

        private void cmdDavEmitido_Click(object sender, EventArgs e)
        {
            MessageBox.Show(AbstractEcf.MensagemNaoSuportada);
        }

        private void cmdCancelarUltimaVenda_Click(object sender, EventArgs e)
        {
            EcfHelper.Ecf.CancelarCupom();
        }

        private void cmdAliquotasCadastradas_Click(object sender, EventArgs e)
        {
            try
            {
                EcfHelper.Ecf.ExibeAliquotasCadastradas();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Erro ao exibir alíquotas.");
            }
            
        }

        private void cmdCadastrarAliquota_Click(object sender, EventArgs e)
        {
            new FormCadastrarAliquota().ShowDialog();
        }
    }
}