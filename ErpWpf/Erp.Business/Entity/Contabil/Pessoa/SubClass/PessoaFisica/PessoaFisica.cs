using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Runtime.CompilerServices;
using DevExpress.Web.ASPxGridView;
using Erp.Business.Annotations;
using Erp.Business.Common.CustomAttributes;
using Erp.Business.Entity.Contabil.Pessoa.SubClass.PessoaFisica.ClassesRelacionadas;
using Erp.Business.Enum;
using Erp.Business.Validation.CustomValidations;


namespace Erp.Business.Entity.Contabil.Pessoa.SubClass.PessoaFisica
{
    [Serializable]
    [PessoaFisicaValidation]
    public class PessoaFisica : Pessoa, INotifyPropertyChanged
    {
        public PessoaFisica()
        {
            PermissaoFormulario = new List<PermissaoFormularioPessoaFisica>();
            PermissaoRelatorio = new List<PermissaoRelatorioPessoaFisica>();
        }
        private string _nome;
        private string _alias;
        private string _cpf;
        private Sexo _sexo;
        private string _login;
        private string _senha;
        private string _novaSenha;
        private string _confirmarSenha;
        private DateTime _ultimaVisita;
        private DateTime _visitaAtual;
        private GridViewEditingMode _modoEdicaoGridView;
        private Theme _temaPadrao;
        private Idioma _idiomaPadrao;
        private IList<PermissaoFormularioPessoaFisica> _permissaoFormulario;
        private IList<PermissaoRelatorioPessoaFisica> _permissaoRelatorio;
        private string _palavraChave;

        [Display(Description = "Nome da pessoa.", Name = "Nome", Order = 1)]
        [DisplayFormat(NullDisplayText = Constants.NullTextGeneroMasculino)]
        [Required(ErrorMessage = Constants.MessageRequiredError)]
        [StringLength(Constants.MaxLengthNames, MinimumLength = Constants.MinLengthNames,
            ErrorMessage = Constants.MessageLengthNameError)]
        [GridAnnotation(Order = 0, Visible = true, Width = 250)]
        public virtual String Nome
        {
            get { return _nome; }
            set
            {
                if (value == _nome) return;
                _nome = value;
                OnPropertyChanged();
            }
        }

        [Display(Description = "Apelido da pessoa.", Name = "Apelido", Order = 2)]
        [DisplayFormat(NullDisplayText = Constants.NullTextGeneroMasculino)]
        [GridAnnotation(Order = 1, Visible = false, Width = 200)]
        public virtual String Alias
        {
            get { return _alias; }
            set
            {
                if (value == _alias) return;
                _alias = value;
                OnPropertyChanged();
            }
        }

        [Required(ErrorMessage = Constants.MessageRequiredError)]
        [Display(Description = "CPF da pessoa", Name = "CPF", Order = 3)]
        [DisplayFormat(DataFormatString = Constants.MaskCpf, NullDisplayText = Constants.NullTextGeneroMasculino)]
        //[CustomValidation(typeof (CpfCnpjValidation), "IsCpfCnpjValid", ErrorMessage = "CPF inválido")]
        [CpfCnpjValidation]
        [Mask(Constants.MaskCpf)]
        [GridAnnotation(Order = 2, Visible = true, Width = 150)]
        public virtual String Cpf
        {
            get { return _cpf; }
            set
            {
                if (value == _cpf) return;
                _cpf = value;
                OnPropertyChanged();
            }
        }

        #region Informações de pessoa física.

        // Este campo deve ser exibido quando a pessoa for do tipo Física.
        [Display(Description = "Sexo", Name = "Sexo", Order = 4)]
        [DisplayFormat(NullDisplayText = Constants.NullTextGeneroMasculino)]
        [GridAnnotation(Order = 3, Visible = true, Width = 100)]
        public virtual Sexo Sexo
        {
            get { return _sexo; }
            set
            {
                if (value == _sexo) return;
                _sexo = value;
                OnPropertyChanged();
            }
        }

        #endregion
        
        #region Usuario

        [Display(Description = "Nome de usuário utilizado para entrar no sistema.", Name = "Usuário", Order = 5)]
        [DisplayFormat(NullDisplayText = Constants.NullTextGeneroMasculino)]
        [StringLength(Constants.MaxLengthNames, MinimumLength = Constants.MinLengthNames,
            ErrorMessage = Constants.MessageLengthNameError)]
        public virtual string Login
        {
            get { return _login; }
            set
            {
                if (value == _login) return;
                _login = value;
                OnPropertyChanged();
            }
        }

        [Display(Description = "Senha utilizada pelo usuário para acessar o sistema.", Name = "Senha", Order = 6)]
        [StringLength(Constants.MaxLengthPassword, MinimumLength = Constants.MinLengthPassword,
            ErrorMessage = Constants.MessageLengthPasswordError)]
        public virtual string Senha
        {
            get { return _senha; }
            set
            {
                if (value == _senha) return;
                _senha = value;
                OnPropertyChanged();
            }
        }

        [Display(Description = "Nova senha", Name = "NovaSenha", Order = 7)]
        [StringLength(Constants.MaxLengthPassword, MinimumLength = Constants.MinLengthPassword,
            ErrorMessage = Constants.MessageLengthPasswordError)]
        public virtual string NovaSenha
        {
            get { return _novaSenha; }
            set
            {
                if (value == _novaSenha) return;
                _novaSenha = value;
                OnPropertyChanged();
            }
        }

        [Display(Description = "Confirmação de senha para inclusão e alteração de senha", Name = "Confirmar", Order = 8)
        ]
        [StringLength(Constants.MaxLengthPassword, MinimumLength = Constants.MinLengthPassword,
            ErrorMessage = Constants.MessageLengthPasswordError)]
        public virtual string ConfirmarSenha
        {
            get { return _confirmarSenha; }
            set
            {
                if (value == _confirmarSenha) return;
                _confirmarSenha = value;
                OnPropertyChanged();
            }
        }

        public virtual DateTime UltimaVisita
        {
            get { return _ultimaVisita; }
            set
            {
                if (value.Equals(_ultimaVisita)) return;
                _ultimaVisita = value;
                OnPropertyChanged();
            }
        }

        public virtual DateTime VisitaAtual
        {
            get { return _visitaAtual; }
            set
            {
                if (value.Equals(_visitaAtual)) return;
                _visitaAtual = value;
                OnPropertyChanged();
            }
        }

        [Required(ErrorMessage = Constants.MessageRequiredError)]
        public virtual GridViewEditingMode ModoEdicaoGridView
        {
            get { return _modoEdicaoGridView; }
            set
            {
                if (value == _modoEdicaoGridView) return;
                _modoEdicaoGridView = value;
                OnPropertyChanged();
            }
        }

        [Required(ErrorMessage = Constants.MessageRequiredError)]
        public virtual Theme TemaPadrao
        {
            get { return _temaPadrao; }
            set
            {
                if (value == _temaPadrao) return;
                _temaPadrao = value;
                OnPropertyChanged();
            }
        }

        /// <summary>
        /// O idioma padrão da aplicação
        /// </summary>
        [Required(ErrorMessage = Constants.MessageRequiredError)]
        public virtual Idioma IdiomaPadrao
        {
            get { return _idiomaPadrao; }
            set
            {
                if (value == _idiomaPadrao) return;
                _idiomaPadrao = value;
                OnPropertyChanged();
            }
        }

        public virtual IList<PermissaoFormularioPessoaFisica> PermissaoFormulario
        {
            get { return _permissaoFormulario; }
            set
            {
                if (Equals(value, _permissaoFormulario)) return;
                _permissaoFormulario = value;
                OnPropertyChanged();
            }
        }

        public virtual IList<PermissaoRelatorioPessoaFisica> PermissaoRelatorio
        {
            get { return _permissaoRelatorio; }
            set
            {
                if (Equals(value, _permissaoRelatorio)) return;
                _permissaoRelatorio = value;
                OnPropertyChanged();
            }
        }

        /// <summary>
        /// Palavra usada para recuperar a senha.
        /// </summary>
        [Display(Description = "Palavra chave", Name = "PalavraChave", Order = 7)]
        [DisplayFormat(NullDisplayText = Constants.NullTextGeneroFeminino)]
        public virtual string PalavraChave
        {
            get { return _palavraChave; }
            set
            {
                if (value == _palavraChave) return;
                _palavraChave = value;
                OnPropertyChanged();
            }
        }

        #endregion Usuario

        public virtual event PropertyChangedEventHandler PropertyChanged;

        [NotifyPropertyChangedInvocator]
        protected virtual void OnPropertyChanged([CallerMemberName] string propertyName = null)
        {
            var handler = PropertyChanged;
            if (handler != null) handler(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}
