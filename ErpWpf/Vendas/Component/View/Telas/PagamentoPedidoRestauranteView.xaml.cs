using Vendas.ViewModel.Forms;

namespace Vendas.Component.View.Telas
{
    /// <summary>
    /// Interaction logic for PagamentoPedidoRestauranteView.xaml
    /// </summary>
    public partial class PagamentoPedidoRestauranteView 
    {
        public PagamentoPedidoRestauranteView(PedidoModel pedido)
        {
            InitializeComponent();
            DataContext = pedido;
            pedido.PedidoFinalizado += pedido_PedidoFinalizado;
            pedido.PedidoVoltar += pedido_PedidoVoltar;
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
