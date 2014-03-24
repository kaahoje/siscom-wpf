using System.Windows;
using Vendas.ViewModel.Forms;

namespace Vendas.Component.View.Telas
{
    /// <summary>
    /// Interaction logic for PagamentoPedidoRestauranteView.xaml
    /// </summary>
    public partial class PagamentoPedidoRestauranteView
    {
        public PagamentoPedidoRestauranteView(PedidoModel model)
        {
            InitializeComponent();
            DataContext = model;
            model.PedidoFinalizado += pedido_PedidoFinalizado;
            model.PedidoVoltar += pedido_PedidoVoltar;
        }

        void pedido_PedidoVoltar(object o, System.EventArgs e)
        {

            Hide();
        }

        void pedido_PedidoFinalizado(object o, System.EventArgs e)
        {
            Hide();
        }
    }
}
