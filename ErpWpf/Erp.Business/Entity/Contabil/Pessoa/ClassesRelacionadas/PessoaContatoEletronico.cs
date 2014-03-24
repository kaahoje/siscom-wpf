using System;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Runtime.CompilerServices;
using Erp.Business.Annotations;
using Erp.Business.Enum;

namespace Erp.Business.Entity.Contabil.Pessoa.ClassesRelacionadas
{
    /// <summary>
    /// Classe que define um endereço eletrônico.
    /// </summary>
     [Serializable]
    public class PessoaContatoEletronico : INotifyPropertyChanged
    {
        private Pessoa _pessoa;
        private Guid _idGuid;
        private Status _status;
        private TipoEmail _tipo;
        private string _nick;

        public PessoaContatoEletronico()
        {
            IdGuid = Guid.NewGuid();
        }
        /// <summary>
        /// Identificador.
        /// </summary>
        public virtual int Id { get; set; }

        public virtual Guid IdGuid
        {
            get { return _idGuid; }
            set
            {
                if (value.Equals(_idGuid)) return;
                _idGuid = value;
                OnPropertyChanged();
            }
        }

        /// <summary>
        /// Status do registro.
        /// </summary>
        public virtual Status Status
        {
            get { return _status; }
            set
            {
                if (value == _status) return;
                _status = value;
                OnPropertyChanged();
            }
        }

        /// <summary>
        /// Tipo de Contato Eletrônico
        /// </summary>
        /// [Display(Name = "Data", Description = "Data do pedido")]
        [Required(ErrorMessage = Constants.MessageRequiredError)]
        [GridAnnotation(Order = 0, Visible = true, Width = 100)]
        [Display(Name = "Tipo", Description = "Tipo de e-mail")]
        public virtual TipoEmail Tipo
        {
            get { return _tipo; }
            set
            {
                if (value == _tipo) return;
                _tipo = value;
                OnPropertyChanged();
            }
        }

        /// <summary>
        /// Nick name utilizado no serviço de e-mail.
        /// </summary>
        /// [Display(Name = "Data", Description = "Data do pedido")]
        [Required(ErrorMessage = Constants.MessageRequiredError)]
        [GridAnnotation(Order = 1, Visible = true, Width = 300)]
        [Display(Name = "E-Mail", Description = "E-mail")]
        public virtual string Nick
        {
            get { return _nick; }
            set
            {
                if (value == _nick) return;
                _nick = value;
                OnPropertyChanged();
            }
        }

        /// <summary>
        /// Pessoa que é dona do contato eletrônico.
        /// </summary>
        public virtual Pessoa Pessoa
        {
            get { return _pessoa; }
            set
            {
                if (Equals(value, _pessoa)) return;
                _pessoa = value;
                OnPropertyChanged();
            }
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