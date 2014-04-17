using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using Vendas.Annotations;

namespace Vendas.ViewModel.Grids
{
    public class GridModelBase <T>: INotifyPropertyChanged
    {
        private ObservableCollection<T> _collection;
        private T _currentItem;


        public ObservableCollection<T> Collection
        {
            get { return _collection ?? (_collection = new ObservableCollection<T>()); }
            set
            {
                _collection = value; 
                OnPropertyChanged("Collection");
            }
        }

        public virtual T CurrentItem
        {
            get { return _currentItem; }
            set
            {
                _currentItem = value;
                OnPropertyChanged();
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
