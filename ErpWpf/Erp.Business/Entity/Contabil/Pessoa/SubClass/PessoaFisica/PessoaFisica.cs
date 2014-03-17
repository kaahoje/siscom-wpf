using System;
using System.ComponentModel.DataAnnotations;
using DevExpress.Web.ASPxGridView;
using Erp.Business.Annotations;
using Erp.Business.Common.CustomAttributes;
using Erp.Business.Enum;
using Erp.Business.Validation.CustomValidations;


namespace Erp.Business.Entity.Contabil.Pessoa.SubClass.PessoaFisica
{
    [Serializable]
    [PessoaFisicaValidation]
    public class PessoaFisica : Pessoa
    {
        [Display(Description = "Nome da pessoa.", Name = "Nome",Order = 1)]
        [DisplayFormat(NullDisplayText = Constants.NullTextGeneroMasculino)]
        [Required(ErrorMessage = Constants.MessageRequiredError)]
        [StringLength(Constants.MaxLengthNames, MinimumLength = Constants.MinLengthNames,
            ErrorMessage = Constants.MessageLengthNameError)]
        [GridAnnotation(Order = 0, Visible = true, Width = 250)]
        public virtual String Nome { get; set; }

        [Display(Description = "Apelido da pessoa.", Name = "Apelido",Order = 2)]
        [DisplayFormat(NullDisplayText = Constants.NullTextGeneroMasculino)]
        [GridAnnotation(Order = 1, Visible = false, Width = 200)]
        public virtual String Alias { get; set; }

        [Required(ErrorMessage = Constants.MessageRequiredError)]
        [Display(Description = "CPF da pessoa", Name = "CPF",Order = 3)]
        [DisplayFormat(DataFormatString = Constants.MaskCpf, NullDisplayText = Constants.NullTextGeneroMasculino)]
        [CustomValidation(typeof(CpfCnpjValidation), "IsCpfCnpjValid")]
        [Mask(Constants.MaskCpf)]
        [GridAnnotation(Order = 2, Visible = true, Width = 150)]
        public virtual String Cpf { get; set; }

        #region Informações de pessoa física.

        // Este campo deve ser exibido quando a pessoa for do tipo Física.
        [Display(Description = "Sexo", Name = "Sexo",Order = 4)]
        [DisplayFormat(NullDisplayText = Constants.NullTextGeneroMasculino)]
        [GridAnnotation(Order = 3, Visible = true, Width = 100)]
        public virtual Sexo Sexo { get; set; }

        #endregion
        
        #region Usuario
        
        [Display(Description = "Nome de usuário utilizado para entrar no sistema.", Name = "Usuário",Order = 5)]
        [DisplayFormat(NullDisplayText = Constants.NullTextGeneroMasculino)]
        [StringLength(Constants.MaxLengthNames, MinimumLength = Constants.MinLengthNames,
            ErrorMessage = Constants.MessageLengthNameError)]
        public virtual string Login { get; set; }

        [Display(Description = "Senha utilizada pelo usuário para acessar o sistema.", Name = "Senha",Order = 6)]
        [StringLength(Constants.MaxLengthPassword,MinimumLength = Constants.MinLengthPassword,ErrorMessage = Constants.MessageLengthPasswordError)]
        public virtual string Senha { get; set; }

        [Display(Description = "Nova senha",Name = "NovaSenha",Order = 7)]
        [StringLength(Constants.MaxLengthPassword, MinimumLength = Constants.MinLengthPassword, ErrorMessage = Constants.MessageLengthPasswordError)]
        public virtual string NovaSenha { get; set; }
        [Display(Description = "Confirmação de senha para inclusão e alteração de senha",Name = "Confirmar",Order = 8)]
        [StringLength(Constants.MaxLengthPassword, MinimumLength = Constants.MinLengthPassword, ErrorMessage = Constants.MessageLengthPasswordError)]
        public virtual string ConfirmarSenha { get; set; }
        public virtual DateTime UltimaVisita { get; set; }
        public virtual DateTime VisitaAtual { get; set; }
       
        [Required(ErrorMessage = Constants.MessageRequiredError)]
        public virtual GridViewEditingMode ModoEdicaoGridView { get; set; }
        
        [Required(ErrorMessage = Constants.MessageRequiredError)]
        public virtual Theme TemaPadrao { get; set; }

        /// <summary>
        /// O idioma padrão da aplicação
        /// </summary>
        [Required(ErrorMessage = Constants.MessageRequiredError)]
        public virtual Idioma IdiomaPadrao { get; set; }
        
        /// <summary>
        /// Palavra usada para recuperar a senha.
        /// </summary>
        [Display(Description = "Palavra chave", Name = "PalavraChave",Order = 7)]
        [DisplayFormat(NullDisplayText = Constants.NullTextGeneroFeminino)]
        public virtual string PalavraChave { get; set; }
        #endregion Usuario
    }
}
