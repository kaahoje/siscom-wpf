using System;

namespace Erp.Suporte.Business.Entity.Log
{
    public class LogSistema
    {
        public virtual int Id { get; set; }
        /// <summary>
        /// Data e hora do envio do erro para a equipe de desenvolvimento.
        /// </summary>
        public virtual DateTime DataEntrada { get; set; }
        /// <summary>
        /// Data e hora da primeira visualização do erro pela equipe de desenvolvimento.
        /// </summary>
        public virtual DateTime DataVisualizacao { get; set; }
        /// <summary>
        /// Data e hora da correção do erro pela equipe de desenvolvimento
        /// </summary>
        public virtual DateTime DataCorrecao { get; set; }
        /// <summary>
        /// Data e hora da comunicação feita ao cliente sobre a correção do erro.
        /// </summary>
        public virtual DateTime DataComunicacaoCliente { get; set; }
        /// <summary>
        /// Conteudo gerado após análise do erro no cliente e enviado ao servidor.
        /// </summary>
        public virtual string StackTrace { get; set; }
    }
}
