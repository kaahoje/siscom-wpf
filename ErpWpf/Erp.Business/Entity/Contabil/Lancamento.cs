using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Runtime.CompilerServices;
using Erp.Business.Annotations;
using Erp.Business.Common.CustomAttributes;
using Erp.Business.Enum;

namespace Erp.Business.Entity.Contabil
{
    public class Lancamento : INotifyPropertyChanged
    {
        private Pessoa.Pessoa _pessoa;
        private TipoTitulo _tipoTitulo;
        private string _historico;
        private string _documento;
        private decimal _desconto;
        private decimal _acrescimos;
        private decimal _valor;
        private DateTime _dataLancamento;
        private DateTime _vencimento;
        private Titulo _titulo;

        public Lancamento()
        {
            Partidas = new List<PartidasLancamento>();
        }

        public virtual int Id { get; set; }

        [Required(ErrorMessage = Constants.MessageRequiredError)]
        [Display(Description = "Lançamento", Name = "Data de lançamento", Order = 1)]
        [GridAnnotation(Order = 1, Visible = true, Width = 150)]
        [Mask(Constants.MaskDate)]
        public virtual DateTime DataLancamento
        {
            get { return _dataLancamento; }
            set
            {
                if (value.Equals(_dataLancamento)) return;
                _dataLancamento = value;
                OnPropertyChanged();
            }
        }

        [Required(ErrorMessage = Constants.MessageRequiredError)]
        [Display(Description = "Valor", Name = "Valor do lançamento", Order = 2)]
        [GridAnnotation(Order = 2, Visible = true, Width = 150)]
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

        [Display(Description = "Juros", Name = "Juros", Order = 3)]
        [GridAnnotation(Order = 3, Visible = true, Width = 150)]
        public virtual Decimal Acrescimos
        {
            get { return _acrescimos; }
            set
            {
                if (value == _acrescimos) return;
                _acrescimos = value;
                OnPropertyChanged();
            }
        }

        [Display(Description = "Descontos", Name = "Descontos", Order = 4)]
        [GridAnnotation(Order = 4, Visible = true, Width = 150)]
        public virtual Decimal Desconto
        {
            get { return _desconto; }
            set
            {
                if (value == _desconto) return;
                _desconto = value;
                OnPropertyChanged();
            }
        }

        [Display(Name = "Título",Description = "Título que originou o lançamento")]
        [Required(ErrorMessage = Constants.MessageRequiredError)]
        public virtual Titulo Titulo
        {
            get { return _titulo; }
            set
            {
                if (Equals(value, _titulo)) return;
                _titulo = value;
                OnPropertyChanged();
            }
        }

        [Display(Description = "Documento", Name = "Texto gerado para identificar o lançamento para outros setores",
            Order = 5)]
        [GridAnnotation(Order = 5, Visible = true, Width = 150)]
        public virtual string Documento
        {
            get { return _documento; }
            set
            {
                if (value == _documento) return;
                _documento = value;
                OnPropertyChanged();
            }
        }

        [Display(Description = "Histórico", Name = "Histórico do lançamento", Order = 6)]
        [GridAnnotation(Order = 6, Visible = true, Width = 150)]
        public virtual String Historico
        {
            get { return _historico; }
            set
            {
                if (value == _historico) return;
                _historico = value;
                OnPropertyChanged();
            }
        }

        public virtual Status Status { get; set; }

        public virtual IList<PartidasLancamento> Partidas { get; set; }
        public virtual event PropertyChangedEventHandler PropertyChanged;

        [NotifyPropertyChangedInvocator]
        protected virtual void OnPropertyChanged([CallerMemberName] string propertyName = null)
        {
            PropertyChangedEventHandler handler = PropertyChanged;
            if (handler != null) handler(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}