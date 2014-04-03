using System;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Runtime.CompilerServices;
using Erp.Business.Annotations;
using Erp.Business.Enum;

namespace Erp.Business.Entity.Vendas.Pedido.ClassesRelacionadas
{
    [Serializable]
    public class PagamentoPedido : INotifyPropertyChanged
    {
        private decimal _valorTotal;
        private decimal _desconto;
        private decimal _juros;
        private decimal _valor;
        private FormaPagamento _formaPagamento;
        private DateTime _vencimento;
        private int _parcela;
        private Pedido _pedido;
        public virtual int Id { get; set; }

        [Display(Name = "Pedido", Description = "Pedido que originou o pagamento.")]
        [Required(ErrorMessage = Constants.MessageRequiredError)]
        public virtual Pedido Pedido
        {
            get { return _pedido; }
            set
            {
                _pedido = value;
                OnPropertyChanged();
            }
        }

        [Display(Name = "Parcela", Description = "Informação da parcela do pagamento do pedido.")]
        [Range(Constants.MinParcelas, Constants.MaxParcelas, ErrorMessage = Constants.MessageRangeError)]
        [Required(ErrorMessage = Constants.MessageRequiredError)]
        public virtual int Parcela
        {
            get { return _parcela; }
            set
            {
                _parcela = value;
                OnPropertyChanged();
            }
        }

        [Display(Name = "Vencimento", Description = "Data em que vence o título desta parcela")]
        [Required(ErrorMessage = Constants.MessageRequiredError)]
        public virtual DateTime Vencimento
        {
            get { return _vencimento; }
            set
            {
                _vencimento = value;
                OnPropertyChanged();
            }
        }

        [Display(Name = "Forma de pagamento", Description = "Forma de pagamento usada para quitar a parcela")]
        [Required(ErrorMessage = Constants.MessageRequiredError)]
        public virtual FormaPagamento FormaPagamento
        {
            get { return _formaPagamento; }
            set
            {
                _formaPagamento = value;
                OnPropertyChanged();
            }
        }

        [Display(Name = "Valor", Description = "Valor da parcela")]
        [Range(Constants.MinValorMonetario, Constants.MaxValorMonetario,
            ErrorMessage = Constants.MessageRangeValorError)]
        [Required(ErrorMessage = Constants.MessageRequiredError)]
        public virtual Decimal Valor
        {
            get { return _valor; }
            set
            {
                _valor = value;
                OnPropertyChanged();
                OnPropertyChanged("ValorTotal");
            }
        }

        [Display(Name = "Juros", Description = "Juros cobrados na parcela")]
        [Range(Constants.MinValorMonetario, Constants.MaxValorMonetario,
            ErrorMessage = Constants.MessageRangeValorError)]
        [Required(ErrorMessage = Constants.MessageRequiredError)]
        public virtual decimal Juros
        {
            get { return _juros; }
            set
            {
                _juros = value;
                OnPropertyChanged();
                OnPropertyChanged("ValorTotal");
            }
        }

        [Display(Name = "Desconto", Description = "Desconto concedido na parcela")]
        [Range(Constants.MinValorMonetario, Constants.MaxValorMonetario,
            ErrorMessage = Constants.MessageRangeValorError)]
        [Required(ErrorMessage = Constants.MessageRequiredError)]
        public virtual decimal Desconto
        {
            get { return _desconto; }
            set
            {
                _desconto = value; 
                OnPropertyChanged();
            }
        }

        [Display(Name = "Total", Description = "Valor total da parcela")]
        [Range(Constants.MinValorMonetario, Constants.MaxValorMonetario,
            ErrorMessage = Constants.MessageRangeValorError)]
        [Required(ErrorMessage = Constants.MessageRequiredError)]
        public virtual decimal ValorTotal
        {
            get
            {
                _valorTotal = Valor + Juros + Desconto;
                return _valorTotal;
            }
            set
            {
                _valorTotal = value;
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