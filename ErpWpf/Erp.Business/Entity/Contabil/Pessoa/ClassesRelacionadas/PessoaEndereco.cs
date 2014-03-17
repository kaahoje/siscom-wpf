using System;
using System.ComponentModel.DataAnnotations;
using Erp.Business.Annotations;
using Erp.Business.Enum;

namespace Erp.Business.Entity.Contabil.Pessoa.ClassesRelacionadas
{
    /// <summary>
    /// Classe que define uma relação entre endereço e funcionário.
    /// </summary>
    [Serializable]
    public class PessoaEndereco
    {
        /// <summary>
        /// Identificador.
        /// </summary>
        public virtual int Id { get; set; }
        
        [GridAnnotation(Order = 0, Visible = true, Width = 0)]
        public virtual Guid IdGuid { get; set; }

        /// <summary>
        /// Referência ao funcionário.
        /// </summary>
        public virtual Pessoa Pessoa { get; set; }
        /// <summary>
        /// Referência ao endereço.
        /// </summary>
        public virtual Endereco.Endereco Endereco { get; set; }

        /// <summary>
        /// Guarda o endereço que foi informado manualmente pelo usuário.
        /// </summary>
        [StringLength(Constants.MaxLengthNames, MinimumLength = Constants.MinLengthNames, ErrorMessage = Constants.MessageLengthNameError)]
        [Required(ErrorMessage = Constants.MessageRequiredError)]
        [GridAnnotation(Order = 0, Visible = true, Width = 100)]
        [Display(Name = "Logradouro", Description = "Logradouro")]
        public virtual string Logradouro { get; set; }
        
        [Required(ErrorMessage = Constants.MessageRequiredError)]
        [GridAnnotation(Order = 1, Visible = true, Width = 100)]
        [Display(Name = "Número",Description = "Número do logradouro")]
        public virtual string Numero { get; set; }

        [GridAnnotation(Order = 2, Visible = true, Width = 100)]
        [Display(Name = "Complemento", Description = "Complemento do endereço")]
        public virtual string Complemento { get; set; }

        /// <summary>
        /// Guarda a informação que diz se o endereço foi informado manualmente.
        /// </summary>
        public virtual bool InformadoManualmente { get; set; }

        [Required(ErrorMessage = Constants.MessageRequiredError)]
        [GridAnnotation(Order = 3, Visible = true, Width = 100)]
        [Display(Name = "Tipo", Description = "Tipo de endereço")]
        public virtual TipoEndereco TipoEndereco { get; set; }

        [GridAnnotation(Order = 4, Visible = true, Width = 100)]
        [Display(Name = "Ponto de referência", Description = "Descrição detalhada do endereço.")]
        public virtual String PontoReferencia { get; set; }

        public virtual Status Status { get; set; }

        public PessoaEndereco()
        {
            IdGuid = Guid.NewGuid();
        }
    }
}
