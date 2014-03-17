using System;
using System.ComponentModel.DataAnnotations;
using Erp.Business.Annotations;
using Erp.Business.Enum;

namespace Erp.Business.Entity.Contabil.Pessoa.ClassesRelacionadas
{
    /// <summary>
    /// Classe que define um endere�o eletr�nico.
    /// </summary>
     [Serializable]
    public class PessoaContatoEletronico
    {
        public PessoaContatoEletronico()
        {
            IdGuid = Guid.NewGuid();
        }
        /// <summary>
        /// Identificador.
        /// </summary>
        public virtual int Id { get; set; }
        public virtual Guid IdGuid { get; set; }
        /// <summary>
        /// Status do registro.
        /// </summary>
        public virtual Status Status { get; set; }
        /// <summary>
        /// Tipo de Contato Eletr�nico
        /// </summary>
        /// [Display(Name = "Data", Description = "Data do pedido")]
        [Required(ErrorMessage = Constants.MessageRequiredError)]
        [GridAnnotation(Order = 0, Visible = true, Width = 100)]
        [Display(Name = "Tipo", Description = "Tipo de e-mail")]
        public virtual TipoEmail Tipo { get; set; }
        /// <summary>
        /// Nick name utilizado no servi�o de e-mail.
        /// </summary>
        /// [Display(Name = "Data", Description = "Data do pedido")]
        [Required(ErrorMessage = Constants.MessageRequiredError)]
        [GridAnnotation(Order = 1, Visible = true, Width = 300)]
        [Display(Name = "E-Mail", Description = "E-mail")]
        public virtual string Nick { get; set; }
        /// <summary>
        /// Pessoa que � dona do contato eletr�nico.
        /// </summary>
        public virtual Pessoa Pessoa { get; set; }
    }
}