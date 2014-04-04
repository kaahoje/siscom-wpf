using System;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Runtime.CompilerServices;
using Erp.Business.Annotations;
using Erp.Business.Entity.Fiscal;
using Erp.Business.Enum;

namespace Erp.Business.Entity.Contabil
{
    public class Titulo : INotifyPropertyChanged
    {
        public Titulo()
        {
            DataLancamento = DateTime.Now.Date;
            Baixado = false;
        }
        private DateTime _dataLancamento;
        private DateTime _dataVencimento;
        private DateTime _baixa;
        private string _numeroOrdem;
        private decimal _valor;
        private decimal _acrescimos;
        private DateTime _descontoAte;
        private decimal _descontoPercentual;
        private decimal _desconto;
        private bool _aReceber;
        private string _historico;
        private bool _baixado;
        private NotaFiscal _notaFiscal;
        private TipoTitulo _tipoTitulo;
        private Lancamento _lancamento;
        public virtual int Id { get; set; }

        [Display(Name = "Lançamento", Description = "Data de lançamento do título")]
        [Required(ErrorMessage = Constants.MessageRequiredError)]
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


        [Display(Name = "Vencimento", Description = "Data de vencimento do título")]
        [Required(ErrorMessage = Constants.MessageRequiredError)]
        public virtual DateTime DataVencimento
        {
            get { return _dataVencimento; }
            set
            {
                if (value.Equals(_dataVencimento)) return;
                _dataVencimento = value;
                OnPropertyChanged();
            }
        }

        [Display(Name = "Baixa", Description = "Data da baixa do título")]
        [Required(ErrorMessage = Constants.MessageRequiredError)]
        public virtual DateTime Baixa
        {
            get { return _baixa; }
            set
            {
                if (value.Equals(_baixa)) return;
                _baixa = value;
                OnPropertyChanged();
            }
        }

        [Display(Name = "Número de ordem", Description = "Código alfa-numérico que identifica o título")]
        [Required(ErrorMessage = Constants.MessageRequiredError)]
        public virtual String NumeroOrdem
        {
            get { return _numeroOrdem; }
            set
            {
                if (value == _numeroOrdem) return;
                _numeroOrdem = value;
                OnPropertyChanged();
            }
        }

        [Display(Name = "Valor", Description = "Valor do título")]
        [Required(ErrorMessage = Constants.MessageRequiredError)]
        public virtual Decimal Valor
        {
            get { return _valor; }
            set
            {
                if (value == _valor) return;
                _valor = value;
                OnPropertyChanged();
                OnPropertyChanged("ValorTotal");
            }
        }


        [Display(Name = "Acréscimos", Description = "Acréscimos do título")]
        [Required(ErrorMessage = Constants.MessageRequiredError)]
        public virtual Decimal Acrescimos
        {
            get { return _acrescimos; }
            set
            {
                if (value == _acrescimos) return;
                _acrescimos = value;
                OnPropertyChanged();
                OnPropertyChanged("ValorTotal");
            }
        }

        [Display(Name = "Desconto até", Description = "Data limite para concessão de um desconto")]
        [Required(ErrorMessage = Constants.MessageRequiredError)]
        public virtual DateTime DescontoAte
        {
            get { return _descontoAte; }
            set
            {
                if (value.Equals(_descontoAte)) return;
                _descontoAte = value;
                OnPropertyChanged();
            }
        }

        [Display(Name = "Desconto percentual", Description = "Desconto percentual")]
        [Required(ErrorMessage = Constants.MessageRequiredError)]
        public virtual Decimal DescontoPercentual
        {
            get { return _descontoPercentual; }
            set
            {
                if (value == _descontoPercentual) return;
                _descontoPercentual = value;
                OnPropertyChanged();
            }
        }

        [Display(Name = "Desconto", Description = "Desconto monetário")]
        [Required(ErrorMessage = Constants.MessageRequiredError)]
        public virtual Decimal Desconto
        {
            get { return _desconto; }
            set
            {
                if (value == _desconto) return;
                _desconto = value;
                OnPropertyChanged();
                OnPropertyChanged("ValorTotal");
            }
        }

        [Display(Name = "A receber", Description = "Define se é um título a pagar ou a receber")]
        [Required(ErrorMessage = Constants.MessageRequiredError)]
        public virtual bool AReceber
        {
            get { return _aReceber; }
            set
            {
                if (value.Equals(_aReceber)) return;
                _aReceber = value;
                OnPropertyChanged();
            }
        }

        [Display(Name = "Histórico", Description = "Histórico para facilitar a identificação do título.")]
        [Required(ErrorMessage = Constants.MessageRequiredError)]
        public virtual string Historico
        {
            get { return _historico; }
            set
            {
                if (value == _historico) return;
                _historico = value;
                OnPropertyChanged();
            }
        }

        [Display(Name = "Baixado", Description = "Indica se o título foi baixado")]
        [Required(ErrorMessage = Constants.MessageRequiredError)]
        public virtual bool Baixado
        {
            get { return _baixado; }
            set
            {
                if (value.Equals(_baixado)) return;
                _baixado = value;
                OnPropertyChanged();
            }
        }

        [Display(Name = "Valor total", Description = "Valor total do título")]
        [Required(ErrorMessage = Constants.MessageRequiredError)]
        public virtual decimal ValorTotal
        {
            get { return Valor - Desconto + Acrescimos ; }
            set { value = ValorTotal; }
        }

        [Display(Name = "Nota fiscal", Description = "Nota fiscal que originou o título")]
        [Required(ErrorMessage = Constants.MessageRequiredError)]
        public virtual NotaFiscal NotaFiscal
        {
            get { return _notaFiscal; }
            set
            {
                if (Equals(value, _notaFiscal)) return;
                _notaFiscal = value;
                OnPropertyChanged();
            }
        }

        [Display(Name = "Tipo", Description = "Tipo do título")]
        [Required(ErrorMessage = Constants.MessageRequiredError)]
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

        [Display(Name = "Lançamento", Description = "Lançamento gerado pelo título")]
        [Required(ErrorMessage = Constants.MessageRequiredError)]
        public virtual Lancamento Lancamento
        {
            get { return _lancamento; }
            set
            {
                if (Equals(value, _lancamento)) return;
                _lancamento = value;
                OnPropertyChanged();
            }
        }

        public virtual Status Status { get; set; }

        public virtual event PropertyChangedEventHandler PropertyChanged;

        [NotifyPropertyChangedInvocator]
        protected virtual void OnPropertyChanged([CallerMemberName] string propertyName = null)
        {
            var handler = PropertyChanged;
            if (handler != null) handler(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}