using System;
using System.Collections.Generic;
using System.Windows.Forms;
using Ecf.Enum;
using Ecf.ImplementacaoEcf.ClassesRelacionadas;
using Erp.Business.Entity.Vendas.Ecf;
using Erp.Business.Enum;

namespace Ecf.ImplementacaoEcf
{
    internal class ErroConfiguracaoEcf : AbstractEcf
    {
        private const string MensagemErro = "Terminal não configurado";
        public override object FormataNumero(decimal valor)
        {
            MessageBox.Show(MensagemErro);
            return null;
        }

        public override string FormataPercentual(decimal valor)
        {
            MessageBox.Show(MensagemErro);
            return null;
        }

        public override decimal ToDecimal(string valor)
        {
            MessageBox.Show(MensagemErro);
            return 0;
        }

        public override DateTime ToDate(string valor)
        {
            MessageBox.Show(MensagemErro);
            return new DateTime(1);
        }

        public override string FormataData(DateTime data)
        {
            MessageBox.Show(MensagemErro);
            return "";
        }

        public override string FormataHora(DateTime hora)
        {
            MessageBox.Show(MensagemErro);
            return "";
        }

        public override string FormataCrz(int numero)
        {
            MessageBox.Show(MensagemErro);
            return null;
        }

        public override int UltimoCupomEmitido()
        {
            MessageBox.Show(MensagemErro);
            return 0;
        }

        public override bool AbrirCupom(ClienteCupom cliente)
        {
            MessageBox.Show(MensagemErro); return false;
        }

        public override bool VenderItem(SituacaoTributaria cargaTributaria, TipoProduto tipoProduto, decimal quantidade, decimal precoUnitario,
            TipoDescontoAcressimo tipoDescontoAcressimo, decimal valorDescontoAcressimo, int codigoItem, string unidadeMedida,
            string descricaoItem, decimal tributacao)
        {
            MessageBox.Show(MensagemErro); return false;

        }


        protected override string PrefixoImposto(SituacaoTributaria situacaoTributaria, TipoProduto tipoProduto)
        {
            MessageBox.Show(MensagemErro);
            return "";
        }

        public override bool LancarDescontoItem(int numeroItem, TipoDescontoAcressimo tipoDesconto, decimal valorDesconto)
        {
            MessageBox.Show(MensagemErro); return false;
        }

        public override bool LancarAcressimoItem(int numeroItem, TipoDescontoAcressimo tipoDescontoAcressimo, decimal valorAcressimo)
        {
            MessageBox.Show(MensagemErro); return false;
        }

        public override bool LancarDescontoUltimoItem(TipoDescontoAcressimo tipoDesconto, decimal valorDesconto)
        {
            MessageBox.Show(MensagemErro); return false;
        }

        public override bool LancarAcressimoUltimoItem(TipoDescontoAcressimo tipoDescontoAcressimo, decimal valorAcressimo)
        {
            MessageBox.Show(MensagemErro); return false;
        }

        public override bool CancelarItem(int numeroItem)
        {
            MessageBox.Show(MensagemErro); return false;
        }

        public override bool CancelarDescontoItem(int numeroItem)
        {
            MessageBox.Show(MensagemErro); return false;
        }

        public override bool CancelaDescontoUltimoItem()
        {
            MessageBox.Show(MensagemErro); return false;
        }

        public override bool CancelaAcressimoItem(int numeroItem)
        {
            MessageBox.Show(MensagemErro); return false;
        }

        public override bool CancelaAcressimoUltimoItem()
        {
            MessageBox.Show(MensagemErro); return false;
        }

        public override bool CancelarDescontoSubTotal()
        {
            MessageBox.Show(MensagemErro); return false;
        }

        public override bool CancelarAcressimoSubTotal()
        {
            MessageBox.Show(MensagemErro); return false;
        }

        public override bool CancelaItemParcial(int numeroItem, decimal quantidade)
        {
            MessageBox.Show(MensagemErro); return false;
        }

        public override bool CancelarUltimoItem()
        {
            MessageBox.Show(MensagemErro); return false;
        }

        public override bool CancelarUltimoItemParcial(decimal quantidade)
        {
            MessageBox.Show(MensagemErro); return false;
        }

        public override bool IniciaFechamentoCupom(TipoDescontoAcressimo tipoDescAcresc, decimal desconto, decimal acrescimo)
        {
            MessageBox.Show(MensagemErro); return false;
        }

        public override bool TotalizarCupomFiscal(TipoDescontoAcressimo tipoDescontoAcressimo, decimal valorDescontoAcressimo)
        {
            MessageBox.Show(MensagemErro); return false;
        }

        public override bool EfetuarPagamento(string formaPagamento, decimal valor, string informacaoAdicional)
        {
            MessageBox.Show(MensagemErro); return false;
        }

        public override bool EfetuarPagamento(string formaPagamento, decimal valor)
        {
            MessageBox.Show(MensagemErro); return false;
        }

        public override bool EfetuarPagamentoPadrao()
        {
            MessageBox.Show(MensagemErro); return false;
        }

        public override bool ExtornarPagamento(string formaPagamentoEstornado, string formaPagamento, decimal valor, string informacaoAdicional)
        {
            MessageBox.Show(MensagemErro); return false;
        }

        public override bool IdentificaConsumidor(ClienteCupom cliente)
        {
            MessageBox.Show(MensagemErro); return false;
        }

        public override bool EncerrarCupom()
        {
            MessageBox.Show(MensagemErro); return false;
        }

        public override bool EncerrarCupom(CupomFiscalAdicional cupomFiscalAdicional, string mensagem)
        {
            MessageBox.Show(MensagemErro); return false;
        }

        public override bool EncerrarCupom(string mensagem)
        {
            MessageBox.Show(MensagemErro); return false;
        }

        public override bool CancelarCupom()
        {
            MessageBox.Show(MensagemErro); return false;
        }

        public override bool EmitirCupomAdicional()
        {
            MessageBox.Show(MensagemErro); return false;
        }

        public override decimal SaldoAtualCupomFiscal()
        {
            MessageBox.Show(MensagemErro); 
            return 0;
        }

        public override decimal SubTotalCupomFiscal()
        {
            MessageBox.Show(MensagemErro); 
            return 0;
        }

        public override StatusCupomFiscal VerificaStatusCupomFiscal()
        {
            MessageBox.Show(MensagemErro); 
            return StatusCupomFiscal.NaoIniciado;
        }

        public override bool TotalIcmsIssUltimoCupom(ref decimal icms, ref decimal iss)
        {
            MessageBox.Show(MensagemErro); return false;
        }

        public override bool ImprimeLeituraX()
        {
            MessageBox.Show(MensagemErro); return false;
        }

        public override bool ImprimeLeituraX(decimal caixaInicial)
        {
            try
            {
                MessageBox.Show(MensagemErro);
                return false;
            }
            catch (Exception ex)
            {
                MessageBox.Show("Erro ao imprimir leitura X.\n" + ex.Message);
                return false;
            }
        }

        public override bool GravaLeituraX()
        {
            MessageBox.Show(MensagemErro); return false;
        }

        public override bool LeituraMemoriaFiscalSimplificadaData(DateTime inicio, DateTime fim)
        {
            MessageBox.Show(MensagemErro); return false;
        }

        public override bool LeituraMemoriaFiscalSimplificadaCrz(int inicio, int fim)
        {
            MessageBox.Show(MensagemErro); return false;
        }

        public override bool LeituraMemoriaFiscalCompletaData(DateTime inicio, DateTime fim)
        {
            MessageBox.Show(MensagemErro); return false;
        }

        public override bool LeituraMemoriaFiscalCompletaCrz(int inicio, int fim)
        {
            MessageBox.Show(MensagemErro); return false;
        }

        public override bool LeituraMemoriaFiscalSerialSimplificadaData(DateTime inicio, DateTime fim)
        {
            MessageBox.Show(MensagemErro); return false;
        }

        public override bool LeituraMemoriaFiscalSerialSimplificadaCrz(int inicio, int fim)
        {
            MessageBox.Show(MensagemErro); return false;
        }

        public override bool LeituraMemoriaFiscalSerialCompletaData(DateTime inicio, DateTime fim)
        {
            MessageBox.Show(MensagemErro); return false;
        }

        public override bool LeituraMemoriaFiscalSerialCompletaCrz(int inicio, int fim)
        {
            MessageBox.Show(MensagemErro); return false;
        }

        public override bool Sangria(decimal valor, string mensagem)
        {
            MessageBox.Show(MensagemErro); return false;
        }

        public override bool Suprimento(decimal valor, string mensagem)
        {
            MessageBox.Show(MensagemErro); return false;
        }

        public override bool ImprimeConfiguracao()
        {
            MessageBox.Show(MensagemErro); return false;
        }

        public override bool ImprimeReducaoZ()
        {
            MessageBox.Show(MensagemErro); return false;
        }

        public override bool ImprimeRelatorioGerencial(string texto)
        {
            MessageBox.Show(MensagemErro); return false;
        }

        public override decimal VendaBruta()
        {
            MessageBox.Show(MensagemErro);
            return 0;
        }

        public override decimal VendaLiquida()
        {
            MessageBox.Show(MensagemErro);
            return 0;
        }

        public override void ReducaoZPendente()
        {
            MessageBox.Show(MensagemErro);
        }

        public override DateTime DataMovimento()
        {
            MessageBox.Show(MensagemErro);
            return new DateTime(1);
        }

        public override DateTime DataUltimaReducaoZ()
        {
            MessageBox.Show(MensagemErro);
            return new DateTime(1);
        }

        public override bool EspelhoMfdData(DateTime inicio, DateTime fim)
        {
            MessageBox.Show(MensagemErro); return false;
        }

        public override bool EspelhoMfdCrz(int inicio, int fim)
        {
            MessageBox.Show(MensagemErro); return false;
        }

        public override bool ArquivoMfdData(DateTime inicio, DateTime fim)
        {
            MessageBox.Show(MensagemErro); return false;
        }

        public override bool ArquivoMfdCrz(int inicio, int fim)
        {
            MessageBox.Show(MensagemErro); return false;
        }

        public override bool TravaTeclado()
        {
            MessageBox.Show(MensagemErro); return false;
        }

        public override bool DestravaTeclado()
        {
            MessageBox.Show(MensagemErro); return false;
        }

        public override RetornoTef EnviarSolicitacao(IList<Pagamento> pagamentos)
        {
            MessageBox.Show(MensagemErro); 
            return RetornoTef.Erro;
        }

        public override bool ImprimirTef()
        {
            MessageBox.Show(MensagemErro); return false;
        }

        public override bool VerificaImpressora()
        {
            return true;
        }

        public override IList<Aliquota> ExibeAliquotasCadastradas()
        {
            MessageBox.Show(MensagemErro);
            return null;
        }

        public override ReducaoZ UltimaReducaoZ()
        {
            MessageBox.Show(MensagemErro);
            return null;
        }

        public override bool ImpressoraLigada()
        {
            MessageBox.Show(MensagemErro);
            return false;
        }


        public override bool CadastrarAliquota(decimal aliquota, TipoAliquota tipoAliquota)
        {
            MessageBox.Show(MensagemErro); return false;
        }

        public override bool CadastrarFormaPagamento(string formaPagamento)
        {
            MessageBox.Show(MensagemErro); return false;
        }
    }
}
