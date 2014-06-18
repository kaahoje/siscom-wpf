using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Runtime.CompilerServices;
using Erp.Business.Annotations;
using Erp.Business.Entity.Contabil.Pessoa;
using Erp.Business.Entity.Contabil.Pessoa.SubClass.PessoaFisica;
using Erp.Business.Entity.Contabil.Pessoa.SubClass.PessoaJuridica;
using Erp.Business.Entity.Fiscal;
using Erp.Business.Entity.Vendas.Pedido.ClassesRelacionadas;
using Erp.Business.Enum;
using Remotion.Linq.Collections;

namespace Erp.Business.Entity.Vendas.Pedido
{
    [Serializable]
    public class Pedido : INotifyPropertyChanged
    {
        private int _id;
        private int _coo;
        private DateTime _dataPedido;
        private decimal _acressimos;
        private decimal _frete;
        private decimal _descontos;
        private decimal _valorPedido;
        private int _caixa;
        private Pessoa _cliente;
        private PessoaJuridica _empresa;
        private PessoaFisica _usuario;
        private NotaFiscal _notaFiscal;
        private CondicaoPagamento _condicaoPagamento;
        private IList<PagamentoPedido> _pagamento;
        private string _observacoes;

        public Pedido()
        {
            Pagamento = new ObservableCollection<PagamentoPedido>();
            DataPedido = DateTime.Now.Date;
            Id = 0;
        }

        [Display(Name = "Número", Description = "Número do pedido")]
        [GridAnnotation(Order = 0, Visible = true, Width = 150)]
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

        public virtual int Coo
        {
            get { return _coo; }
            set
            {
                if (value == _coo) return;
                _coo = value;
                OnPropertyChanged();
            }
        }

        [Display(Name = "Data", Description = "Data do pedido")]
        [DisplayFormat(DataFormatString = Constants.MaskDate)]
        [Required(ErrorMessage = Constants.MessageRequiredError)]
        [GridAnnotation(Order = 1, Visible = true, Width = 100)]
        public virtual DateTime DataPedido
        {
            get { return _dataPedido; }
            set
            {
                if (value.Equals(_dataPedido)) return;
                _dataPedido = value;
                OnPropertyChanged();
            }
        }

        public virtual decimal Acressimos
        {
            get { return _acressimos; }
            set
            {
                if (value == _acressimos) return;
                _acressimos = value;
                OnPropertyChanged();
            }
        }

        public virtual decimal Frete
        {
            get { return _frete; }
            set
            {
                if (value == _frete) return;
                _frete = value;
                OnPropertyChanged();
            }
        }

        public virtual decimal Descontos
        {
            get { return _descontos; }
            set
            {
                if (value == _descontos) return;
                _descontos = value;
                OnPropertyChanged();
            }
        }

        public virtual decimal ValorPedido
        {
            get { return _valorPedido; }
            set
            {
                if (value == _valorPedido) return;
                _valorPedido = value;
                OnPropertyChanged();
            }
        }

        public virtual int Caixa
        {
            get { return _caixa; }
            set
            {
                if (value == _caixa) return;
                _caixa = value;
                OnPropertyChanged();
            }
        }

        /// <summary>
        ///     Pessoa que está comprando da empresa.
        ///     Caso seja necessário a utilização de limites ou informações especificas de clientes o mesmo deve
        ///     ser cadastrado pelo formulário de cliente.
        /// </summary>
        public virtual Pessoa Cliente
        {
            get { return _cliente; }
            set
            {
                if (Equals(value, _cliente)) return;
                _cliente = value;
                OnPropertyChanged();
            }
        }

        public virtual PessoaJuridica Empresa
        {
            get { return _empresa; }
            set
            {
                if (Equals(value, _empresa)) return;
                _empresa = value;
                OnPropertyChanged();
            }
        }

        public virtual PessoaFisica Usuario
        {
            get { return _usuario; }
            set
            {
                if (Equals(value, _usuario)) return;
                _usuario = value;
                OnPropertyChanged();
            }
        }

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

        public virtual CondicaoPagamento CondicaoPagamento
        {
            get { return _condicaoPagamento; }
            set
            {
                if (Equals(value, _condicaoPagamento)) return;
                _condicaoPagamento = value;
                OnPropertyChanged();
            }
        }

        public virtual IList<PagamentoPedido> Pagamento
        {
            get { return _pagamento; }
            set
            {
                if (Equals(value, _pagamento)) return;
                _pagamento = value;
                OnPropertyChanged();
            }
        }

        [Display(Name = "Observações", Description = "Observações do pedido")]
        [GridAnnotation(Order = 2, Visible = true, Width = 300)]
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