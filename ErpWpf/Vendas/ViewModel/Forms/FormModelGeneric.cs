namespace Vendas.ViewModel.Forms
{
    public class FormModelGeneric<T> : FormModelBase
    {
        private T _entity;

        public T Entity
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
