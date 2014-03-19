using Vendas.ViewModel.Forms;

namespace Vendas.ViewModel.Grids
{
    public class FilaModel : GridModelBase<PedidoRestauranteModel>
    {
        private RestauranteModel _restauranteModel;

        public virtual RestauranteModel RestauranteModel
        {
            get { return _restauranteModel; }
            set
            {
                _restauranteModel = value; 
                OnPropertyChanged();
            }
        }
    }
}
