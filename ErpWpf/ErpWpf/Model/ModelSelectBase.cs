using System.Windows;
using System.Windows.Input;
using DevExpress.Xpf.Core;
using Util.Wpf;

namespace Erp.Model
{
    public class ModelSelectBase : ModelBase
    {
        private string _filter;
        private int _selectedIndex;
        private DXWindow _windowSelect;

        #region Commands

        public ICommand CmdAbrirPesquisa
        {
            get { return new RelayCommandBase(x=>AbrirPesquisa());}
        }
        public ICommand CmdSair
        {
            get
            {
                return new RelayCommandBase(x => Sair());
            }
        }

        public ICommand CmdCancelarPesquisa
        {
            get
            {
                return new RelayCommandBase(x=> CancelarPesquisa());
            }
        }
        public ICommand CmdSelecionar
        {
            get
            {
                return new RelayCommandBase(x => Selecionar());
            }
        }
        
        #endregion
        #region Keys

        public KeyGesture KeyAbrirPesquisa
        {
            get { return new KeyGesture(Key.F5);}
        }
        public KeyGesture KeySelecionar
        {
            get
            {
                return new KeyGesture(Key.Enter);
            }
        }
        public virtual KeyGesture KeySair
        {
            get
            {
                return new KeyGesture(Key.Escape);
            }
        }
        
        #endregion
        #region Eventos
        #endregion
        #region Properties

        public DXWindow WindowSelect
        {
            get { return _windowSelect; }
            set
            {
                _windowSelect = value;
                if (value != null)
                {
                    _windowSelect.IsVisibleChanged += _windowSelect_IsVisibleChanged;
                }
                OnPropertyChanged("WindowSelect");
            }
        }

        void _windowSelect_IsVisibleChanged(object sender, DependencyPropertyChangedEventArgs e)
        {
            if ((bool) e.NewValue)
            {
                Limpar();
            }
        }

        public int SelectedIndex
        {
            get { return _selectedIndex; }
            set
            {
                _selectedIndex = value; 
                OnPropertyChanged("SelectedIndex");
            }
        }

        public string Filter
        {
            get { return _filter; }
            set
            {
                _filter = value;

                OnPropertyChanged("Filter");
                Filtrar();
            }
        }

        #endregion
        #region Métodos de ação

        public virtual void AbrirPesquisa()
        {
            if (WindowSelect != null)
            {
                //WindowSelect.DataContext = this;
                WindowSelect.ShowDialog();
            }
            else
            {
                MensagemErro("A tela de pesquisa não foi definida em ModelSelectBase.");
            }
        }
        protected virtual void Filtrar()
        {
            SelectedIndex = -1;
        }

        public virtual void Selecionar()
        {
            IsVisible = Visibility.Hidden;
        }

        public virtual void Sair()
        {

            IsCancelado = true;
            IsVisible = Visibility.Hidden;
            OnFechar();
        }

        
        #endregion

        public virtual void MovePrevious()
        {
            
        }
        public virtual void MoveNext()
        {
            
        }


        public virtual void CancelarPesquisa()
        {
            IsCancelado = true;
            IsVisible = Visibility.Hidden;
        }
    }
}
