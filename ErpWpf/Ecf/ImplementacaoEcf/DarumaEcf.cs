using System;
using System.Collections.Generic;
using System.Globalization;
using System.IO;
using System.Text;
using System.Windows.Forms;
using Ecf.ImplementacaoEcf.ClassesRelacionadas;
using Ecf.Enum;
using Erp.Business.Entity.Vendas.Ecf;
using Erp.Business.Enum;

namespace Ecf.ImplementacaoEcf
{
    internal class DarumaEcf : AbstractEcf
    {

        public const int CodigoErroComunicacao = 0;
        public const int CodigoSucessoComando = 1;

        public DarumaEcf()
        {
            Declaracoes.eBuscarPortaVelocidade_ECF_Daruma();

            if (LocalArquivosRelatoriosFiscais == null)
            {
                LocalArquivosRelatoriosFiscais = Environment.CurrentDirectory + "\\relatórios fiscais\\";

            }
            if (!Directory.Exists(LocalArquivosRelatoriosFiscais))
            {
                Directory.CreateDirectory(LocalArquivosRelatoriosFiscais);
            }
            VerificaImpressora();
        }

        public String TipoDescontoAcressimoToString(TipoDescontoAcressimo tipoDescontoAcressimo)
        {
            switch (tipoDescontoAcressimo)
            {
                case TipoDescontoAcressimo.AcressimoPercentual:
                    return "A%";
                case TipoDescontoAcressimo.AcressimoValor:
                    return "A$";
                case TipoDescontoAcressimo.DescontoPercentual:
                    return "D%";
                case TipoDescontoAcressimo.DescontoValor:
                    return "D$";
            }
            return "";
        }

        public override string FormataPercentual(decimal valor)
        {
            var val = FormataNumero(valor).ToString().Split(',');
            if (val[0].Length == 1)
            {
                val[0] = "0" + val[0];
            }
            if (val[1].Length > 2)
            {
                val[1] = val[1].Substring(0, 2);
            }
            return val[0] + "," + val[1];
        }

        public override Decimal ToDecimal(String valor)
        {
            valor = valor.Replace(",", ".");
            return Decimal.Parse(valor);
        }

        public override DateTime ToDate(string valor)
        {
            return DateTime.ParseExact(valor, "ddMMyyyy", CultureInfo.InvariantCulture);
        }

        public override string FormataData(DateTime data)
        {
            return data.ToString("ddMMyy");
        }

        public override string FormataHora(DateTime hora)
        {
            return hora.ToString("HHmmss");
        }

        public override string FormataCrz(int numero)
        {
            var ret = "000000" + numero.ToString(CultureInfo.InvariantCulture);
            return ret.Substring(ret.Length - 4);
        }

        public override int UltimoCupomEmitido()
        {
            return 0;
        }


        public String CupomFiscalAdicionalToString(CupomFiscalAdicional cupomAdicional)
        {
            switch (cupomAdicional)
            {
                case CupomFiscalAdicional.NaoImprime:
                    return "0";
                case CupomFiscalAdicional.ImprimeCupomSimplificado:
                    return "1";
                case CupomFiscalAdicional.ImprimeCupomDetalhado:
                    return "2";
                case CupomFiscalAdicional.ImprimeCupomDll:
                    return "3";
            }
            return "";
        }

        public StatusCupomFiscal IntToStatusCupomFiscal(int iStatus)
        {
            var status = StatusCupomFiscal.Fechado;
            switch (iStatus)
            {
                case 0:
                    status = StatusCupomFiscal.Fechado;
                    break;
                case 1:
                    status = StatusCupomFiscal.EmRegistroItem;
                    break;
                case 2:
                    status = StatusCupomFiscal.EmTotalizacao;
                    break;
                case 3:
                    status = StatusCupomFiscal.EmPagamento;
                    break;
                case 4:
                    status = StatusCupomFiscal.EmFinalizacao;
                    break;
                case 5:
                    status = StatusCupomFiscal.Fechado;
                    break;
                case 6:
                    status = StatusCupomFiscal.Fechado;
                    break;
                case 7:
                    status = StatusCupomFiscal.Fechado;
                    break;
                case 8:
                    status = StatusCupomFiscal.Fechado;
                    break;

            }
            return status;
        }

        public String CargaTributariaToString(SituacaoTributaria situacaoTributaria)
        {
            MessageBox.Show(MensagemNaoSuportada);
            return "";
        }

        public override object FormataNumero(decimal valor)
        {
            return valor.ToString(CultureInfo.InvariantCulture).Replace(".", ",");
        }

        public override bool AbrirCupom(ClienteCupom cliente)
        {
            var buf = new StringBuilder();
            var ret = 0;
            if (!TrataRetorno(Declaracoes.rCFVerificarStatus_ECF_Daruma(buf, ref ret)))
            {
                return false;
            }
            if (cliente.CpfCnpj == null)
            {
                cliente.CpfCnpj = "";
            }
            if (cliente.Nome == null)
            {
                cliente.Nome = "";
            }
            if (cliente.Endereco == null)
            {
                cliente.Endereco = "";
            }
            var status = IntToStatusCupomFiscal(ret);
            if (status != StatusCupomFiscal.Fechado)
            {
                MessageBox.Show("Já existe um cupom fiscal aberto.\n" +
                                "O mesmo será cancelado.");
                CancelarCupom();

            }
            Declaracoes.iRetorno = Declaracoes.iCFAbrir_ECF_Daruma(
                cliente.CpfCnpj,
                cliente.Nome,
                cliente.Endereco);
            return TrataRetorno(Declaracoes.iRetorno);
        }

        public override bool VenderItem(SituacaoTributaria cargaTributaria, TipoProduto tipoProduto, decimal quantidade, decimal precoUnitario,
            TipoDescontoAcressimo tipoDescontoAcressimo, decimal valorDescontoAcressimo, int codigoItem, string unidadeMedida,
            string descricaoItem, decimal tributacao)
        {

            string aliquota;
            if (tributacao == 0 && cargaTributaria == SituacaoTributaria.Tributado)
            {
                aliquota = "I";
            }
            else
            {
                aliquota = PrefixoImposto(cargaTributaria, tipoProduto)
                           + FormataPercentual(tributacao);
            }
            if (cargaTributaria == SituacaoTributaria.SubstituicaoTributaria ||
                cargaTributaria == SituacaoTributaria.Isento ||
                cargaTributaria == SituacaoTributaria.NaoTributado)
            {
                aliquota = PrefixoImposto(cargaTributaria, tipoProduto);
            }
            Declaracoes.iRetorno = Declaracoes.iCFVender_ECF_Daruma(
                aliquota,
                AjustarCasasDecimais(FormataNumero(quantidade).ToString(), 3),
                AjustarCasasDecimais(FormataNumero(precoUnitario).ToString(), 2),
                AjustarCasasDecimais(TipoDescontoAcressimoToString(tipoDescontoAcressimo).ToString(), 2),
                AjustarCasasDecimais(FormataNumero(valorDescontoAcressimo).ToString(), 2),
                codigoItem.ToString(CultureInfo.InvariantCulture),
                unidadeMedida,
                descricaoItem
                );
            return TrataRetorno(Declaracoes.iRetorno);
        }

        public String AjustarCasasDecimais(string numero, int casasDecimais)
        {
            var adicionais = "000000000000000000000000000";
            if (numero.Contains(",") || numero.Contains("."))
            {
                var split = numero.Replace(".", ",").Split(',');
                adicionais = split[1] + adicionais;
                return split[0] + "," + adicionais.Substring(0, casasDecimais);
            }
            else
            {
                return numero + "," + adicionais.Substring(0, casasDecimais);
            }

        }

        protected override string PrefixoImposto(SituacaoTributaria situacaoTributaria, TipoProduto tipoProduto)
        {
            if (tipoProduto == TipoProduto.Servico)
            {
                switch (situacaoTributaria)
                {
                    case SituacaoTributaria.Isento:
                        return "ISS";
                    case SituacaoTributaria.SubstituicaoTributaria:
                        return "FS";
                    case SituacaoTributaria.Tributado:
                        return "S";
                    case SituacaoTributaria.NaoTributado:
                        return "NS";
                }
            }
            else
            {
                switch (situacaoTributaria)
                {
                    case SituacaoTributaria.Isento:
                        return "I";
                    case SituacaoTributaria.SubstituicaoTributaria:
                        return "F1";
                    case SituacaoTributaria.Tributado:
                        return "T";
                    case SituacaoTributaria.NaoTributado:
                        return "N";
                }
            }

            return "";
        }


        public override bool LancarDescontoItem(int numeroItem, TipoDescontoAcressimo tipoDesconto, decimal valorDesconto)
        {
            Declaracoes.iRetorno = Declaracoes.iCFLancarDescontoItem_ECF_Daruma(
                numeroItem.ToString(CultureInfo.InvariantCulture),
                TipoDescontoAcressimoToString(tipoDesconto),
                AjustarCasasDecimais(FormataNumero(valorDesconto).ToString(), 2)
                );
            return TrataRetorno(Declaracoes.iRetorno);
        }

        public override bool LancarAcressimoItem(int numeroItem, TipoDescontoAcressimo tipoDescontoAcressimo, decimal valorAcressimo)
        {
            Declaracoes.iRetorno = Declaracoes.iCFLancarAcrescimoItem_ECF_Daruma(
                numeroItem.ToString(CultureInfo.InvariantCulture),
                TipoDescontoAcressimoToString(tipoDescontoAcressimo),
                AjustarCasasDecimais(FormataNumero(valorAcressimo).ToString(), 2)
                );
            return TrataRetorno(Declaracoes.iRetorno);
        }

        public override bool LancarDescontoUltimoItem(TipoDescontoAcressimo tipoDesconto, decimal valorDesconto)
        {
            Declaracoes.iRetorno = Declaracoes.iCFLancarDescontoUltimoItem_ECF_Daruma(
                TipoDescontoAcressimoToString(tipoDesconto),
                AjustarCasasDecimais(FormataNumero(valorDesconto).ToString(), 2)
                );
            return TrataRetorno(Declaracoes.iRetorno);
        }

        public override bool LancarAcressimoUltimoItem(TipoDescontoAcressimo tipoDescontoAcressimo, decimal valorAcressimo)
        {
            Declaracoes.iRetorno = Declaracoes.iCFLancarAcrescimoUltimoItem_ECF_Daruma(
                TipoDescontoAcressimoToString(tipoDescontoAcressimo),
                AjustarCasasDecimais(FormataNumero(valorAcressimo).ToString(), 2)
                );
            return TrataRetorno(Declaracoes.iRetorno);
        }

        public override bool CancelarItem(int numeroItem)
        {
            Declaracoes.iRetorno = Declaracoes.iCFCancelarItem_ECF_Daruma(
                numeroItem.ToString(CultureInfo.InvariantCulture)
                );
            return TrataRetorno(Declaracoes.iRetorno);
        }

        public override bool CancelarDescontoItem(int numeroItem)
        {
            Declaracoes.iRetorno = Declaracoes.iCFCancelarDescontoItem_ECF_Daruma(
                numeroItem.ToString(CultureInfo.InvariantCulture)
                );
            return TrataRetorno(Declaracoes.iRetorno);
        }

        public override bool CancelaDescontoUltimoItem()
        {
            Declaracoes.iRetorno = Declaracoes.iCFCancelarDescontoUltimoItem_ECF_Daruma();
            return TrataRetorno(Declaracoes.iRetorno);
        }

        public override bool CancelaAcressimoItem(int numeroItem)
        {
            Declaracoes.iRetorno = Declaracoes.iCFCancelarAcrescimoItem_ECF_Daruma(
                numeroItem.ToString(CultureInfo.InvariantCulture)
                );
            return TrataRetorno(Declaracoes.iRetorno);
        }

        public override bool CancelaAcressimoUltimoItem()
        {
            Declaracoes.iRetorno = Declaracoes.iCFCancelarAcrescimoUltimoItem_ECF_Daruma();
            return TrataRetorno(Declaracoes.iRetorno);
        }

        public override bool CancelarDescontoSubTotal()
        {
            Declaracoes.iRetorno = Declaracoes.iCFCancelarDescontoSubtotal_ECF_Daruma();
            return TrataRetorno(Declaracoes.iRetorno);
        }

        public override bool CancelarAcressimoSubTotal()
        {
            Declaracoes.iRetorno = Declaracoes.iCFCancelarAcrescimoSubtotal_ECF_Daruma();
            return TrataRetorno(Declaracoes.iRetorno);
        }

        public override bool CancelaItemParcial(int numeroItem, decimal quantidade)
        {
            Declaracoes.iRetorno = Declaracoes.iCFCancelarItemParcial_ECF_Daruma(
                numeroItem.ToString(CultureInfo.InvariantCulture),
                AjustarCasasDecimais(FormataNumero(quantidade).ToString(), 3)
                );
            return TrataRetorno(Declaracoes.iRetorno);
        }

        public override bool CancelarUltimoItem()
        {
            Declaracoes.iRetorno = Declaracoes.iCFCancelarUltimoItem_ECF_Daruma();
            return TrataRetorno(Declaracoes.iRetorno);
        }

        public override bool CancelarUltimoItemParcial(decimal quantidade)
        {
            Declaracoes.iRetorno = Declaracoes.iCFCancelarUltimoItemParcial_ECF_Daruma(
                AjustarCasasDecimais(FormataNumero(quantidade).ToString(), 3)
                );
            return TrataRetorno(Declaracoes.iRetorno);
        }

        public override bool IniciaFechamentoCupom(TipoDescontoAcressimo tipoDescAcresc, decimal desconto, decimal acrescimo)
        {
            bool ret = true;
            if (desconto > acrescimo)
            {
                ret = TotalizarCupomFiscal(TipoDescontoAcressimo.DescontoValor, desconto - acrescimo);
            }
            else
            {
                ret = TotalizarCupomFiscal(TipoDescontoAcressimo.AcressimoValor, acrescimo - desconto);
            }
            return ret;
        }

        public override bool TotalizarCupomFiscal(TipoDescontoAcressimo tipoDescontoAcressimo, decimal valorDescontoAcressimo)
        {
            Declaracoes.iRetorno = Declaracoes.iCFTotalizarCupom_ECF_Daruma(
                TipoDescontoAcressimoToString(tipoDescontoAcressimo),
                AjustarCasasDecimais(FormataNumero(valorDescontoAcressimo).ToString(), 2)
                );
            return TrataRetorno(Declaracoes.iRetorno);
        }

        public override bool EfetuarPagamento(string formaPagamento, decimal valor, string informacaoAdicional)
        {
            Declaracoes.iRetorno = Declaracoes.iCFEfetuarPagamento_ECF_Daruma(
                formaPagamento,
                AjustarCasasDecimais(FormataNumero(valor).ToString(), 2),
                informacaoAdicional
                );
            return TrataRetorno(Declaracoes.iRetorno);
        }

        public override bool EfetuarPagamento(string formaPagamento, decimal valor)
        {
            Declaracoes.iRetorno = Declaracoes.iCFEfetuarPagamentoFormatado_ECF_Daruma(
                formaPagamento,
                AjustarCasasDecimais(FormataNumero(valor).ToString(), 2)
                );
            return TrataRetorno(Declaracoes.iRetorno);
        }

        public override bool EfetuarPagamentoPadrao()
        {
            Declaracoes.iRetorno = Declaracoes.iCFEfetuarPagamentoPadrao_ECF_Daruma();
            return TrataRetorno(Declaracoes.iRetorno);
        }

        public override bool ExtornarPagamento(string formaPagamentoEstornado, string formaPagamento, decimal valor, string informacaoAdicional)
        {
            Declaracoes.iRetorno = Declaracoes.iEstornarPagamento_ECF_Daruma(
                formaPagamentoEstornado,
                formaPagamento,
                AjustarCasasDecimais(FormataNumero(valor).ToString(), 2),
                informacaoAdicional
                );
            return TrataRetorno(Declaracoes.iRetorno);
        }

        public override bool IdentificaConsumidor(ClienteCupom cliente)
        {
            var buf = new StringBuilder();
            var ret = 0;
            bool retorno = true;
            retorno = TrataRetorno(Declaracoes.rCFVerificarStatus_ECF_Daruma(buf, ref ret));
            if (!retorno)
            {
                return false;
            }
            var status = IntToStatusCupomFiscal(ret);
            if (status != StatusCupomFiscal.Fechado)
            {
                MessageBox.Show("Já existe um cupom fiscal aberto.\n" +
                                "O mesmo será cancelado.");
                CancelarCupom();
            }
            if (status != StatusCupomFiscal.Fechado)
            {
                return AbrirCupom(cliente);
            }
            else
            {
                return TrataRetorno(Declaracoes.iCFIdentificarConsumidor_ECF_Daruma(
                cliente.CpfCnpj,
                cliente.Nome,
                cliente.Endereco
                ));
            }

        }

        public override bool EncerrarCupom()
        {
            Declaracoes.iRetorno = Declaracoes.iCFEncerrarPadrao_ECF_Daruma();
            return TrataRetorno(Declaracoes.iRetorno);
        }

        public override bool EncerrarCupom(CupomFiscalAdicional cupomFiscalAdicional, string mensagem)
        {
            Declaracoes.iRetorno = Declaracoes.iCFEncerrar_ECF_Daruma(
                CupomFiscalAdicionalToString(cupomFiscalAdicional),
                mensagem
                );
            return TrataRetorno(Declaracoes.iRetorno);
        }

        public override bool EncerrarCupom(string mensagem)
        {
            Declaracoes.iRetorno = Declaracoes.iCFEncerrarConfigMsg_ECF_Daruma(
                mensagem
                );
            return TrataRetorno(Declaracoes.iRetorno);
        }

        public override sealed bool CancelarCupom()
        {
            Declaracoes.iRetorno = Declaracoes.iCFCancelar_ECF_Daruma();
            return TrataRetorno(Declaracoes.iRetorno);
        }

        public override bool EmitirCupomAdicional()
        {
            Declaracoes.iRetorno = Declaracoes.iCFEmitirCupomAdicional_ECF_Daruma();
            return TrataRetorno(Declaracoes.iRetorno);
        }

        public override decimal SaldoAtualCupomFiscal()
        {
            var ret = new StringBuilder();
            Declaracoes.iRetorno = Declaracoes.rCFSaldoAPagar_ECF_Daruma(
                ret
                );
            TrataRetorno(Declaracoes.iRetorno);
            return ToDecimal(ret.ToString());
        }

        public override decimal SubTotalCupomFiscal()
        {
            var ret = new StringBuilder();
            Declaracoes.iRetorno = Declaracoes.rCFSubTotal_ECF_Daruma(
                ret);
            TrataRetorno(Declaracoes.iRetorno);
            return ToDecimal(ret.ToString());

        }

        public override sealed StatusCupomFiscal VerificaStatusCupomFiscal()
        {
            var status = StatusCupomFiscal.Fechado;
            int retInt = 0;
            var retString = new StringBuilder();
            Declaracoes.iRetorno = Declaracoes.rCFVerificarStatus_ECF_Daruma(
                retString, ref retInt
                );
            if (!TrataRetorno(Declaracoes.iRetorno))
            {
                return status;
            }
            status = IntToStatusCupomFiscal(retInt);
            return status;
        }

        public override bool TotalIcmsIssUltimoCupom(ref decimal icms, ref decimal iss)
        {
            var retIcms = new StringBuilder();
            var retIss = new StringBuilder();
            Declaracoes.iRetorno = Declaracoes.rCMEfetuarCalculo_ECF_Daruma(
                retIss,
                retIcms
                );
            return TrataRetorno(Declaracoes.iRetorno);
        }

        public override bool ImprimeLeituraX()
        {
            Declaracoes.iRetorno = Declaracoes.iLeituraX_ECF_Daruma();
            return TrataRetorno(Declaracoes.iRetorno);
        }

        public override bool ImprimeLeituraX(decimal caixaInicial)
        {
            if (TrataRetorno(Declaracoes.iLeituraX_ECF_Daruma()))
            {
                return
                    TrataRetorno(Declaracoes.iSuprimento_ECF_Daruma(FormataNumero(caixaInicial).ToString(),
                    "LANCAMENTO iNICIAL"));
            }
            return false;
        }

        public override bool GravaLeituraX()
        {
            Declaracoes.iRetorno = Declaracoes.rLeituraX_ECF_Daruma();
            return TrataRetorno(Declaracoes.iRetorno);
        }

        public override bool LeituraMemoriaFiscalSimplificadaData(DateTime inicio, DateTime fim)
        {

            Declaracoes.iRetorno = Declaracoes.regAlterarValor_Daruma(
                "ECF\\LMFCompleta",
                "0");
            if (Declaracoes.iRetorno == CodigoSucessoComando)
            {
                Declaracoes.iRetorno = Declaracoes.iMFLer_ECF_Daruma(
                    FormataData(inicio),
                    FormataData(fim)
                    );
                return TrataRetorno(Declaracoes.iRetorno);
            }
            else
            {
                return TrataRetorno(Declaracoes.iRetorno);
            }


        }

        public override bool LeituraMemoriaFiscalSimplificadaCrz(int inicio, int fim)
        {
            Declaracoes.iRetorno = Declaracoes.regAlterarValor_Daruma(
                "ECF\\LMFCompleta",
                "0");
            if (Declaracoes.iRetorno == CodigoSucessoComando)
            {
                Declaracoes.iRetorno = Declaracoes.iMFLer_ECF_Daruma(
                    FormataCrz(inicio),
                    FormataCrz(fim)
                    );
                return TrataRetorno(Declaracoes.iRetorno);
            }
            else
            {
                return TrataRetorno(Declaracoes.iRetorno);
            }
        }

        public override bool LeituraMemoriaFiscalCompletaData(DateTime inicio, DateTime fim)
        {
            Declaracoes.iRetorno = Declaracoes.regAlterarValor_Daruma(
                "ECF\\LMFCompleta",
                "1");
            if (Declaracoes.iRetorno == CodigoSucessoComando)
            {
                Declaracoes.iRetorno = Declaracoes.iMFLer_ECF_Daruma(
                    FormataData(inicio),
                    FormataData(fim)
                    );
                return TrataRetorno(Declaracoes.iRetorno);
            }
            else
            {
                return TrataRetorno(Declaracoes.iRetorno);
            }
        }

        public override bool LeituraMemoriaFiscalCompletaCrz(int inicio, int fim)
        {
            Declaracoes.iRetorno = Declaracoes.regAlterarValor_Daruma(
                "ECF\\LMFCompleta",
                "1");
            if (Declaracoes.iRetorno == CodigoSucessoComando)
            {
                Declaracoes.iRetorno = Declaracoes.iMFLer_ECF_Daruma(
                    FormataCrz(inicio),
                    FormataCrz(fim)
                    );
                return TrataRetorno(Declaracoes.iRetorno);
            }
            else
            {
                return TrataRetorno(Declaracoes.iRetorno);
            }
        }

        public override bool LeituraMemoriaFiscalSerialSimplificadaData(DateTime inicio, DateTime fim)
        {
            Declaracoes.iRetorno = Declaracoes.regAlterarValor_Daruma(
                "ECF\\LMFCompleta",
                "0");
            if (Declaracoes.iRetorno == CodigoSucessoComando)
            {
                Declaracoes.iRetorno = Declaracoes.iMFLerSerial_ECF_Daruma(
                    FormataData(inicio),
                    FormataData(fim)
                    );
                return TrataRetorno(Declaracoes.iRetorno);
            }
            else
            {
                return TrataRetorno(Declaracoes.iRetorno);
            }
        }

        public override bool LeituraMemoriaFiscalSerialSimplificadaCrz(int inicio, int fim)
        {
            Declaracoes.iRetorno = Declaracoes.regAlterarValor_Daruma(
                "ECF\\LMFCompleta",
                "0");
            if (Declaracoes.iRetorno == CodigoSucessoComando)
            {
                Declaracoes.iRetorno = Declaracoes.iMFLerSerial_ECF_Daruma(
                    FormataCrz(inicio),
                    FormataCrz(fim)
                    );
                return TrataRetorno(Declaracoes.iRetorno);
            }
            else
            {
                return TrataRetorno(Declaracoes.iRetorno);
            }
        }

        public override bool LeituraMemoriaFiscalSerialCompletaData(DateTime inicio, DateTime fim)
        {
            Declaracoes.iRetorno = Declaracoes.regAlterarValor_Daruma(
                "ECF\\LMFCompleta",
                "1");
            if (Declaracoes.iRetorno == CodigoSucessoComando)
            {
                Declaracoes.iRetorno = Declaracoes.iMFLerSerial_ECF_Daruma(
                    FormataData(inicio),
                    FormataData(fim)
                    );
                return TrataRetorno(Declaracoes.iRetorno);
            }
            else
            {
                return TrataRetorno(Declaracoes.iRetorno);
            }
        }

        public override bool LeituraMemoriaFiscalSerialCompletaCrz(int inicio, int fim)
        {
            Declaracoes.iRetorno = Declaracoes.regAlterarValor_Daruma(
                "ECF\\LMFCompleta",
                "1");
            if (Declaracoes.iRetorno == CodigoSucessoComando)
            {
                Declaracoes.iRetorno = Declaracoes.iMFLerSerial_ECF_Daruma(
                    FormataCrz(inicio),
                    FormataCrz(fim)
                    );
                return TrataRetorno(Declaracoes.iRetorno);
            }
            else
            {
                return TrataRetorno(Declaracoes.iRetorno);
            }
        }


        public override bool Sangria(decimal valor, string mensagem)
        {
            Declaracoes.iRetorno = Declaracoes.iSangria_ECF_Daruma(
                AjustarCasasDecimais(FormataNumero(valor).ToString(), 2),
                mensagem
                );
            return TrataRetorno(Declaracoes.iRetorno);
        }

        public override bool Suprimento(decimal valor, string mensagem)
        {
            Declaracoes.iRetorno = Declaracoes.iSuprimento_ECF_Daruma(
                AjustarCasasDecimais(FormataNumero(valor).ToString(), 2),
                mensagem
                );
            return TrataRetorno(Declaracoes.iRetorno);
        }

        public override bool ImprimeConfiguracao()
        {
            Declaracoes.iRetorno = Declaracoes.iRelatorioConfiguracao_ECF_Daruma();
            return TrataRetorno(Declaracoes.iRetorno);
        }

        public override bool ImprimeReducaoZ()
        {
            Declaracoes.iRetorno = Declaracoes.iReducaoZ_ECF_Daruma(
                FormataData(DateTime.Now),
                FormataHora(DateTime.Now)
                );
            return TrataRetorno(Declaracoes.iRetorno);
        }

        public override bool ImprimeRelatorioGerencial(string texto)
        {
            var ret = TrataRetorno(Declaracoes.iRGAbrirPadrao_ECF_Daruma());
            //if (ret)
            //{
            ret = TrataRetorno(Declaracoes.iRGImprimirTexto_ECF_Daruma(texto));
            if (ret)
            {
                return TrataRetorno(Declaracoes.iRGFechar_ECF_Daruma());
            }
            return true;
            //var newLine = new[] { Environment.NewLine };
            //var slipt = texto.Split();
            //foreach (var s in slipt)
            //{
            //    ret = TrataRetorno(Declaracoes.iRGImprimirTexto_ECF_Daruma(texto));
            //    if (!ret)
            //    {
            //        ret = TrataRetorno(Declaracoes.iRGFechar_ECF_Daruma());
            //        return ret;
            //    }
            //}

            //}
            //ret = TrataRetorno(Declaracoes.iRGFechar_ECF_Daruma());
            //return ret;
        }

        public override decimal VendaBruta()
        {
            return 0;
        }

        public override decimal VendaLiquida()
        {
            return 0;
        }

        public override sealed void ReducaoZPendente()
        {
            var buf = new StringBuilder();
            TrataRetorno(Declaracoes.rVerificarReducaoZ_ECF_Daruma(buf));
            if (buf.ToString().Equals("1"))
            {
                ImprimeReducaoZ();

            }

        }

        public override DateTime DataMovimento()
        {
            var buf = new StringBuilder();
            if (TrataRetorno(Declaracoes.rRetornarInformacao_ECF_Daruma("70", buf)))
            {
                return ToDate(buf.ToString().Substring(0, 8));
            }
            return new DateTime(1);
        }

        public override DateTime DataUltimaReducaoZ()
        {
            var buf = new StringBuilder();
            if (TrataRetorno(Declaracoes.rRetornarInformacao_ECF_Daruma("140", buf)))
            {
                return ToDate(buf.ToString().Split(';')[0]);
            }
            return new DateTime(1);
        }

        public override bool EspelhoMfdData(DateTime inicio, DateTime fim)
        {
            var i = FormataDataPadraoPaf(inicio);
            var f = FormataDataPadraoPaf(fim);
            return TrataRetorno(Declaracoes.rGerarRelatorio_ECF_Daruma(
                "ESPELHO",
                "DATAM",
                i,
                f));
        }

        private string FormataDataPadraoPaf(DateTime fim)
        {
            return fim.ToString("ddMMyyyy");
        }

        public override bool EspelhoMfdCrz(int inicio, int fim)
        {
            return TrataRetorno(Declaracoes.rGerarRelatorio_ECF_Daruma(
                "ESPELHO",
                "COO",
                inicio.ToString(CultureInfo.InvariantCulture),
                fim.ToString(CultureInfo.InvariantCulture)
                ));
        }

        public override bool ArquivoMfdData(DateTime inicio, DateTime fim)
        {
            var i = FormataDataPadraoPaf(inicio);
            var f = FormataDataPadraoPaf(fim);
            var ret = TrataRetorno(Declaracoes.rGerarRelatorio_ECF_Daruma(
                "MFD",
                "DATAM",
                i,
                f
                ));
            //if (ret)
            //{
            //    var msg = "Gravar o arquivo no banco de dados?";
            //    if (MessageBox.Show(msg, "Atenção", MessageBoxButtons.YesNo) == DialogResult.Yes)
            //    {
            //        ArquivoDigitalRepository.ImportarArquivo(LocalArquivosRelatoriosFiscais);
            //    }
            //}
            return ret;
        }

        public override bool ArquivoMfdCrz(int inicio, int fim)
        {
            return TrataRetorno(Declaracoes.rGerarRelatorio_ECF_Daruma(
                "MFD",
                "COO",
                inicio.ToString(CultureInfo.InvariantCulture),
                fim.ToString(CultureInfo.InvariantCulture)
                ));
        }



        public override bool TravaTeclado()
        {
            return TrataRetorno(Declaracoes.eTEF_TravarTeclado_ECF_Daruma(true));
        }

        private bool TrataRetorno(int retorno)
        {
            Declaracoes.TrataRetorno(retorno);
            return retorno == 1;
        }

        public override bool DestravaTeclado()
        {
            return TrataRetorno(Declaracoes.eTEF_TravarTeclado_ECF_Daruma(false));
        }

        public override RetornoTef EnviarSolicitacao(IList<Pagamento> pagamentos)
        {
            MessageBox.Show(MensagemNaoSuportada);
            return RetornoTef.Sucesso;
        }

        public override bool ImprimirTef()
        {
            Declaracoes.iRetorno = Declaracoes.iTEF_ImprimirResposta_ECF_Daruma(
                ArquivoTefSolicitacao, true);
            DestravaTeclado();
            return TrataRetorno(Declaracoes.iRetorno);
        }

        

        public override sealed bool VerificaImpressora()
        {
            if (!ImpressoraLigada())
            {
                return false;
            }
            ReducaoZPendente();
            var result = VerificaStatusCupomFiscal();
            if (result != StatusCupomFiscal.Fechado)
            {
                CancelarCupom();
            }
            return true;
        }

        public override IList<Aliquota> ExibeAliquotasCadastradas()
        {

            var buf = new StringBuilder();
            var ret = new List<Aliquota>();
            TrataRetorno(Declaracoes.rLerAliquotas_ECF_Daruma(buf));
            var aliquotas = buf.ToString().Split(';');
            foreach (var aliquota in aliquotas)
            {
                Bematech.Fiscal.ECF.Informacoes.Aliquota.TipoAliquota tipo;
                if (aliquota.Contains("S"))
                {
                    tipo = Bematech.Fiscal.ECF.Informacoes.Aliquota.TipoAliquota.ISS;
                }
                else
                {
                    tipo = Bematech.Fiscal.ECF.Informacoes.Aliquota.TipoAliquota.ICMS;
                }
                ret.Add(new Aliquota()
                {
                    TipoAliquota = tipo,
                    Valor = aliquota
                });
            }
            return ret;
        }

        public override sealed ReducaoZ UltimaReducaoZ()
        {
            try
            {
                var buf = new StringBuilder();
                TrataRetorno(Declaracoes.rRetornarDadosReducaoZ_ECF_Daruma(buf));
                var split = buf.ToString().Split(';');
                var reducao = new ReducaoZ()
                {
                    Data = ToDate(split[0]),
                    GrandeTotal = int.Parse(split[1]),
                    GrandeTotalInicial = int.Parse(split[2]),
                    DescontoIcms = decimal.Parse(split[3]),
                    DescontoIss = decimal.Parse(split[4]),
                    CancelamentoIcms = decimal.Parse(split[5]),
                    CancelamentoIss = decimal.Parse(split[6]),
                    AcrescimoIcms = decimal.Parse(split[7]),
                    AcrescimoIss = decimal.Parse(split[8]),
                    TributadosIcmsIss = split[9],
                    F1Icms = decimal.Parse(split[10]),
                    F2Icms = decimal.Parse(split[11]),
                    I1Icms = decimal.Parse(split[12]),
                    I2Icms = decimal.Parse(split[13]),
                    N1Icms = decimal.Parse(split[14]),
                    N2Icms = decimal.Parse(split[15]),
                    F1Iss = decimal.Parse(split[16]),
                    F2Iss = decimal.Parse(split[17]),
                    I1Iss = decimal.Parse(split[18]),
                    I2Iss = decimal.Parse(split[19]),
                    N1Iss = decimal.Parse(split[20]),
                    N2Iss = decimal.Parse(split[21]),
                    TotalizadoresNf = split[22],
                    DescontosNf = decimal.Parse(split[23]),
                    CancelamentosNf = decimal.Parse(split[24]),
                    AcressimosNf = decimal.Parse(split[25]),
                    Aliquotas = split[26],
                    Cro = int.Parse(split[27]),
                    Crz = int.Parse(split[28]),
                    CrzRestante = int.Parse(split[29]),
                    Coo = int.Parse(split[30]),
                    Gnf = int.Parse(split[31]),
                    Ccf = int.Parse(split[32]),
                    Cvc = int.Parse(split[33]),
                    Grg = int.Parse(split[35]),
                    Cfd = int.Parse(split[36]),
                    Cbp = int.Parse(split[37]),
                    Nfc = int.Parse(split[38]),
                    Cmv = int.Parse(split[39]),
                    Cfc = int.Parse(split[40]),
                    Cnc = int.Parse(split[41]),
                    Cbc = int.Parse(split[42]),
                    Ncn = int.Parse(split[43]),
                    Cdc = int.Parse(split[44]),
                    Con = int.Parse(split[45]),
                    Cer = int.Parse(split[46])
                };

                return reducao;
            }
            catch (Exception ex)
            {
                MessageBox.Show("Erro ao buscar ultima redução Z.\n" + ex.Message);
                throw;
            }
            return null;
        }

        public override sealed bool ImpressoraLigada()
        {
            return true;
        }


        public override bool CadastrarAliquota(decimal aliquota, TipoAliquota tipoAliquota)
        {
            if (tipoAliquota == TipoAliquota.Icms)
            {
                return TrataRetorno(Declaracoes.confCadastrar_ECF_Daruma("ALIQUOTA", FormataPercentual(aliquota), "|"));
            }
            else
            {
                return TrataRetorno(Declaracoes.confCadastrar_ECF_Daruma("ALIQUOTA", "S" + FormataPercentual(aliquota), "|"));
            }
        }

        public override bool CadastrarFormaPagamento(string formaPagamento)
        {
            return TrataRetorno(Declaracoes.confCadastrar_ECF_Daruma("FPGTO", formaPagamento, "|"));
        }
    }
}
