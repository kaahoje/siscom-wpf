namespace Vendas.ViewModel.Forms
{
    public class FormModelGeneric<T> : FormModelBase
    {
        public virtual void CalculaPedido()
        {
            
        }

        private T _entity;

        public virtual T Entity
        {
            get { return _entity; }
            set
            {
                _entity = value;

                OnPropertyChanged("Entity");
            }
        }
    }
}
