using System;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Runtime.CompilerServices;
using Erp.Business.Annotations;
using Erp.Business.Enum;


namespace Erp.Business.Entity.Contabil.Pessoa.ClassesRelacionadas
{
    /// <summary>
    /// Classe que define a estrutura de um registro de telefone.
    /// </summary>
    [Serializable]
    public class PessoaTelefone : INotifyPropertyChanged
    {
        private string _ddiPais;
        private string _dddTelefone;
        private string _numero;
        private string _ramal;
        private Pessoa _pessoa;
        private TelefoneTipo _telefoneTipo;
        private Status _status;
        private Guid _idGuid;

        public PessoaTelefone()
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
        /// DDI Pais
        /// </summary>
        [Required(ErrorMessage = Constants.MessageRequiredError)]
        [GridAnnotation(Order = 0, Visible = true, Width = 100)]
        [Display(Name = "DDI", Description = "DDI do telefone")]
        //[Range(2, 3, ErrorMessage = "O campo {0} deve ter {2} caracteres.")]
        public virtual string DdiPais
        {
            get { return _ddiPais; }
            set
            {
                _ddiPais = value; 
                OnPropertyChanged();
            }
        }

        /// <summary>
        /// DDI Pais
        /// </summary>
        [Required(ErrorMessage = Constants.MessageRequiredError)]
        [GridAnnotation(Order = 1, Visible = true, Width = 100)]
        [Display(Name = "DDD", Description = "DDD do telefone")]
        public virtual string DddTelefone
        {
            get { return _dddTelefone; }
            set
            {
                _dddTelefone = value; 
                OnPropertyChanged();
            }
        }

        /// <summary>
        /// Número do telefone.
        /// </summary>
        [Required(ErrorMessage = Constants.MessageRequiredError)]
        [GridAnnotation(Order = 2, Visible = true, Width = 150)]
        [Display(Name = "Número", Description = "Número do telefone")]
        public virtual string Numero
        {
            get { return _numero; }
            set
            {
                _numero = value;
                OnPropertyChanged();
            }
        }

        /// <summary>
        /// Ramal.
        /// </summary>
        [GridAnnotation(Order = 4, Visible = true, Width = 100)]
        [Display(Name = "Ramal", Description = "Ramal do telefone")]
        public virtual string Ramal
        {
            get { return _ramal; }
            set
            {
                if (value == _ramal) return;
                _ramal = value;
                OnPropertyChanged();
            }
        }

        /// <summary>
        /// Pessoa que possui o número de telefone.
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

        /// <summary>
        /// Tipo de telefone.
        /// </summary>
        [Required(ErrorMessage = Constants.MessageRequiredError)]
        [GridAnnotation(Order = 5, Visible = true, Width = 200)]
        [Display(Name = "Tipo", Description = "Tipo do telefone")]
        public virtual TelefoneTipo TelefoneTipo
        {
            get { return _telefoneTipo; }
            set
            {
                if (value == _telefoneTipo) return;
                _telefoneTipo = value;
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

        public virtual event PropertyChangedEventHandler PropertyChanged;

        [NotifyPropertyChangedInvocator]
        protected virtual void OnPropertyChanged([CallerMemberName] string propertyName = null)
        {
            PropertyChangedEventHandler handler = PropertyChanged;
            if (handler != null) handler(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}