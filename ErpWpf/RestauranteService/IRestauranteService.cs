using System;
using System.Collections.Generic;
using System.ServiceModel;
using Erp.Business.Annotations;
using Erp.Business.Entity.Vendas.Pedido.ClassesRelacionadas;
using Erp.Business.Entity.Vendas.Pedido.Restaurante;
using Erp.Business.Entity.Vendas.Pedido.Restaurante.ClassesRelacionadas;
using RestauranteService.DataContracts;

namespace RestauranteService
{
    // NOTE: You can use the "Rename" command on the "Refactor" menu to change the interface name "IService1" in both code and config file together.
    [ServiceContract]
    public interface IRestauranteService
    {
        [OperationContract]
        StatusComando TrocarMesa(int origem, int destino);
        [OperationContract]
        StatusComando JuntarMesa(int origem, int destino);
        [OperationContract]
        PedidoRestaurante GetMesa(int mesa);
        [OperationContract]
        PedidoRestaurante GetEntrega(int controle);
        [OperationContract]
        PedidoRestaurante NovaMesa(int mesa);
        [OperationContract]
        PedidoRestaurante NovoBalcao();
        [OperationContract]
        PedidoRestaurante NovaEntrega();

        /// <summary>
        /// Solicitação feita pelo garçon do estabelecimento ao sistema.
        /// </summary>
        /// <param name="mesa">Número da mesa.</param>
        /// <param name="idGarcon">Número de identificação do garçon</param>
        /// <returns>Solicitação de parcial gerada pelo serviço do sistema</returns>
        [OperationContract]
        ParcialMesaDataContract ParcialMesa(int mesa, int idGarcon);
        /// <summary>
        /// Lista de parciais solicitadas pelo garçon.
        /// </summary>
        /// <param name="idGarcon">Número de identificação do garçon para saber quais parciais ele solicitou.</param>
        /// <returns>Lista de parciais solicitadas pelo garçon</returns>
        [OperationContract]
        IList<ParcialMesaDataContract> ParciaisSolicitadas(int idGarcon);
        /// <summary>
        /// Função para o caixa que está com a impressora livre fazer a impressão das parciais pendentes.
        /// </summary>
        /// <returns></returns>
        [OperationContract]
        ParcialMesaDataContract ParcialPendente();
        /// <summary>
        /// Comando executado pelo caixa após a impressão da parcial
        /// </summary>
        /// <param name="idGuid">Identificador da parcial no serviço.</param>
        /// <param name="caixa">Caixa que emitiu a parcial.</param>
        /// <returns></returns>
        [OperationContract]
        StatusComando ConfirmarImpressaoParcial(Guid idGuid, int caixa);
        [OperationContract]
        StatusComando ConfirmarPedido(PedidoRestaurante pedido);
        /// <summary>
        /// Método que retorna as mesas em aberto.
        /// </summary>
        /// <returns></returns>
        [OperationContract]
        IList<PedidoRestaurante> GetMesasAbertas();
        [OperationContract]
        StatusComando FecharMesa(int mesa);
        [OperationContract]
        StatusComando FecharEntrega(int controle);
        [OperationContract]
        StatusComando CancelarMesa(int mesa);
        [OperationContract]
        StatusComando CancelarEntrega(int controle);
        [OperationContract]
        StatusComando CancelarItemMesa(int mesa, ComposicaoProduto composicao);
        /// <summary>
        /// Método que cancela um item na lista de composição do produto. Esta operação está disponível para pedidos
        /// que foram confirmados e não foram produzidos.
        /// </summary>
        /// <param name="mesa">Número da mesa.</param>
        /// <param name="composicao">Identificador da composição.</param>
        /// <param name="produto">Identificador do produto na composição.</param>
        /// <returns></returns>
        [OperationContract]
        StatusComando CancelarItemComposicaoMesa(int mesa, Guid composicao, Guid produto);
        [OperationContract]
        StatusComando AdicionarItemComposicaoMesa(int mesa, Guid composicao, ProdutoPedido produto);
        [OperationContract]
        StatusComando AdicionarItemMesa(int mesa, ComposicaoProduto composicao);
        /// <summary>
        /// Método que calcula o valor do produto e retorna o indice do produto base da cobrança e o preço a ser
        /// cobrado.
        /// </summary>
        /// <param name="produtos">Lista de produtos para verificação.</param>
        /// <returns>Dictionary com o indice do produto base da cobrança na lista passada e o valor a ser cobrado.</returns>
        [OperationContract]
        Dictionary<int, decimal> VerificaProdutoCobranca(IList<ProdutoPedido> produtos);
        [OperationContract]
        string GetLastException();

        ControlePedido NovoControle();
    }



}
