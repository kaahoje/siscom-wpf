using WindowsControls.Forms;

namespace Ecf.Forms
{
    public partial class FormLeituraMemoriaFiscal : FormDefault
    {
        private TipoDocumento Tipo { get; set; }
        public FormLeituraMemoriaFiscal(TipoDocumento tipo)
        {
            InitializeComponent();
            Tipo = tipo;
            switch (tipo)
            {
                case TipoDocumento.EspelhoMfd:
                    gerarArquivoSimpleButton.Visible = false;
                    Text = "Espelho Mfd";
                    tipoLeituraGroupBox.Visible = false;
                    imprimirLeituraSimpleButton.Text = "Gerar espelho Mfd";
                    tipoIntervaloRadioGroup.Properties.Items[1].Description = "COO";
                    break;
                case TipoDocumento.ArquivoMfd:
                    gerarArquivoSimpleButton.Visible = false;
                    Text = "Arquivo Mfd";
                    tipoLeituraGroupBox.Visible = false;
                    imprimirLeituraSimpleButton.Text = "Gerar arquivo Mfd";
                    break;
                case TipoDocumento.LeituraMemoriaFiscal:

                    break;
            }
        }

        private void gerarArquivoSimpleButton_Click(object sender, System.EventArgs e)
        {
            if (tipoLeituraRadioGroup.SelectedIndex == 0)
            {if (tipoIntervaloRadioGroup.SelectedIndex == 0)
                {
                    EcfHelper.Ecf.LeituraMemoriaFiscalSerialCompletaData(
                        inicioDateEdit.DateTime,
                        fimDateEdit.DateTime);
                }
                if (tipoIntervaloRadioGroup.SelectedIndex == 1)
                {
                    EcfHelper.Ecf.LeituraMemoriaFiscalSerialCompletaCrz(
                        (int)inicioSpinEdit.EditValue,
                        (int)fimSpinEdit.EditValue);
                }
            }
            if (tipoLeituraRadioGroup.SelectedIndex == 1)
            {
                if (tipoIntervaloRadioGroup.SelectedIndex == 0)
                {
                    EcfHelper.Ecf.LeituraMemoriaFiscalSerialSimplificadaData(
                        inicioDateEdit.DateTime,
                        fimDateEdit.DateTime);
                }
                if (tipoIntervaloRadioGroup.SelectedIndex == 1)
                {
                    EcfHelper.Ecf.LeituraMemoriaFiscalSerialSimplificadaCrz(
                        (int)inicioSpinEdit.EditValue,
                        (int)fimSpinEdit.EditValue);
                }
            }
        }

        private void imprimirLeituraSimpleButton_Click(object sender, System.EventArgs e)
        {
            switch (Tipo)
            {
                case TipoDocumento.ArquivoMfd:
                    ArquivoMfd();
                    break;
                case TipoDocumento.EspelhoMfd:
                    EspelhoMfd();
                    break;
                case TipoDocumento.LeituraMemoriaFiscal:
                    LeituraMemoriaFiscal();
                    break;
            }
        }

        private void EspelhoMfd()
        {
            if (tipoIntervaloRadioGroup.SelectedIndex == 0)
            {
                EcfHelper.Ecf.EspelhoMfdData(inicioDateEdit.DateTime, fimDateEdit.DateTime);
            }
            else
            {
                EcfHelper.Ecf.EspelhoMfdCrz((int)inicioSpinEdit.Value, (int)fimSpinEdit.Value);
            }
        }

        private void ArquivoMfd()
        {
            if (tipoIntervaloRadioGroup.SelectedIndex == 0)
            {
                EcfHelper.Ecf.ArquivoMfdData(inicioDateEdit.DateTime, fimDateEdit.DateTime);
            }
            else
            {
                EcfHelper.Ecf.ArquivoMfdCrz((int)inicioSpinEdit.Value, (int)fimSpinEdit.Value);
            }
        }

        private void LeituraMemoriaFiscal()
        {
            if (tipoLeituraRadioGroup.SelectedIndex == 0)
            {
                if (tipoIntervaloRadioGroup.SelectedIndex == 0)
                {
                    EcfHelper.Ecf.LeituraMemoriaFiscalSerialCompletaData(
                        inicioDateEdit.DateTime,
                        fimDateEdit.DateTime);
                }
                if (tipoIntervaloRadioGroup.SelectedIndex == 1)
                {
                    EcfHelper.Ecf.LeituraMemoriaFiscalSerialCompletaCrz(
                        (int)inicioSpinEdit.EditValue,
                        (int)fimSpinEdit.EditValue);
                }
            }
            if (tipoLeituraRadioGroup.SelectedIndex == 1)
            {
                if (tipoIntervaloRadioGroup.SelectedIndex == 0)
                {
                    EcfHelper.Ecf.LeituraMemoriaFiscalSerialSimplificadaData(
                        inicioDateEdit.DateTime,
                        fimDateEdit.DateTime);
                }
                if (tipoIntervaloRadioGroup.SelectedIndex == 1)
                {
                    EcfHelper.Ecf.LeituraMemoriaFiscalSerialSimplificadaCrz(
                        (int)inicioSpinEdit.EditValue,
                        (int)fimSpinEdit.EditValue);
                }
            }
        }
        public enum TipoDocumento
        {
            LeituraMemoriaFiscal,
            EspelhoMfd,
            ArquivoMfd
        }

        private void fecharSimpleButton_Click(object sender, System.EventArgs e)
        {
            Close();
        }
    }
}