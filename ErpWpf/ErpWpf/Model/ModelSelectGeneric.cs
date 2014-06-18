using System;
using System.Collections.ObjectModel;
using FluentNHibernate.Conventions;

namespace Erp.Model
{
    public class ModelSelectGeneric<T> : ModelSelectBase
    {
        private T _currentItem;
        private ObservableCollection<T> _collection;

        public T CurrentItem{
            get { return _currentItem; }
            set
            {
                _currentItem = value;
                OnPropertyChanged();

            }
        }

        public ObservableCollection<T> Collection
        {
            get { return _collection ?? (_collection = new ObservableCollection<T>()); }
            set
            {
                _collection = value;
                OnPropertyChanged("Collection");
            }
        }

        public override void CancelarPesquisa()
        {
            CurrentItem = Activator.CreateInstance<T>();

            base.CancelarPesquisa();
        }

        public override void Sair()
        {
            CurrentItem = Activator.CreateInstance<T>();

            base.Sair();

        }

        public override void Limpar()
        {
            Filter = "";
            Collection.Clear();
            
        }

        public override void MoveNext()
        {
            if (Collection == null) return;
            if (Collection.IsNotEmpty())
            {
                if (SelectedIndex == -1)
                {
                    SelectedIndex = 0;
                }
                else
                {
                    if (SelectedIndex < Collection.Count - 1)
                    {
                        SelectedIndex += 1;
                    }
                }
                CurrentItem = Collection[SelectedIndex];

            }
            else
            {
                SelectedIndex = -1;
            }

        }

        public override void MovePrevious()
        {
            if (Collection == null) return;
            if (Collection.IsNotEmpty())
            {
                if (SelectedIndex == -1)
                {
                    SelectedIndex = Collection.Count - 1;
                }
                else
                {
                    if (SelectedIndex > 0)
                    {
                        SelectedIndex -= 1;
                    }
                }
                CurrentItem = Collection[SelectedIndex];

            }
            else
            {
                SelectedIndex = -1;
            }

        }
    }
}
