using System.ComponentModel;
using System.Runtime.CompilerServices;
using Vendas.Annotations;

namespace Vendas.ViewModel.Forms
{
    public class FormModelBase<T> : INotifyPropertyChanged
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

        public event PropertyChangedEventHandler PropertyChanged;

        [NotifyPropertyChangedInvocator]
        protected virtual void OnPropertyChanged([CallerMemberName] string propertyName = null)
        {
            PropertyChangedEventHandler handler = PropertyChanged;
            if (handler != null) handler(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}
