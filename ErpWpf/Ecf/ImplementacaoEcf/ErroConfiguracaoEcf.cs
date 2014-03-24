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
            
            return null;
        }

        public override string FormataPercentual(decimal valor)
        {
            
            return null;
        }

        public override decimal ToDecimal(string valor)
        {
            
            return 0;
        }

        public override DateTime ToDate(string valor)
        {
            
            return new DateTime(1);
        }

        public override string FormataData(DateTime data)
        {
            
            return "";
        }

        public override string FormataHora(DateTime hora)
        {
            
            return "";
        }

        public override string FormataCrz(int numero)
        {
            
            return null;
        }

        public override int UltimoCupomEmitido()
        {
            
            return 0;
        }

        public override bool AbrirCupom(ClienteCupom cliente)
        {
             return false;
        }

        public override bool VenderItem(SituacaoTributaria cargaTributaria, TipoProduto tipoProduto, decimal quantidade, decimal precoUnitario,
            TipoDescontoAcressimo tipoDescontoAcressimo, decimal valorDescontoAcressimo, int codigoItem, string unidadeMedida,
            string descricaoItem, decimal tributacao)
        {
             return false;

        }


        protected override string PrefixoImposto(SituacaoTributaria situacaoTributaria, TipoProduto tipoProduto)
        {
            
            return "";
        }

        public override bool LancarDescontoItem(int numeroItem, TipoDescontoAcressimo tipoDesconto, decimal valorDesconto)
        {
             return false;
        }

        public override bool LancarAcressimoItem(int numeroItem, TipoDescontoAcressimo tipoDescontoAcressimo, decimal valorAcressimo)
        {
             return false;
        }

        public override bool LancarDescontoUltimoItem(TipoDescontoAcressimo tipoDesconto, decimal valorDesconto)
        {
             return false;
        }

        public override bool LancarAcressimoUltimoItem(TipoDescontoAcressimo tipoDescontoAcressimo, decimal valorAcressimo)
        {
             return false;
        }

        public override bool CancelarItem(int numeroItem)
        {
             return false;
        }

        public override bool CancelarDescontoItem(int numeroItem)
        {
             return false;
        }

        public override bool CancelaDescontoUltimoItem()
        {
             return false;
        }

        public override bool CancelaAcressimoItem(int numeroItem)
        {
             return false;
        }

        public override bool CancelaAcressimoUltimoItem()
        {
             return false;
        }

        public override bool CancelarDescontoSubTotal()
        {
             return false;
        }

        public override bool CancelarAcressimoSubTotal()
        {
             return false;
        }

        public override bool CancelaItemParcial(int numeroItem, decimal quantidade)
        {
             return false;
        }

        public override bool CancelarUltimoItem()
        {
             return false;
        }

        public override bool CancelarUltimoItemParcial(decimal quantidade)
        {
             return false;
        }

        public override bool IniciaFechamentoCupom(TipoDescontoAcressimo tipoDescAcresc, decimal desconto, decimal acrescimo)
        {
             return false;
        }

        public override bool TotalizarCupomFiscal(TipoDescontoAcressimo tipoDescontoAcressimo, decimal valorDescontoAcressimo)
        {
             return false;
        }

        public override bool EfetuarPagamento(string formaPagamento, decimal valor, string informacaoAdicional)
        {
             return false;
        }

        public override bool EfetuarPagamento(string formaPagamento, decimal valor)
        {
             return false;
        }

        public override bool EfetuarPagamentoPadrao()
        {
             return false;
        }

        public override bool ExtornarPagamento(string formaPagamentoEstornado, string formaPagamento, decimal valor, string informacaoAdicional)
        {
             return false;
        }

        public override bool IdentificaConsumidor(ClienteCupom cliente)
        {
             return false;
        }

        public override bool EncerrarCupom()
        {
             return false;
        }

        public override bool EncerrarCupom(CupomFiscalAdicional cupomFiscalAdicional, string mensagem)
        {
             return false;
        }

        public override bool EncerrarCupom(string mensagem)
        {
             return false;
        }

        public override bool CancelarCupom()
        {
             return false;
        }

        public override bool EmitirCupomAdicional()
        {
             return false;
        }

        public override decimal SaldoAtualCupomFiscal()
        {
             
            return 0;
        }

        public override decimal SubTotalCupomFiscal()
        {
             
            return 0;
        }

        public override StatusCupomFiscal VerificaStatusCupomFiscal()
        {
             
            return StatusCupomFiscal.NaoIniciado;
        }

        public override bool TotalIcmsIssUltimoCupom(ref decimal icms, ref decimal iss)
        {
             return false;
        }

        public override bool ImprimeLeituraX()
        {
             return false;
        }

        public override bool ImprimeLeituraX(decimal caixaInicial)
        {
            try
            {
                
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
             return false;
        }

        public override bool LeituraMemoriaFiscalSimplificadaData(DateTime inicio, DateTime fim)
        {
             return false;
        }

        public override bool LeituraMemoriaFiscalSimplificadaCrz(int inicio, int fim)
        {
             return false;
        }

        public override bool LeituraMemoriaFiscalCompletaData(DateTime inicio, DateTime fim)
        {
             return false;
        }

        public override bool LeituraMemoriaFiscalCompletaCrz(int inicio, int fim)
        {
             return false;
        }

        public override bool LeituraMemoriaFiscalSerialSimplificadaData(DateTime inicio, DateTime fim)
        {
             return false;
        }

        public override bool LeituraMemoriaFiscalSerialSimplificadaCrz(int inicio, int fim)
        {
             return false;
        }

        public override bool LeituraMemoriaFiscalSerialCompletaData(DateTime inicio, DateTime fim)
        {
             return false;
        }

        public override bool LeituraMemoriaFiscalSerialCompletaCrz(int inicio, int fim)
        {
             return false;
        }

        public override bool Sangria(decimal valor, string mensagem)
        {
             return false;
        }

        public override bool Suprimento(decimal valor, string mensagem)
        {
             return false;
        }

        public override bool ImprimeConfiguracao()
        {
             return false;
        }

        public override bool ImprimeReducaoZ()
        {
             return false;
        }

        public override bool ImprimeRelatorioGerencial(string texto)
        {
             return false;
        }

        public override decimal VendaBruta()
        {
            
            return 0;
        }

        public override decimal VendaLiquida()
        {
            
            return 0;
        }

        public override void ReducaoZPendente()
        {
            
        }

        public override DateTime DataMovimento()
        {
            
            return new DateTime(1);
        }

        public override DateTime DataUltimaReducaoZ()
        {
            
            return new DateTime(1);
        }

        public override bool EspelhoMfdData(DateTime inicio, DateTime fim)
        {
             return false;
        }

        public override bool EspelhoMfdCrz(int inicio, int fim)
        {
             return false;
        }

        public override bool ArquivoMfdData(DateTime inicio, DateTime fim)
        {
             return false;
        }

        public override bool ArquivoMfdCrz(int inicio, int fim)
        {
             return false;
        }

        public override bool TravaTeclado()
        {
             return false;
        }

        public override bool DestravaTeclado()
        {
             return false;
        }

        public override RetornoTef EnviarSolicitacao(IList<Pagamento> pagamentos)
        {
             
            return RetornoTef.Erro;
        }

        public override bool ImprimirTef()
        {
             return false;
        }

        public override bool VerificaImpressora()
        {
            return true;
        }

        public override IList<Aliquota> ExibeAliquotasCadastradas()
        {
            
            return null;
        }

        public override ReducaoZ UltimaReducaoZ()
        {
            
            return null;
        }

        public override bool ImpressoraLigada()
        {
            
            return false;
        }


        public override bool CadastrarAliquota(decimal aliquota, TipoAliquota tipoAliquota)
        {
             return false;
        }

        public override bool CadastrarFormaPagamento(string formaPagamento)
        {
             return false;
        }
    }
}
