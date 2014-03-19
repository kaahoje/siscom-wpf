using System;
using System.Windows;
using System.Windows.Forms.VisualStyles;
using System.Windows.Input;
using Vendas.ViewModel.Forms;

namespace Vendas.Component.View.Telas
{
    /// <summary>
    /// Interaction logic for Fechamento.xaml
    /// </summary>
    public partial class PagamentoPedidoView
    {
        public delegate void PagamentoCanceladoEventHandler(object sender, EventArgs e);

        private PedidoModel Model
        {
            get { return (PedidoModel) DataContext; }
        }

        public PagamentoPedidoView(PedidoModel model)
        {
            InitializeComponent();
            DataContext = model;
        }

        public event PagamentoCanceladoEventHandler PagamentoCancelado;
        protected override void OnPropertyChanged(DependencyPropertyChangedEventArgs e)
        {
            base.OnPropertyChanged(e);
            if (e.Property.Name.Equals("DataContext"))
            {
                Model.PedidoVoltar += model_PedidoVoltar;
                Model.PedidoFinalizado += model_PedidoFinalizado;
            }
        }

        protected virtual void OnPagamentoCancelado()
        {
            PagamentoCanceladoEventHandler handler = PagamentoCancelado;
            if (handler != null) handler(this, EventArgs.Empty);
        }

        void model_PedidoVoltar(object o, System.EventArgs e)
        {
            Model.IsPagamentoCancelado = true;
            OnPagamentoCancelado();
            Hide();
        }

        void model_PedidoFinalizado(object o, System.EventArgs e)
        {
            Hide();
        }


        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            DataContext = Model;
            Model.Acressimo = Model.Acressimo;
            Model.CondicaoPagamento = Model.CondicaoPagamento;
        }

        private void PagamentoPedidoView_OnPreviewKeyDown(object sender, KeyEventArgs e)
        {
            if (e.Key == Key.Escape)
            {
                Hide();
            }
        }
    }
}
