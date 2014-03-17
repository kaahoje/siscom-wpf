using System;
using System.ComponentModel.DataAnnotations;
using Erp.Business.Annotations;
using Erp.Business.Enum;


namespace Erp.Business.Entity.Contabil.Pessoa.ClassesRelacionadas
{
    /// <summary>
    /// Classe que define a estrutura de um registro de telefone.
    /// </summary>
    [Serializable]
    public class PessoaTelefone
    {
        public PessoaTelefone()
        {
            IdGuid = Guid.NewGuid();
        }
        /// <summary>
        /// Identificador.
        /// </summary>
        public virtual int Id { get; set; }
        public virtual Guid IdGuid { get; set; }
        /// <summary>
        /// DDI Pais
        /// </summary>
        [Required(ErrorMessage = Constants.MessageRequiredError)]
        [GridAnnotation(Order = 0, Visible = true, Width = 100)]
        [Display(Name = "DDI", Description = "DDI do telefone")]
        //[Range(2, 3, ErrorMessage = "O campo {0} deve ter {2} caracteres.")]
        public virtual string DdiPais { get; set; }

        /// <summary>
        /// DDI Pais
        /// </summary>
        [Required(ErrorMessage = Constants.MessageRequiredError)]
        [GridAnnotation(Order = 1, Visible = true, Width = 100)]
        [Display(Name = "DDD", Description = "DDD do telefone")]
        public virtual string DddTelefone { get; set; }

        /// <summary>
        /// Número do telefone.
        /// </summary>
        [Required(ErrorMessage = Constants.MessageRequiredError)]
        [GridAnnotation(Order = 2, Visible = true, Width = 150)]
        [Display(Name = "Número", Description = "Número do telefone")]
        public virtual string Numero { get; set; }

        /// <summary>
        /// Ramal.
        /// </summary>
        [GridAnnotation(Order = 4, Visible = true, Width = 100)]
        [Display(Name = "Ramal", Description = "Ramal do telefone")]
        public virtual string Ramal { get; set; }

        /// <summary>
        /// Pessoa que possui o número de telefone.
        /// </summary>
        public virtual Pessoa Pessoa { get; set; }
        /// <summary>
        /// Tipo de telefone.
        /// </summary>
        [Required(ErrorMessage = Constants.MessageRequiredError)]
        [GridAnnotation(Order = 5, Visible = true, Width = 200)]
        [Display(Name = "Tipo", Description = "Tipo do telefone")]
        public virtual TelefoneTipo TelefoneTipo { get; set; }

        /// <summary>
        /// Status do registro.
        /// </summary>
        public virtual Status Status { get; set; }
    }
}