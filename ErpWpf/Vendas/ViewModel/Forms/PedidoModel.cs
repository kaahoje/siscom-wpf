using System;
using System.Collections.ObjectModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Windows.Input;
using Erp.Business;
using Erp.Business.Entity.Vendas.Pedido;
using Erp.Business.Entity.Vendas.Pedido.ClassesRelacionadas;
using Util.Wpf;

namespace Vendas.ViewModel.Forms
{
    public delegate void PedidoFinalizadoEventHandler(object o, EventArgs e);
    public delegate void PedidoVoltarEventHandler(object o, EventArgs e);
    public abstract class PedidoModel : FormModelBase<Pedido>
    {
        public PedidoModel()
        {
            IdGuid = Guid.NewGuid();
            QuantidadeAtual = 1;
            try
            {
                FormasPagamento = new ObservableCollection<FormaPagamento>(FormaPagamentoRepository.GetList());
                CondicoesPagamento = new ObservableCollection<CondicaoPagamento>(CondicaoPagamentoRepository.GetList());
                IniciarPagamento();

            }
            catch (Exception ex)
            {

            }
        }

        protected void IniciarPagamento()
        {
            FormaPagamentoPadrao = FormasPagamento.SingleOrDefault(forma => forma.AVista);
            foreach (var condicao in CondicoesPagamento)
            {
                if (condicao.Prazos.Count == 1 && condicao.Prazos[0].Prazo == 0)
                {
                    CondicaoPagamento = condicao;
                }
            }
            
        }
        #region Properties
        private CondicaoPagamento _condicaoPagamento;
        private ICommand _pagamentoEfetuado;
        private ICommand _voltarAoPedido;
        private bool _isPagamentoEfetuado;
        private decimal _totalPedido;
        private decimal _acressimo;
        private decimal _frete;
        private decimal _totalProduto;
        private decimal _desconto;
        private ObservableCollection<PagamentoPedido> _pagamentoPedido;
        private ObservableCollection<FormaPagamento> _formasPagamento;
        private ObservableCollection<CondicaoPagamento> _condicoesPagamento;
        private decimal _quantidadeAtual;

        public Guid IdGuid { get; set; }

        public FormaPagamento FormaPagamentoPadrao { get; set; }
        
        public decimal QuantidadeAtual
        {
            get { return _quantidadeAtual; }
            set
            {
                _quantidadeAtual = value;
                OnPropertyChanged("QuantidadeAtual");
            }
        }

        public ObservableCollection<CondicaoPagamento> CondicoesPagamento
        {
            get { return _condicoesPagamento; }
            set
            {
                _condicoesPagamento = value;
                OnPropertyChanged("CondicoesPagamento");

            }
        }

        public ObservableCollection<FormaPagamento> FormasPagamento
        {
            get { return _formasPagamento; }
            set
            {
                _formasPagamento = value;
                OnPropertyChanged("FormasPagamento");
            }
        }

        public CondicaoPagamento CondicaoPagamento
        {
            get { return _condicaoPagamento; }
            set
            {
                _condicaoPagamento = value;
                Pagamento.Clear();
                var parcela = 1;

                foreach (var prazo in value.Prazos)
                {
                    Pagamento.Add(new PagamentoPedido()
                    {
                        Parcela = parcela,
                        FormaPagamento = FormaPagamentoPadrao,
                        Vencimento = DateTime.Now.AddDays(prazo.Prazo),
                        Valor = TotalPedido / value.Prazos.Count
                    });
                    parcela += 1;
                }
                Pagamento= Pagamento;
                OnPropertyChanged("CondicaoPagamento");
            }
        }

        public ObservableCollection<PagamentoPedido> Pagamento
        {
            get { return _pagamentoPedido ?? (_pagamentoPedido = new ObservableCollection<PagamentoPedido>()); }
            set
            {
                
                _pagamentoPedido = value;
                OnPropertyChanged("Pagamento");
            }
        }
        [DisplayFormat(DataFormatString = Constants.MaskMoney)]
        public decimal Desconto
        {
            get { return _desconto; }
            set
            {
                _desconto = value;
                OnPropertyChanged("Desconto");
            }
        }
        [DisplayFormat(DataFormatString = Constants.MaskMoney)]
        public decimal Acressimo
        {
            get { return _acressimo; }
            set
            {
                _acressimo = value;
                OnPropertyChanged("Acressimo");
            }
        }
        [DisplayFormat(DataFormatString = Constants.MaskMoney)]
        public decimal Frete
        {
            get { return _frete; }
            set
            {
                _frete = value;
                OnPropertyChanged("Frete");
            }
        }
        [DisplayFormat(DataFormatString = Constants.MaskMoney)]
        public decimal TotalProduto
        {
            get { return _totalProduto; }
            set
            {
                _totalProduto = value;
                OnPropertyChanged("TotalProduto");
            }
        }
        
        [DisplayFormat(DataFormatString = Constants.MaskMoney)]
        public decimal TotalPedido
        {
            get { return _totalPedido; }
            set
            {
                _totalPedido = value;
                OnPropertyChanged("TotalPedido");
            }
        }
        public bool IsPagamentoEfetuado
        {
            get
            {
                var totalPagamento = Pagamento.Sum(pag => pag.Valor);
                _isPagamentoEfetuado = TotalPedido <= totalPagamento;
                return _isPagamentoEfetuado;
            }

        }
        #endregion

        #region KeyGestures

        public KeyGesture KeyFinalizarPedido
        {
            get
            {
                return new KeyGesture(Key.F6);
            }
        }
        public KeyGesture KeyVoltarPedido
        {
            get
            {
                return new KeyGesture(Key.Escape);
            }
        }

        #endregion
        #region Commands

        public ICommand CmdPagamentoEfetuado
        {
            get { return _pagamentoEfetuado ?? (_pagamentoEfetuado = new RelayCommandBase(o => EfetuarPagamento())); }
            set
            {
                _pagamentoEfetuado = value;
                OnPropertyChanged("CmdPagamentoEfetuado");
            }
        }

        public ICommand CmdVoltarAoPedido
        {
            get { return _voltarAoPedido ?? (_voltarAoPedido = new RelayCommandBase(o => CancelarPagamento())); }
            set
            {
                _voltarAoPedido = value;
                OnPropertyChanged("CmdVoltarAoPedido");
            }
        }

        #endregion
        #region Eventos
        /// <summary>
        /// Evento chamado quando o pedido é finalizado com sucesso.
        /// </summary>
        public event PedidoFinalizadoEventHandler PedidoFinalizado;
        /// <summary>
        /// Evento chamado quando o usuário cancela o fechamento do pedido.
        /// </summary>
        public event PedidoVoltarEventHandler PedidoVoltar;

        protected virtual void OnPedidoVoltar(object o, EventArgs e)
        {
            PedidoVoltarEventHandler handler = PedidoVoltar;
            if (handler != null) handler(o, e);
        }

        protected virtual void OnPedidoFinalizado(object o, EventArgs e)
        {
            PedidoFinalizadoEventHandler handler = PedidoFinalizado;
            if (handler != null) handler(o, e);
        }

        #endregion

        public bool EfetuarPagamento()
        {
            if (IsPagamentoEfetuado)
            {
                OnPedidoFinalizado(this, EventArgs.Empty);
                return true;
            }
            System.Windows.Forms.MessageBox.Show("O pedido não foi totalmente pago...\n\n Confira os valores informados e tente novamente.");
            return false;
        }

        public bool CancelarPagamento()
        {
            OnPedidoVoltar(this, EventArgs.Empty);
            return true;
        }

        protected abstract void CalculaPedido();
    }

}
