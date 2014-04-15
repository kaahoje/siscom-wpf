using System;
using System.Collections.Generic;
using Erp.Business.Entity.Contabil.Pessoa.SubClass.PessoaFisica;
using Erp.Business.Entity.Contabil.Pessoa.SubClass.PessoaJuridica.SubClass.ParceiroNegocio;

namespace Erp.Suporte.Business.Entity.Suporte
{
    public class SolicitacaoSuporte
    {
        public virtual int Id { get; set; }
        /// <summary>
        /// Número de protocolo gerado para identificar a solicitação pelo cliente.
        /// </summary>
        public virtual string ProtocoloAtendimento { get; set; }
        /// <summary>
        /// Data e hora de entrada do pedido de suporte.
        /// </summary>
        public virtual DateTime DataEntrada { get; set; }
        /// <summary>
        /// Data e hora do primeiro acesso à solicitação pela equipe de suporte.
        /// </summary>
        public virtual DateTime DataAcesso { get; set; }
        /// <summary>
        /// Data e hora do término do atendimento.
        /// </summary>
        public virtual DateTime DataTerminoAtendimento { get; set; }
        /// <summary>
        /// Descrição do problema feito pelo cliente.
        /// </summary>
        public virtual string RelatoProblema { get; set; }
        /// <summary>
        /// Data e hora da ocorrência do problema que originou o suporte.
        /// </summary>
        public virtual DateTime DataOcorrencia { get; set; }
        /// <summary>
        /// Informação da empresa que solicitou o suporte.
        /// </summary>
        public virtual ParceiroNegocioPessoaJuridica EmpresaSolicitante { get; set; }
        /// <summary>
        /// Informação da pessoa que solicitou o suporte para a empresa.
        /// </summary>
        public virtual PessoaFisica Solicitante { get; set; }
        /// <summary>
        /// Lista de atendentes que participaram da solicitação de suporte.
        /// </summary>
        public virtual IList<PessoaFisica> Atendentes { get; set; }
        /// <summary>
        /// Nota dada pelo cliente ao atendimento recebido.
        /// </summary>
        public virtual int Nota { get; set; }
    }
}
