using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Globalization;
using System.IO;
using System.Windows.Forms;
using Bematech;
using Bematech.Fiscal.ECF;
using Bematech.Fiscal.ECF.CupomFiscal;
using Bematech.Fiscal.ECF.Informacoes;
using Ecf.Enum;
using Erp.Business;
using Erp.Business.Entity.Vendas.Ecf;
using Erp.Business.Enum;

namespace Ecf.ImplementacaoEcf
{
    internal class BematechEcf : AbstractEcf
    {

        private ImpressoraFiscal Impressora { get; set; }

        public BematechEcf()
        {
            try
            {
                Impressora = ImpressoraFiscal.Construir();
                var statusImp = ImpressoraLigada();
                if (!statusImp)
                {
                    throw new Exception("A impressora está desligada.");
                }
                var statusCupom = VerificaStatusCupomFiscal();
                if (statusCupom == StatusCupomFiscal.Aberto)
                {
                    CancelarCupom();
                }

                if (LocalArquivosRelatoriosFiscais == null)
                {
                    LocalArquivosRelatoriosFiscais = Environment.CurrentDirectory + "\\relatórios fiscais\\";

                }
                if (!Directory.Exists(LocalArquivosRelatoriosFiscais))
                {
                    Directory.CreateDirectory(LocalArquivosRelatoriosFiscais);
                }
                Impressora.Inicializacao.HabilitarVendaItemUmaLinha(false);

            }
            catch (Exception ex)
            {
                MessageBox.Show("Erro ao iniciar impressora fiscal.\n" + ex.Message);
                Process.GetCurrentProcess().Kill();
            }


        }
        public override object FormataNumero(decimal valor)
        {

            return null;
        }

        public override string FormataPercentual(decimal valor)
        {

            var val = valor.ToString(CultureInfo.InvariantCulture).Replace(".", ",").Split(',');
            var inteiro = "0000" + val[0];
            var decimais = val[1] + 000;

            inteiro = inteiro.Substring(inteiro.Length - 2);
            decimais = decimais.Substring(0, 2);
            var ret = inteiro + decimais;
            return ret;
        }

        private TipoAcrescimoDesconto TipoDescontoAcressimoToAcrescimoDesconto(TipoDescontoAcressimo tipo)
        {
            switch (tipo)
            {
                case TipoDescontoAcressimo.AcressimoPercentual:
                    return TipoAcrescimoDesconto.Percentual;
                case TipoDescontoAcressimo.AcressimoValor:
                    return TipoAcrescimoDesconto.Valor;
                case TipoDescontoAcressimo.DescontoPercentual:
                    return TipoAcrescimoDesconto.Percentual;
                case TipoDescontoAcressimo.DescontoValor:
                    return TipoAcrescimoDesconto.Valor;
            }
            return TipoAcrescimoDesconto.Valor;
        }
        public override decimal ToDecimal(string valor)
        {
            MessageBox.Show(MensagemNaoSuportada);
            return 0;
        }

        public override DateTime ToDate(string valor)
        {
            MessageBox.Show(MensagemNaoSuportada);
            return new DateTime(1);
        }

        public override string FormataData(DateTime data)
        {
            return data.ToString("ddMMyyyy");
        }

        public override string FormataHora(DateTime hora)
        {
            MessageBox.Show(MensagemNaoSuportada);
            return null;
        }

        public override string FormataCrz(int numero)
        {
            MessageBox.Show(MensagemNaoSuportada);
            return null;
        }

        public override int UltimoCupomEmitido()
        {
            try
            {
                return UltimoCupom;
            }
            catch (BematechException ex)
            {
                MessageBox.Show("Erro ao buscar o número do último cupom fiscal." +
                    ex.Message);
            }
            return 0;
        }

        public static int UltimoCupom { get; set; }


        public override bool AbrirCupom(ClienteCupom cliente)
        {
            try
            {
                if (Impressora.Cupom.Status.Aberto)
                {
                    MessageBox.Show("Cupom fiscal já aberto.\n\n" +
                                    "O mesmo será cancelado.");
                    CancelarCupom();
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
                UltimoCupom = Impressora.Cupom.Abrir(
                    cliente.CpfCnpj,
                    cliente.Nome,
                    cliente.Endereco
                    );
                return true;
            }
            catch (Bematech.BematechException ex)
            {
                ExibeMensagem("Erro ao abrir cupom fiscal.\n" + ex.Message);
                return false;
            }

        }

        public override bool VenderItem(SituacaoTributaria cargaTributaria, TipoProduto tipoProduto, decimal quantidade,
            decimal precoUnitario, TipoDescontoAcressimo tipoDescontoAcressimo, decimal valorDescontoAcressimo,
            int codigoItem, string unidadeMedida, string descricaoItem, decimal tributacao)
        {
            try
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
                var item = new Item()
                {
                    Aliquota = aliquota,
                    Codigo = codigoItem.ToString(CultureInfo.InvariantCulture),
                    Quantidade = quantidade,
                    Descricao = descricaoItem,
                    TipoQuantidade = TipoQuantidade.Fracionaria,
                    CasasDecimais = ContaCasasDecimais(quantidade),
                    ValorUnitario = precoUnitario

                };
                var validacao = "";
                var error = item.Validar();
                foreach (ParametroInvalido invalido in error)
                {

                    validacao += invalido.Descricao + Environment.NewLine;
                }
                if (!validacao.Equals(""))
                {
                    MessageBox.Show("Erros encontrados.\n" + validacao);
                }
                Impressora.Cupom.AumentarDescricaoItem(item.Descricao);
                Impressora.Cupom.Vender(item);
                //Impressora.Cupom.Vender(codigoItem.ToString(CultureInfo.InvariantCulture),
                //    descricaoItem,
                //    aliquota,
                //    TipoQuantidade.Fracionaria,
                //    quantidade,
                //    ContaCasasDecimais(quantidade),
                //    precoUnitario,
                //    TipoDescontoAcressimoToAcrescimoDesconto(tipoDescontoAcressimo), // SubGrupo de desconto.
                //    valorDescontoAcressimo); // Valor desconto
                return true;
            }
            catch (Bematech.BematechException ex)
            {
                ExibeMensagem("Erro ao vender item.\n" + ex.Message);
                CancelarCupom();
                throw;
                return false;
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
                        return "II";
                    case SituacaoTributaria.SubstituicaoTributaria:
                        return "FF";
                    case SituacaoTributaria.Tributado:
                        return "T";
                    case SituacaoTributaria.NaoTributado:
                        return "NN";
                }
            }
            return "";
        }

        private void ExibeMensagem(string s)
        {
            MessageBox.Show(s);
        }

        private int ContaCasasDecimais(decimal valor)
        {
            var s = valor.ToString("C");
            return s.Substring(0, s.IndexOf(",", System.StringComparison.Ordinal)).Length - 1;
        }


        public override bool LancarDescontoItem(int numeroItem, TipoDescontoAcressimo tipoDesconto, decimal valorDesconto)
        {
            try
            {
                Impressora.Cupom.DescontarItem(
                    numeroItem,
                    TipoDescontoAcressimoToAcrescimoDesconto(tipoDesconto),
                    valorDesconto);
                return true;
            }
            catch (Bematech.BematechException ex)
            {
                ExibeMensagem("Erro ao lançar desconto.\n" + ex.Message);
            }
            return false;
        }

        public override bool LancarAcressimoItem(int numeroItem, TipoDescontoAcressimo tipoDescontoAcressimo, decimal valorAcressimo)
        {
            try
            {
                Impressora.Cupom.DescontarItem(
                    numeroItem,
                    TipoDescontoAcressimoToAcrescimoDesconto(tipoDescontoAcressimo),
                    valorAcressimo);
            }
            catch (Bematech.BematechException ex)
            {
                ExibeMensagem("Erro ao lançar acrescimo em item.\n" + ex.Message);
                return false;
            }
            return true;
        }

        public override bool LancarDescontoUltimoItem(TipoDescontoAcressimo tipoDesconto, decimal valorDesconto)
        {
            try
            {
                MessageBox.Show(MensagemNaoSuportada);
            }
            catch (Bematech.BematechException ex)
            {
                ExibeMensagem("Erro ao lançar desconto.\n" + ex.Message);
                return false;
            }
            return true;
        }

        public override bool LancarAcressimoUltimoItem(TipoDescontoAcressimo tipoDescontoAcressimo, decimal valorAcressimo)
        {
            MessageBox.Show(MensagemNaoSuportada);
            return false;
        }

        public override bool CancelarItem(int numeroItem)
        {
            try
            {
                Impressora.Cupom.CancelarItem(numeroItem);
            }
            catch (Bematech.BematechException ex)
            {
                ExibeMensagem("Erro ao cancelar item.\n" + ex.Message);
                return false;
            }
            return true;
        }

        public override bool CancelarDescontoItem(int numeroItem)
        {
            try
            {
                Impressora.Cupom.CancelarDescontoItem(numeroItem);
            }
            catch (Bematech.BematechException ex)
            {
                ExibeMensagem("Erro ao cancelar desconto.\n" + ex.Message);
                return false;
            }
            return true;
        }

        public override bool CancelaDescontoUltimoItem()
        {
            MessageBox.Show(MensagemNaoSuportada);
            return false;
        }

        public override bool CancelaAcressimoItem(int numeroItem)
        {
            try
            {
                Impressora.Cupom.CancelarAcrescimoItem(numeroItem);
            }
            catch (Bematech.BematechException ex)
            {
                ExibeMensagem("Erro ao cancelar acréscimo.\n" + ex.Message);
                return false;
            }
            return true;
        }

        public override bool CancelaAcressimoUltimoItem()
        {
            MessageBox.Show(MensagemNaoSuportada);
            return false;
        }

        public override bool CancelarDescontoSubTotal()
        {
            try
            {
                Impressora.Cupom.CancelarDescontoSubTotal();
            }
            catch (Bematech.BematechException ex)
            {
                ExibeMensagem("Erro ao cancelar desconto.\n" + ex.Message);
                return false;
            }
            return true;
        }

        public override bool CancelarAcressimoSubTotal()
        {
            try
            {
                Impressora.Cupom.CancelarAcrescimoSubTotal();
            }
            catch (Bematech.BematechException ex)
            {
                ExibeMensagem("Erro ao cancelar acréscimo.\n" + ex.Message);
                return false;
            }
            return true;
        }

        public override bool CancelaItemParcial(int numeroItem, decimal quantidade)
        {
            MessageBox.Show(MensagemNaoSuportada);
            return false;
        }

        public override bool CancelarUltimoItem()
        {
            MessageBox.Show(MensagemNaoSuportada);
            return false;
        }

        public override bool CancelarUltimoItemParcial(decimal quantidade)
        {
            MessageBox.Show(MensagemNaoSuportada);
            return false;
        }

        public override bool IniciaFechamentoCupom(TipoDescontoAcressimo tipoDescAcresc, decimal desconto, decimal acrescimo)
        {
            try
            {
                Impressora.Cupom.IniciarFechamento(
                    TipoDescontoAcressimoToAcrescimoDesconto(tipoDescAcresc),
                    acrescimo,
                    desconto
                    );
            }
            catch (BematechException ex)
            {
                MessageBox.Show("Erro ao iniciar fechamento do cupom.\n" + ex.Message);
                return false;
            }
            return true;
        }


        public override bool TotalizarCupomFiscal(TipoDescontoAcressimo tipoDescontoAcressimo, decimal valorDescontoAcressimo)
        {
            MessageBox.Show(MensagemNaoSuportada);
            return false;
        }

        public override bool EfetuarPagamento(string formaPagamento, decimal valor, string informacaoAdicional)
        {
            try
            {
                Impressora.Cupom.EfetuarPagamento(formaPagamento,
                    valor,
                    informacaoAdicional);
            }
            catch (Bematech.BematechException ex)
            {
                ExibeMensagem("Erro ao efetuar pagamento.\n" + ex.Message);
                return false;
            }
            return true;
        }

        public override bool EfetuarPagamento(string formaPagamento, decimal valor)
        {
            try
            {
                Impressora.Cupom.EfetuarPagamento(
                    formaPagamento,
                    valor);
            }
            catch (Bematech.BematechException ex)
            {
                ExibeMensagem("Erro ao efetuar pagamento.\n" + ex.Message);
                return false;
            }
            return true;
        }

        public override bool EfetuarPagamentoPadrao()
        {
            MessageBox.Show(MensagemNaoSuportada);
            return false;
        }

        public override bool ExtornarPagamento(string formaPagamentoEstornado, string formaPagamento, decimal valor, string informacaoAdicional)
        {
            MessageBox.Show(MensagemNaoSuportada);
            return false;
        }

        public override bool IdentificaConsumidor(ClienteCupom cliente)
        {
            try
            {
                AbrirCupom(cliente);
            }
            catch (Bematech.BematechException ex)
            {
                ExibeMensagem("Erro ao identificar consumidor.\n" + ex.Message);
                return false;
            }
            return true;
        }

        public override bool EncerrarCupom()
        {
            try
            {
                Impressora.Cupom.Fechar();
            }
            catch (BematechException ex)
            {
                ExibeMensagem("Erro ao encerrar cupom.\n" + ex.Message);
                return false;
            }
            return true;
        }

        public override bool EncerrarCupom(CupomFiscalAdicional cupomFiscalAdicional, string mensagem)
        {
            try
            {

                Impressora.Cupom.Fechar(mensagem);
                if (cupomFiscalAdicional != CupomFiscalAdicional.NaoImprime)
                {
                    Impressora.Cupom.EmitirCupomAdicional();
                }
            }
            catch (Bematech.BematechException ex)
            {
                ExibeMensagem("Erro ao encerrar cupom.\n" + ex.Message);
                return false;
            }
            return true;
        }

        public override bool EncerrarCupom(string mensagem)
        {

            EncerrarCupom(CupomFiscalAdicional.NaoImprime, mensagem);
            return false;
        }

        public override sealed bool CancelarCupom()
        {
            try
            {
                Impressora.Cupom.Cancelar();
            }
            catch (BematechException ex)
            {
                var ret = MessageBox.Show("Erro ao cancelar cupom.\n " +
                                          "Deseja tentar fechá-lo?", "Atenção!", MessageBoxButtons.YesNo);
                if (ret == DialogResult.Yes)
                {
                    if (EncerrarCupom()) return true;
                } return false;
            }
            return true;
        }

        public override bool EmitirCupomAdicional()
        {
            try
            {
                Impressora.Cupom.EmitirCupomAdicional();
            }
            catch (Bematech.BematechException ex)
            {
                ExibeMensagem("Erro ao emitir cupom adicional.\n" + ex.Message);
                return false;
            }
            return true;
        }

        public override decimal SaldoAtualCupomFiscal()
        {
            try
            {
                return Impressora.Cupom.SubTotal;
            }
            catch (Bematech.BematechException ex)
            {
                ExibeMensagem("Erro ao obter o saldo atual do cupom fiscal.\n" + ex.Message);
            }
            return 0;
        }

        public override decimal SubTotalCupomFiscal()
        {
            try
            {
                return Impressora.Cupom.SubTotal;
            }
            catch (Bematech.BematechException ex)
            {
                ExibeMensagem("Erro ao buscar subtotal do cupom.\n" + ex.Message);

            }
            return 0;
        }

        public override sealed StatusCupomFiscal VerificaStatusCupomFiscal()
        {
            try
            {

                if (Impressora.Cupom.Status.Cancelado)
                {
                    return StatusCupomFiscal.Cancelado;
                }
                if (Impressora.Cupom.Status.EmPagamento)
                {
                    return StatusCupomFiscal.EmPagamento;
                }
                if (Impressora.Cupom.Status.Encerrado)
                {
                    return StatusCupomFiscal.Fechado;
                }
                if (Impressora.Cupom.Status.NaoInicializado)
                {
                    return StatusCupomFiscal.NaoIniciado;
                }
                if (Impressora.Cupom.Status.Aberto)
                {
                    return StatusCupomFiscal.Aberto;
                }
            }
            catch (BematechException ex)
            {
                ExibeMensagem("Erro ao verificar o status do cupom fiscal.\n" + ex.Message);
            }
            return 0;
        }

        public override bool TotalIcmsIssUltimoCupom(ref decimal icms, ref decimal iss)
        {
            MessageBox.Show(MensagemNaoSuportada);
            return false;
        }

        public override bool ImprimeLeituraX()
        {
            try
            {
                Impressora.RelatoriosFiscais.ImprimirLeituraX();
            }
            catch (Bematech.BematechException ex)
            {
                ExibeMensagem("Erro ao buscar o ICMS do último cupom.\n" + ex.Message);
                return false;
            }
            return true;
        }

        public override bool ImprimeLeituraX(decimal caixaInicial)
        {
            try
            {
                
                Impressora.RelatoriosFiscais.ImprimirLeituraX();
                Suprimento(caixaInicial, "LANCAMENTO INICIAL");
                return true;
            }
            catch (Exception ex)
            {
                MessageBox.Show("Erro ao imprimir leitura X.\n" + ex.Message);
                return false;
            }
        }

        public override bool GravaLeituraX()
        {
            try
            {
                var x = Impressora.RelatoriosFiscais.ReceberLeituraX();
                Utils.GravarArquivo(LocalArquivosRelatoriosFiscais + "LeituraX.data" + FormataData(DateTime.Now), x);
            }
            catch (Bematech.BematechException ex)
            {
                ExibeMensagem("Erro ao gravar leitura X.\n" + ex.Message);
                return false;
            }
            return true;
        }

        public override bool LeituraMemoriaFiscalSimplificadaData(DateTime inicio, DateTime fim)
        {
            try
            {
                Impressora.RelatoriosFiscais.ImprimirLeituraMemoriaFiscal(
                    inicio,
                    fim,
                    true);
            }
            catch (Bematech.BematechException ex)
            {
                ExibeMensagem("Erro ao emitir leitura de memória fiscal simplificada.\n" + ex.Message);
                return false;
            }
            return true;
        }

        public override bool LeituraMemoriaFiscalSimplificadaCrz(int inicio, int fim)
        {
            try
            {
                Impressora.RelatoriosFiscais.ImprimirLeituraMemoriaFiscal(
                    inicio,
                    fim,
                    true);
            }
            catch (Bematech.BematechException ex)
            {
                ExibeMensagem("Erro ao emitir leitura da memória fiscal simplificada.\n" + ex.Message);
                return false;
            }
            return true;
        }

        public override bool LeituraMemoriaFiscalCompletaData(DateTime inicio, DateTime fim)
        {
            try
            {
                Impressora.RelatoriosFiscais.ImprimirLeituraMemoriaFiscal(
                    inicio,
                    fim,
                    false);
            }
            catch (Bematech.BematechException ex)
            {
                ExibeMensagem("Erro ao emitir leitura da memória fiscal.\n" + ex.Message);
                return false;
            }
            return true;
        }

        public override bool LeituraMemoriaFiscalCompletaCrz(int inicio, int fim)
        {
            try
            {
                Impressora.RelatoriosFiscais.ImprimirLeituraMemoriaFiscal(
                    inicio,
                    fim,
                    false);
            }
            catch (Bematech.BematechException ex)
            {
                ExibeMensagem("Erro ao emitir leitura da memória fiscal.\n" + ex.Message);
                return false;
            }
            return true;
        }

        public override bool LeituraMemoriaFiscalSerialSimplificadaData(DateTime inicio, DateTime fim)
        {
            try
            {
                var leitura = Impressora.RelatoriosFiscais.ReceberLeituraMemoriaFiscal(
                    inicio,
                    fim,
                    true);
                Utils.GravarArquivo(LocalArquivosRelatoriosFiscais + "LMF" + FormataData(DateTime.Now) + ".txt", leitura);
            }
            catch (Bematech.BematechException ex)
            {
                ExibeMensagem("Erro ao emitir leitura da memória fiscal.\n" + ex.Message);
                return false;
            }
            return true;
        }

        public override bool LeituraMemoriaFiscalSerialSimplificadaCrz(int inicio, int fim)
        {
            try
            {
                var leitura = Impressora.RelatoriosFiscais.ReceberLeituraMemoriaFiscal(
                    inicio,
                    fim,
                    true);
                Utils.GravarArquivo(LocalArquivosRelatoriosFiscais + "LMF" + FormataData(DateTime.Now) + ".txt", leitura);
            }
            catch (Bematech.BematechException ex)
            {
                ExibeMensagem("Erro ao emitir leitura da memória fiscal.\n" + ex.Message);
                return false;
            }
            return true;
        }



        public override bool LeituraMemoriaFiscalSerialCompletaData(DateTime inicio, DateTime fim)
        {
            try
            {
                var leitura = Impressora.RelatoriosFiscais.ReceberLeituraMemoriaFiscal(
                    inicio,
                    fim,
                    false);
                Utils.GravarArquivo(LocalArquivosRelatoriosFiscais + "LMF" + FormataData(DateTime.Now) + ".txt", leitura);
            }
            catch (Bematech.BematechException ex)
            {
                ExibeMensagem("Erro ao emitir leitura da memória fiscal.\n" + ex.Message);
                return false;
            }
            return true;
        }

        public override bool LeituraMemoriaFiscalSerialCompletaCrz(int inicio, int fim)
        {
            try
            {
                var leitura = Impressora.RelatoriosFiscais.ReceberLeituraMemoriaFiscal(
                    inicio,
                    fim,
                    true);
                Utils.GravarArquivo(LocalArquivosRelatoriosFiscais + "LMF" + FormataData(DateTime.Now) + ".txt", leitura);
            }
            catch (Bematech.BematechException ex)
            {
                ExibeMensagem("Erro ao emitir leitura da memória fiscal.\n" + ex.Message);
                return false;
            }
            return true;
        }

        public override bool Sangria(decimal valor, string mensagem)
        {
            try
            {
                Impressora.OperacaoNaoFiscal.ExecutarSangria(valor);
            }
            catch (Bematech.BematechException ex)
            {
                ExibeMensagem("Erro ao emitir leitura da memória fiscal.\n" + ex.Message);
                return false;
            }
            return true;
        }

        public override bool Suprimento(decimal valor, string mensagem)
        {
            try
            {
                Impressora.OperacaoNaoFiscal.ExecutarSuprimento(valor, mensagem);
            }
            catch (Bematech.BematechException ex)
            {
                ExibeMensagem("Erro ao emitir leitura da memória fiscal.\n" + ex.Message);
                return false;
            }
            return true;
        }

        public override bool ImprimeConfiguracao()
        {
            MessageBox.Show(MensagemNaoSuportada);
            return false;
        }

        public override bool ImprimeReducaoZ()
        {
            try
            {
                Impressora.RelatoriosFiscais.ImprimirReducaoZ();
            }
            catch (Bematech.BematechException ex)
            {
                ExibeMensagem("Erro ao emitir redução Z.\n" + ex.Message);
                return false;
            }
            return true;
        }

        public override bool ImprimeRelatorioGerencial(string texto)
        {
            try
            {
                Impressora.OperacaoNaoFiscal.AbrirGerencial(texto);
            }
            catch (Bematech.BematechException ex)
            {
                ExibeMensagem("Erro ao emitir relatório gerêncial.\n" + ex.Message);
                return false;
            }
            return true;
        }

        public override decimal VendaBruta()
        {
            try
            {
                return Impressora.Informacao.VendaBruta;
            }
            catch (Exception ex)
            {

                ExibeMensagem("Erro ao obter venda bruta.\n" + ex.Message);
                return 0;
            }

        }

        public override decimal VendaLiquida()
        {
            try
            {
                return 0;
            }
            catch (Exception ex)
            {

                ExibeMensagem("Erro ao obter venda líquida.\n" + ex.Message);
                return 0;
            }

        }

        public override sealed void ReducaoZPendente()
        {
            try
            {
                var dataUltimaZ = DataUltimaReducaoZ();
                var dataMovimento = DataMovimento();

                var cal = CultureInfo.CurrentCulture.Calendar;

                if (dataUltimaZ.Date.Equals(dataMovimento.Date))
                {
                    return;
                }
                if (dataUltimaZ.Equals(cal.AddDays(DateTime.Now, -1)) &&
                    UltimaReducaoZ().Equals(cal.AddDays(DateTime.Now, -1)))
                {
                    ImprimeReducaoZ();
                    UltimaReducaoZ();
                }
                if (dataUltimaZ.Equals(DateTime.Now) && dataMovimento.Ticks <= 1)
                {
                    MessageBox.Show("Redução Z já emitida para o dia atual.\n" +
                                    "Não é possível realizar nenhuma operação até o proximo dia.");
                    Process.GetCurrentProcess().Kill();

                }

            }
            catch (Exception)
            {
                ExibeMensagem("Erro ao verificar se há reduções pendentes.");
            }
        }

        public override DateTime DataMovimento()
        {
            try
            {
                return Impressora.Informacao.DataMovimento;
            }
            catch (Exception)
            {

                throw;
            }
        }

        public override DateTime DataUltimaReducaoZ()
        {
            try
            {
                return Impressora.Informacao.DataHoraUltimaReducao;
            }
            catch (Exception)
            {

                throw;
            }
        }

        public override bool EspelhoMfdData(DateTime inicio, DateTime fim)
        {
            try
            {
                ExibeMensagem(MensagemNaoSuportada);
            }
            catch (Bematech.BematechException ex)
            {
                ExibeMensagem("Erro ao ao gravar espelho Mfd.\n" + ex.Message);
                return false;
            }
            return true;
        }

        public override bool EspelhoMfdCrz(int inicio, int fim)
        {
            MessageBox.Show(MensagemNaoSuportada);
            return false;
        }

        public override bool ArquivoMfdData(DateTime inicio, DateTime fim)
        {

            return false;
        }

        public override bool ArquivoMfdCrz(int inicio, int fim)
        {
            MessageBox.Show(MensagemNaoSuportada);
            return false;
        }


        public override bool TravaTeclado()
        {
            try
            {
                Impressora.TEF.TravarTeclado(true);
            }
            catch (Bematech.BematechException ex)
            {
                ExibeMensagem("Erro ao travar teclado.\n" + ex.Message);
                return false;
            }
            return true;
        }

        public override bool DestravaTeclado()
        {
            try
            {
                Impressora.TEF.TravarTeclado(false);
            }
            catch (Bematech.BematechException ex)
            {
                ExibeMensagem("Erro ao destravar o teclado.\n" + ex.Message);
                return false;
            }
            return true;
        }

        public override RetornoTef EnviarSolicitacao(IList<Pagamento> pagamentos)
        {
            MessageBox.Show(MensagemNaoSuportada);
            return RetornoTef.Sucesso;
        }

        public override bool ImprimirTef()
        {
            MessageBox.Show(MensagemNaoSuportada);
            return false;
        }

        public override sealed bool VerificaImpressora()
        {
            try
            {
                if (Impressora == null)
                {
                    Impressora = ImpressoraFiscal.Construir();
                }
                ReducaoZPendente();
                return true;
            }
            catch (Bematech.BematechException ex)
            {
                return false;
            }
        }

        public override IList<ClassesRelacionadas.Aliquota> ExibeAliquotasCadastradas()
        {
            MessageBox.Show(MensagemNaoSuportada);
            return null;
        }

        public override ReducaoZ UltimaReducaoZ()
        {
            try
            {
                var reducaoBema = Impressora.Informacao.DadosUltimaReducao;
                var reducao = new ReducaoZ()
                {
                    AcrescimoIcms = reducaoBema.AcrescimoICMS,
                    AcrescimoIss = reducaoBema.AcrescimoISSQN,
                    AcressimosNf = reducaoBema.AcrescimosNaoFiscais,
                    CancelamentoIcms = reducaoBema.CancelamentoICMS,
                    CancelamentoIss = reducaoBema.CancelamentoISSQN,
                    CancelamentosNf = reducaoBema.CancelamentosNaoFiscais,
                    Ccf = reducaoBema.CupomFinal,
                    Cfc = reducaoBema.NumeroCupomReducao
                };
                return reducao;
            }
            catch (Exception)
            {

            }
            return null;
        }

        public override sealed bool ImpressoraLigada()
        {
            return true;
        }


        public override bool CadastrarAliquota(decimal aliquota, TipoAliquota tipoAliquota)
        {
            try
            {
                if (tipoAliquota == TipoAliquota.Icms)
                {
                    Impressora.Inicializacao.ProgramarAliquota(aliquota, Aliquota.TipoAliquota.ICMS);

                }
                else
                {
                    Impressora.Inicializacao.ProgramarAliquota(aliquota, Aliquota.TipoAliquota.ISS);
                }

            }
            catch (Bematech.BematechException ex)
            {
                MessageBox.Show("Erro ao cadastrar alíquota.\n" + ex.Message);
                return false;
            }
            return true;
        }

        public override bool CadastrarFormaPagamento(string formaPagamento)
        {
            throw new NotImplementedException();
        }
    }
}
