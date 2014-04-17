namespace RestauranteService
{
    public enum StatusComando
    {
        ConcluidoSucesso,
        ErroExecucao,
        ErroDados,
        OperacaoNaoPermitida,
        /// <summary>
        /// Esta opção serve para informar que somente o adminstrador/gerênte pode efetuar a operação.
        /// </summary>
        SolicitacaoAdministrador,
        /// <summary>
        /// Esta opção é quando for solicitada a troca de mesa para uma mesa já ocupada, dando a opção de trocar
        /// a mesa juntando o consumo das duas mesas.
        /// </summary>
        MesaAberta
    }
}