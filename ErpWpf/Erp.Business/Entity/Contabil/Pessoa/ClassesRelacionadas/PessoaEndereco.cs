using System;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Runtime.CompilerServices;
using Erp.Business.Annotations;
using Erp.Business.Enum;

namespace Erp.Business.Entity.Contabil.Pessoa.ClassesRelacionadas
{
    /// <summary>
    /// Classe que define uma relação entre endereço e funcionário.
    /// </summary>
    [Serializable]
    public class PessoaEndereco : INotifyPropertyChanged
    {
        private Pessoa _pessoa;
        private Endereco.Endereco _endereco;
        private string _logradouro;
        private string _numero;
        private string _complemento;
        private bool _informadoManualmente;
        private TipoEndereco _tipoEndereco;
        private string _pontoReferencia;

        /// <summary>
        /// Identificador.
        /// </summary>
        public virtual int Id { get; set; }
        
        [GridAnnotation(Order = 0, Visible = true, Width = 0)]
        public virtual Guid IdGuid { get; set; }

        /// <summary>
        /// Referência ao funcionário.
        /// </summary>
        public virtual Pessoa Pessoa
        {
            get { return _pessoa; }
            set
            {
                _pessoa = value; 
                OnPropertyChanged();
            }
        }

        /// <summary>
        /// Referência ao endereço.
        /// </summary>
        public virtual Endereco.Endereco Endereco
        {
            get { return _endereco; }
            set
            {
                _endereco = value;
                OnPropertyChanged();
            }
        }

        /// <summary>
        /// Guarda o endereço que foi informado manualmente pelo usuário.
        /// </summary>
        [StringLength(Constants.MaxLengthNames, MinimumLength = Constants.MinLengthNames,
            ErrorMessage = Constants.MessageLengthNameError)]
        [Required(ErrorMessage = Constants.MessageRequiredError)]
        [GridAnnotation(Order = 0, Visible = true, Width = 100)]
        [Display(Name = "Logradouro", Description = "Logradouro")]
        public virtual string Logradouro
        {
            get { return _logradouro; }
            set
            {
                _logradouro = value; 
                OnPropertyChanged();
            }
        }

        [Required(ErrorMessage = Constants.MessageRequiredError)]
        [GridAnnotation(Order = 1, Visible = true, Width = 100)]
        [Display(Name = "Número", Description = "Número do logradouro")]
        public virtual string Numero
        {
            get { return _numero; }
            set
            {
                _numero = value;
                OnPropertyChanged();
            }
        }

        [GridAnnotation(Order = 2, Visible = true, Width = 100)]
        [Display(Name = "Complemento", Description = "Complemento do endereço")]
        public virtual string Complemento
        {
            get { return _complemento; }
            set
            {
                _complemento = value; 
                OnPropertyChanged();
            }
        }

        /// <summary>
        /// Guarda a informação que diz se o endereço foi informado manualmente.
        /// </summary>
        public virtual bool InformadoManualmente
        {
            get { return _informadoManualmente; }
            set
            {
                _informadoManualmente = value;
                OnPropertyChanged();
            }
        }

        [Required(ErrorMessage = Constants.MessageRequiredError)]
        [GridAnnotation(Order = 3, Visible = true, Width = 100)]
        [Display(Name = "Tipo", Description = "Tipo de endereço")]
        public virtual TipoEndereco TipoEndereco
        {
            get { return _tipoEndereco; }
            set { _tipoEndereco = value; 
                OnPropertyChanged();
            }
        }

        [GridAnnotation(Order = 4, Visible = true, Width = 100)]
        [Display(Name = "Ponto de referência", Description = "Descrição detalhada do endereço.")]
        public virtual String PontoReferencia
        {
            get { return _pontoReferencia; }
            set
            {
                _pontoReferencia = value; 
                OnPropertyChanged();
            }
        }

        public virtual Status Status { get; set; }

        public PessoaEndereco()
        {
            IdGuid = Guid.NewGuid();
            
        }

        public virtual event PropertyChangedEventHandler PropertyChanged;

        [NotifyPropertyChangedInvocator]
        protected virtual void OnPropertyChanged([CallerMemberName] string propertyName = null)
        {
            PropertyChangedEventHandler handler = PropertyChanged;
            if (handler != null) handler(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}
