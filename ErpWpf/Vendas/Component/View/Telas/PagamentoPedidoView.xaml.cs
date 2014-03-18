using System.Windows;
using System.Windows.Input;
using Erp.Business.Entity.Vendas.Pedido.Restaurante;
using Vendas.ViewModel.Forms;

namespace Vendas.Component.View.Telas
{
    /// <summary>
    /// Interaction logic for Fechamento.xaml
    /// </summary>
    public partial class PagamentoPedidoView 
    {
        private PedidoModel Model { get; set; }
        public PagamentoPedidoView(PedidoModel model)
        {
            
            Model = model;
            InitializeComponent();
            

        }

        protected override void OnPropertyChanged(DependencyPropertyChangedEventArgs e)
        {
            base.OnPropertyChanged(e);
            if (e.Property.Name == "DataContext")
            {
                var model = DataContext as PedidoModel;
                if (model != null)
                {
                    model.PedidoFinalizado += model_PedidoFinalizado;
                    model.PedidoVoltar += model_PedidoVoltar;
                }
            }
        }

        void model_PedidoVoltar(object o, System.EventArgs e)
        {
            Hide();
        }

        void model_PedidoFinalizado(object o, System.EventArgs e)
        {
            Hide();
        }

        public bool CancelarPagamento { get; set; }
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
