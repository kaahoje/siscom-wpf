using System;
using System.Collections.Generic;
using System.Runtime.Serialization;

namespace Erp.Suporte.Business.Entity.Suporte
{
    [DataContract]
    public class SolicitacaoSuporte
    {
        public virtual int Id { get; set; }
        /// <summary>
        /// Número de protocolo gerado para identificar a solicitação pelo cliente.
        /// </summary>
        [DataMember]
        public virtual string ProtocoloAtendimento { get; set; }
        /// <summary>
        /// Data e hora de entrada do pedido de suporte.
        /// </summary>
        [DataMember]
        public virtual DateTime DataEntrada { get; set; }
        /// <summary>
        /// Data e hora do primeiro acesso à solicitação pela equipe de suporte.
        /// </summary>
        [DataMember]
        public virtual DateTime DataAcesso { get; set; }
        /// <summary>
        /// Data e hora do término do atendimento.
        /// </summary>
        [DataMember]
        public virtual DateTime DataTerminoAtendimento { get; set; }
        /// <summary>
        /// Descrição do problema feito pelo cliente.
        /// </summary>
        [DataMember]
        public virtual string RelatoProblema { get; set; }
        /// <summary>
        /// Data e hora da ocorrência do problema que originou o suporte.
        /// </summary>
        [DataMember]
        public virtual DateTime DataOcorrencia { get; set; }
        /// <summary>
        /// Informação da pessoa que solicitou o suporte para a empresa.
        /// </summary>
        [DataMember]
        public virtual ResponsavelSolicitacaoSuporte Responsavel { get; set; }
        /// <summary>
        /// Lista de atendentes que participaram da solicitação de suporte.
        /// </summary>
        public virtual IList<Erp.Business.Entity.Contabil.Pessoa.SubClass.PessoaFisica.PessoaFisica> Atendentes { get; set; }
        /// <summary>
        /// Nota dada pelo cliente ao atendimento recebido.
        /// </summary>
        public virtual int Nota { get; set; }
    }
}
