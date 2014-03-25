using System;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Runtime.CompilerServices;
using Erp.Business.Annotations;
using Erp.Business.Enum;

namespace Erp.Business.Entity.Contabil
{
    public class CustoFixo: INotifyPropertyChanged
    {
        public CustoFixo()
        {
            
        }
        private string _observacoes;
        private decimal _valor;
        private TipoTitulo _tipoTitulo;
        private Pessoa.Pessoa _pessoa;
        private int _diaVencimento;
        private int _id;

        public virtual int Id
        {
            get { return _id; }
            set
            {
                if (value == _id) return;
                _id = value;
                OnPropertyChanged();
            }
        }

        [Required(ErrorMessage = Constants.MessageRequiredError)]
        [Display(Description = "Vencimento", Name = "Dia de vencimento", Order = 0)]
        [GridAnnotation(Order = 0, Visible = true, Width = 150)]
        public virtual int DiaVencimento
        {
            get { return _diaVencimento; }
            set
            {
                if (value == _diaVencimento) return;
                _diaVencimento = value;
                OnPropertyChanged();
            }
        }

        [Required(ErrorMessage = Constants.MessageRequiredError)]
        [Display(Description = "Tipo de lançamento", Name = "Tipo de lançamento", Order = 1)]
        [GridAnnotation(Order = 1, Visible = true, Width = 250)]
        public virtual TipoTitulo TipoTitulo
        {
            get { return _tipoTitulo; }
            set
            {
                if (Equals(value, _tipoTitulo)) return;
                _tipoTitulo = value;
                OnPropertyChanged();
            }
        }

        [Required(ErrorMessage = Constants.MessageRequiredError)]
        [Display(Description = "Valor", Name = "Valor", Order = 3)]
        [GridAnnotation(Order = 3, Visible = true, Width = 150)]
        public virtual decimal Valor
        {
            get { return _valor; }
            set
            {
                if (value == _valor) return;
                _valor = value;
                OnPropertyChanged();
            }
        }

        [Required(ErrorMessage = Constants.MessageRequiredError)]
        [Display(Description = "Observações", Name = "Observações do custo", Order = 4)]
        [GridAnnotation(Order = 4, Visible = true, Width = 200)]
        public virtual string Observacoes
        {
            get { return _observacoes; }
            set
            {
                if (value == _observacoes) return;
                _observacoes = value;
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
