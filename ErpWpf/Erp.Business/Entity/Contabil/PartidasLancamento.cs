using System;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Runtime.CompilerServices;
using Erp.Business.Annotations;
using Erp.Business.Entity.Sped;
using Erp.Business.Enum;

namespace Erp.Business.Entity.Contabil
{
    public class PartidasLancamento : INotifyPropertyChanged
    {
        private PlanoContaReferencial _planoConta;
        private decimal _valor;
        public virtual int Id { get; set; }

        [Required(ErrorMessage = Constants.MessageRequiredError)]
        [Display(Description = "Pessoa", Name = "Pessoa com que se relacionou a empresa originando o relacionamento",
            Order = 8)]
        [Range(Constants.MinValorMonetario, Constants.MaxValorMonetario, ErrorMessage = Constants.MessageRangeValorError
            )]
        [GridAnnotation(Order = 8, Visible = true, Width = 200, FieldName = "Id")]
        public virtual Decimal Valor
        {
            get { return _valor; }
            set
            {
                if (value == _valor) return;
                _valor = value;
                OnPropertyChanged();
            }
        }

        public virtual PlanoContaReferencial PlanoConta
        {
            get { return _planoConta; }
            set
            {
                if (Equals(value, _planoConta)) return;
                _planoConta = value;
                OnPropertyChanged();
            }
        }

        public virtual Status Status { get; set; }
        public virtual event PropertyChangedEventHandler PropertyChanged;

        [NotifyPropertyChangedInvocator]
        protected virtual void OnPropertyChanged([CallerMemberName] string propertyName = null)
        {
            PropertyChangedEventHandler handler = PropertyChanged;
            if (handler != null) handler(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}