using System;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using Util.Annotations;

namespace Util.Wpf
{
    public abstract class LargeDataModelGeneric <T> : INotifyPropertyChanged
    {
        public String Filter
        {
            get { return _filter; }
            set
            {
                if (value == _filter) return;
                _filter = value;
                Filtrar();
                OnPropertyChanged();
                
            }
        }

        private ObservableCollection<T> _collection;
        private string _filter;

        public abstract void Reset();
        public abstract void Filtrar();

        public ObservableCollection<T> Collection
        {
            get
            {
                try
                {
                    return _collection ?? (_collection = new ObservableCollection<T>());
                }
                catch (Exception)
                {
                    return new ObservableCollection<T>();
                }
                
            }
            set
            {
                if (Equals(value, _collection)) return;
                _collection = value;
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
