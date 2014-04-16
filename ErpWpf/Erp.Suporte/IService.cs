using System;
using System.Collections.Generic;
using System.IO;
using System.ServiceModel;
using Erp.Suporte.Business.Entity.Licenca;
using Erp.Suporte.Business.Entity.Suporte;
using Erp.Suporte.Business.Enum;

namespace Erp.Suporte
{
    // NOTE: You can use the "Rename" command on the "Refactor" menu to change the interface name "IService1" in both code and config file together.
    [ServiceContract]
    public interface IService
    {
        /// <summary>
        /// Método que recebe um log de erro da aplicação.
        /// </summary>
        /// <param name="stackTrace">StackTrace do erro</param>
        [OperationContract]
        void Log(string stackTrace);
        /// <summary>
        /// Método que recebe um log de erro do banco de dados.
        /// </summary>
        /// <param name="stackTrace">StackTrace do erro</param>
        [OperationContract]
        void LogDataBase(string stackTrace);
        /// <summary>
        /// Método que recebe uma requisição de licença do usuário do sistema.
        /// </summary>
        /// <param name="requisicao">Requisição de licença</param>
        /// <returns>Código de ativação da aplicação</returns>
        [OperationContract]
        string RequestLicense(LicencaConcedida requisicao);
        /// <summary>
        /// Método que verifica se a licença do aplicativo é válida.
        /// </summary>
        /// <param name="codigo">Código de ativação usado pelo cliente.</param>
        /// <returns></returns>
        [OperationContract]
        bool LicenceActivated(string codigo);
        /// <summary>
        /// Verifica o estado da licença à qual pertence o código e retorna a situação da mesma.
        /// </summary>
        /// <param name="codigo"></param>
        /// <returns></returns>
        StatusLicenca LicenseSituation(string codigo);
        /// <summary>
        /// Método que verifica se a lista de arquivos enviada está atualizada.
        /// </summary>
        /// <param name="licenca">Dados da licença do usuário da aplicação.</param>
        /// <param name="currentFileList">Lista contendo o caminho relativo do arquivo e sua respectiva versão.</param>
        /// <returns>Lista com o caminho relativo do arquivo a ser atualizado e seu respectivo stream de dados.</returns>
        [OperationContract]
        Dictionary<String, FileStream> RequestUpdate(LicencaConcedida licenca, Dictionary<string,string> currentFileList);
        /// <summary>
        /// Método para a solicitação de suporte por meio do sistema de suporte do aplicativo.
        /// </summary>
        /// <param name="licenca">Dados da licença do usuário</param>
        /// <param name="solicitacao">Dados da solicitação de suporte que está sendo feita.</param>
        /// <returns>Solicitação de suporte processada.</returns>
        [OperationContract]
        SolicitacaoSuporte RequestSuport(LicencaConcedida licenca, SolicitacaoSuporte solicitacao);
    }


    
}
