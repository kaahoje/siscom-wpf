using System;
using System.Collections.Generic;
using Ecf.Enum;
using Ecf.ImplementacaoEcf.ClassesRelacionadas;
using Erp.Business.Entity.Vendas.Ecf;
using Erp.Business.Enum;

namespace Ecf
{
    public abstract class AbstractEcf
    {
        public const string MensagemNaoSuportada = "Função  não  suportada  pelo  " +
                                                      "modelo  de  ECF utilizado ";

        public string LocalArquivosRelatoriosFiscais { get; set; }
        
        public string ArquivoTefSolicitacao { get; set; }

        protected Dictionary<int, String> Aliquotas { get; set; }

        #region Funções de formatação

        public abstract object FormataNumero(decimal valor);

        public abstract string FormataPercentual(decimal valor);

        public abstract Decimal ToDecimal(String valor);
        public abstract DateTime ToDate(string valor);
        public abstract String FormataData(DateTime data);

        public abstract String FormataHora(DateTime hora);

        public abstract String FormataCrz(int numero);

        #endregion

        #region Funções de cupom fiscal.

        public abstract int UltimoCupomEmitido();

        /// <summary>
        ///  Este método abre um Cupom Fiscal, identificando consumidor.
        ///  </summary><param name="cliente">Informações do Consumidor</param><param name="nome">Nome Consumidor</param><param name="endereco">Endereço Consumidor</param>
        public abstract bool AbrirCupom(ClienteCupom cliente);

        /// <summary>
        ///  Este método acrescenta um item vendido no Cupom Fiscal. 
        ///  </summary><param name="cargaTributaria">A alíquota do item pode ser informada 
        ///  através da posição dela cadastrada com o comando ou valor da alíquota pode ser informado 
        ///  diretamente </param><param name="quantidade">Quantidade do Item</param>
        /// <param name="precoUnitario">Preço Unitário do Item.</param>
        /// <param name="tipoDescontoAcressimo">SubGrupo de Acréscimo ou Desconto no Item.</param>
        /// <param name="valorDescontoAcressimo">Valor do desconto ou acréscimo ou Valor da porcentagem.</param>
        /// <param name="codigoItem">Código do Item.</param>
        /// <param name="unidadeMedida">Unidade de medida.</param>
        /// <param name="descricaoItem">Descrição do Item.</param>
        /// <param name="tributacao">Valor dos tributos sobre o item.</param>
        /// <param name="tipoProduto">Parametro que identifica se o item é um produto, mercadoria ou serviço.</param>
        public abstract bool VenderItem(SituacaoTributaria cargaTributaria,
            TipoProduto tipoProduto,
            decimal quantidade, decimal precoUnitario,
            TipoDescontoAcressimo tipoDescontoAcressimo,
            decimal valorDescontoAcressimo,
            int codigoItem,
            string unidadeMedida,
            string descricaoItem,
            decimal tributacao);

        /// <summary>
        /// Método que obtém o prefixo do tipo de tributação a ser informado no item.
        /// </summary>
        /// <param name="situacaoTributaria">Situação tributária do item.</param>
        /// <param name="tipoProduto">Tipo de produto.</param>
        /// <returns></returns>
        protected abstract string PrefixoImposto(SituacaoTributaria situacaoTributaria, TipoProduto tipoProduto);
        /// <summary>
        ///  Este método permite aplicar desconto no item do cupom fiscal antes da totalização.
        ///  </summary><param name="numeroItem">Número do Item</param><param name="tipoDesconto">SubGrupo Desconto</param><param name="valorDesconto">Valor do Desconto ou Valor da porcentagem.</param>
        public abstract bool LancarDescontoItem(int numeroItem, TipoDescontoAcressimo tipoDesconto, decimal valorDesconto);

        /// <summary>
        ///  Este método permite aplicar acréscimo no item do cupom fiscal antes da totalização.
        ///  </summary><param name="numeroItem">Número do Item</param><param name="tipoDescontoAcressimo">SubGrupo Acréscimo</param><param name="valorAcressimo">Valor do acréscimo ou Valor da porcentagem.</param>
        public abstract bool LancarAcressimoItem(int numeroItem, TipoDescontoAcressimo tipoDescontoAcressimo, decimal valorAcressimo);

        /// <summary>
        ///  Este método permite aplicar desconto no último item do cupom fiscal
        ///  </summary><param name="tipoDesconto">SubGrupo Desconto</param><param name="valorDesconto">Valor do Desconto ou Valor da porcentagem.</param>
        public abstract bool LancarDescontoUltimoItem(TipoDescontoAcressimo tipoDesconto, decimal valorDesconto);

        /// <summary>
        ///  Este método permite aplicar acréscimo no último item do cupom fiscal. 
        ///  </summary><param name="tipoDescontoAcressimo">SubGrupo Acréscimo</param><param name="valorAcressimo">Valor do acréscimo ou Valor da porcentagem.</param>
        public abstract bool LancarAcressimoUltimoItem(TipoDescontoAcressimo tipoDescontoAcressimo, decimal valorAcressimo);

        /// <summary>
        ///  Este método permite o cancelamento total de item em cupom fiscal.
        ///  </summary><param name="numeroItem">Número do Item</param>
        public abstract bool CancelarItem(int numeroItem);

        /// <summary>
        ///  Este método cancela o desconto aplicado sobre um item vendido no cupom fiscal atual.
        ///  </summary><param name="numeroItem">Número do Item</param>
        public abstract bool CancelarDescontoItem(int numeroItem);

        /// <summary>
        ///  Este método cancela o desconto aplicado sobre o último item vendido no cupom fiscal atual.
        ///  </summary>
        public abstract bool CancelaDescontoUltimoItem();

        /// <summary>
        ///  Este método cancela o acréscimo aplicado sobre um item vendido no cupom fiscal atual.
        ///  </summary><param name="numeroItem"></param>
        public abstract bool CancelaAcressimoItem(int numeroItem);

        /// <summary>
        ///  Este método cancela o acréscimo aplicado sobre o último item vendido no cupom fiscal atual. 
        ///  </summary>
        public abstract bool CancelaAcressimoUltimoItem();

        /// <summary>
        ///  Este método cancela o desconto aplicado sobre o subtotal do cupom fiscal atual.
        ///  </summary>
        public abstract bool CancelarDescontoSubTotal();

        /// <summary>
        ///  Este método cancela o acréscimo aplicado sobre o subtotal do cupom fiscal atual. 
        ///  </summary>
        public abstract bool CancelarAcressimoSubTotal();

        /// <summary>
        ///  Este método cancela parcialmente um item, eliminando a quantidade passada por parâmetro do item informado.
        ///  </summary><param name="numeroItem">Número do Item</param><param name="quantidade">Quantidade a cancelar</param>
        public abstract bool CancelaItemParcial(int numeroItem, decimal quantidade);

        /// <summary>
        ///  Este método permite o cancelamento do último item em cupom fiscal. 
        ///  </summary>
        public abstract bool CancelarUltimoItem();

        /// <summary>
        ///  Este método cancela parcialmente o ultimo item, eliminando a quantidade passada por parâmetro.
        ///  </summary><param name="quantidade">Quantidade a cancelar</param>
        public abstract bool CancelarUltimoItemParcial(decimal quantidade);

        public abstract bool IniciaFechamentoCupom(TipoDescontoAcressimo tipoDescAcresc,
            decimal desconto, decimal acrescimo);

        /// <summary>
        ///  Este método totaliza o cupom fiscal, realizando a soma dos itens vendidos e 
        ///  aplicando acréscimo ou desconto estabelecido.
        ///  </summary><param name="tipoDescontoAcressimo">SubGrupo Acréscimo ou Desconto</param><param name="valorDescontoAcressimo">Valor do acréscimo ou valor da porcentagem.</param>
        public abstract bool TotalizarCupomFiscal(TipoDescontoAcressimo tipoDescontoAcressimo, decimal valorDescontoAcressimo);

        /// <summary>
        ///  Realiza o pagamento do cupom fiscal, definindo a forma de pagamento, 
        ///  o valor pago  com a forma escolhida e a impressão de um texto adicional. 
        ///  </summary><param name="formaPagamento">Descrição da forma de pagamento</param><param name="valor">Valor da forma de pagamento</param><param name="informacaoAdicional">Informação Adicional</param>
        public abstract bool EfetuarPagamento(string formaPagamento, decimal valor, string informacaoAdicional);

        /// <summary>
        ///  Realiza o pagamento do cupom fiscal, definindo a forma de pagamento e o valor pago com a forma escolhida.
        ///  </summary><param name="formaPagamento">Descrição da forma de pagamento</param><param name="valor">Valor da forma de pagamento</param>
        public abstract bool EfetuarPagamento(string formaPagamento, decimal valor);

        /// <summary>
        ///  Este método realiza o pagamento do cupom fiscal com a forma de pagamento default - Dinheiro.
        ///  </summary>
        public abstract bool EfetuarPagamentoPadrao();

        /// <summary>
        ///  Este método permite retirar o valor de uma forma de pagamento e transferir em outra forma.
        ///  </summary><param name="formaPagamentoEstornado">Descrição da forma de pagamento a estornar.</param><param name="formaPagamento">Descrição da forma de pagamento a ser alterada.</param><param name="valor">Valor da forma de pagamento.</param><param name="informacaoAdicional">Informação Adicional.</param>
        public abstract bool ExtornarPagamento(string formaPagamentoEstornado, string formaPagamento, decimal valor, string informacaoAdicional);

        /// <summary>
        ///  Este método imprime a Identificação do Consumidor no cupom fiscal, ele pode ser chamado a 
        ///  qualquer momento entre a abertura do cupom e a finalização do mesmo. 
        ///  </summary>
        ///  /// <param name="cliente">Identificação do Consumidor</param><param name="nome">Nome Consumidor</param><param name="endereco">Endereço Consumidor</param>
        public abstract bool IdentificaConsumidor(ClienteCupom cliente);

        /// <summary>
        ///  Este método finaliza o cupom fiscal, de forma resumida sem mensagem promocional.
        ///  </summary>
        public abstract bool EncerrarCupom();

        /// <summary>
        ///  Este método finaliza o cupom fiscal, com a opção de emitir cupom adicional ou não com a 
        ///  mensagem promocional informada.
        ///  </summary><param name="cupomFiscalAdicional">Define se será impresso o cupom fiscal adicional e em que
        ///  forma será impresso este.</param><param name="mensagem">Mensagem promocional.</param>
        public abstract bool EncerrarCupom(CupomFiscalAdicional cupomFiscalAdicional, string mensagem);

        /// <summary>
        ///  Este método finaliza o cupom fiscal com a mensagem promocional informada.
        ///  </summary><param name="mensagem">Mensagem promocional.</param>
        public abstract bool EncerrarCupom(string mensagem);

        /// <summary>
        ///  Este método permite cancelar o cupom fiscal.
        ///  </summary>
        public abstract bool CancelarCupom();

        /// <summary>
        ///   Emite um resumo do último Cupom Fiscal emitido, com Número do cupom, Valor e Data.
        ///  </summary>
        public abstract bool EmitirCupomAdicional();

        /// <summary>
        ///  Este método retorna o saldo total a pagar do cupom fiscal atual. 
        ///  </summary>
        public abstract decimal SaldoAtualCupomFiscal();

        /// <summary>
        ///  Este método retorna o subtotal do cupom fiscal atual, ou seja, a soma do valor 
        ///  dos itens vendidos até o momento em que essa função foi chamada.
        ///  </summary>
        public abstract decimal SubTotalCupomFiscal();

        /// <summary>
        ///  Este método retorna o status atual do cupom fiscal.
        ///  </summary>
        public abstract StatusCupomFiscal VerificaStatusCupomFiscal();

        /// <summary>
        ///  Este método retorna o Total de ISS e ICMS contabilizado no último cupom fiscal. 
        ///  </summary><param name="icms">Valor total de ICMS acumulados do último cupom fiscal.</param><param name="iss">Valor total de ISS acumulados do último cupom fiscal.</param>
        public abstract bool TotalIcmsIssUltimoCupom(ref decimal icms, ref decimal iss);
        #endregion

        #region Funções de relatórios fiscais.

        /// <summary>
        /// Este método imprimi uma Leitura X.
        /// </summary>
        public abstract bool ImprimeLeituraX();
        /// <summary>
        /// Este método que imprime uma leitura x e lança o caixa.
        /// </summary>
        /// <param name="caixaInicial">Valor inicial do caixa</param>
        
        /// <returns></returns>
        public abstract bool ImprimeLeituraX(decimal caixaInicial);
        /// <summary>
        /// Este método gera Leitura X em arquivo. 
        /// </summary>
        public abstract bool GravaLeituraX();

        #region Funções para leitura da memória fiscal

        public abstract bool LeituraMemoriaFiscalSimplificadaData(
            DateTime inicio,
            DateTime fim);

        public abstract bool LeituraMemoriaFiscalSimplificadaCrz(
            int inicio,
            int fim);

        public abstract bool LeituraMemoriaFiscalCompletaData(
            DateTime inicio,
            DateTime fim);

        public abstract bool LeituraMemoriaFiscalCompletaCrz(
            int inicio,
            int fim);

        public abstract bool LeituraMemoriaFiscalSerialSimplificadaData(
            DateTime inicio,
            DateTime fim
            );

        public abstract bool LeituraMemoriaFiscalSerialSimplificadaCrz(
            int inicio,
            int fim
            );

        public abstract bool LeituraMemoriaFiscalSerialCompletaData(
            DateTime inicio,
            DateTime fim
            );

        public abstract bool LeituraMemoriaFiscalSerialCompletaCrz(
            int inicio,
            int fim
            );

        #endregion


        /// <summary>
        /// Este método usado para retirar uma quantia de dinheiro do Caixa, e informando 
        /// uma mensagem com texto livre.
        /// </summary>
        /// <param name="valor">Valor da sangria</param>
        /// <param name="mensagem">Texto descritivo da sangria</param>
        public abstract bool Sangria(
            decimal valor,
            string mensagem);

        /// <summary>
        /// Este método usado para dar entrada de uma quantia de 
        /// dinheiro do Caixa, e informando uma mensagem com texto livre.
        /// </summary>
        /// <param name="valor">Valor da sangria</param>
        /// <param name="mensagem">Texto descritivo da sangria</param>
        public abstract bool Suprimento(
            decimal valor,
            string mensagem
            );

        /// <summary>
        /// Este método imprime em um relatório gerencial as configurações da impressora.
        /// </summary>
        public abstract bool ImprimeConfiguracao();

        /// <summary>
        /// Este método emite a Redução Z e encerra a jornada fiscal.
        /// </summary>
        public abstract bool ImprimeReducaoZ();

        #endregion

        #region Relatórios gerenciais

        /// <summary>
        /// Este método imprime texto do Relatório Gerencial. 
        /// </summary>
        /// <param name="texto">Texto do relatório gerencial</param>
        public abstract bool ImprimeRelatorioGerencial(string texto);

        public abstract Decimal VendaBruta();

        public abstract Decimal VendaLiquida();
        /// <summary>
        /// Método que verifica se há uma redução Z pendente. Em caso afirmativo emite a redução Z pendente.
        /// </summary>
        public abstract void ReducaoZPendente();

        public abstract DateTime DataMovimento();
        public abstract DateTime DataUltimaReducaoZ();
        #endregion

        #region PAF-ECF


        public abstract bool EspelhoMfdData(
            DateTime inicio,
            DateTime fim
            );

        public abstract bool EspelhoMfdCrz(
            int inicio,
            int fim
            );

        public abstract bool ArquivoMfdData(
            DateTime inicio,
            DateTime fim
            );

        public abstract bool ArquivoMfdCrz(
            int inicio,
            int fim
            );



        #endregion

        #region Funções TEF

        public abstract bool TravaTeclado();

        public abstract bool DestravaTeclado();

        public abstract RetornoTef EnviarSolicitacao(IList<Pagamento> pagamentos);

        public abstract bool ImprimirTef();

        #endregion

        #region Funções auxiliares

        public abstract bool VerificaImpressora();

        public abstract IList<Aliquota> ExibeAliquotasCadastradas();

        public abstract ReducaoZ UltimaReducaoZ();

        public abstract bool ImpressoraLigada();


        #endregion

        #region Funções de configuração.

        public abstract bool CadastrarAliquota(decimal aliquota, TipoAliquota tipoAliquota);

        public abstract bool CadastrarFormaPagamento(String formaPagamento);

        #endregion
    }
}
