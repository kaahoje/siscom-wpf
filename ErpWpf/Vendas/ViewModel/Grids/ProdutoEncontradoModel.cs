using System;
using System.Collections.ObjectModel;
using System.Windows.Input;
using Erp.Business.Entity.Estoque.Produto;
using Util.Wpf;

namespace Vendas.ViewModel.Grids
{
    public delegate void AdicionarEventHandler(object sender, EventArgs e);
    public delegate void CancelarEventHandler(object sender, EventArgs e);
    public class ProdutoEncontradoModel : GridModelBase<Produto>
    {
        private ICommand _cmdAdicionar;
        private ICommand _cmdCancelar;

        public KeyGesture KeySelecionarProduto
        {
            get
            {
                return new KeyGesture(Key.F6);
            }
        }
        public KeyGesture KeyCancelar
        {
            get
            {
                return new KeyGesture(Key.F7);
            }
        }

        public ICommand CmdAdicionar
        {
            get { return _cmdAdicionar ?? (_cmdAdicionar = new RelayCommandBase(o=> OnAdicionar())); }
            set { _cmdAdicionar = value; }
        }

        public ICommand CmdCancelar
        {
            get { return _cmdCancelar ?? (_cmdCancelar = new RelayCommandBase(o=>OnCancelar())); }
            set { _cmdCancelar = value; }
        }

        public event AdicionarEventHandler Adicionar;
        public event CancelarEventHandler Cancelar;

        protected virtual void OnCancelar()
        {
            CancelarEventHandler handler = Cancelar;
            if (handler != null) handler(this, EventArgs.Empty);
        }

        protected virtual void OnAdicionar()
        {
            AdicionarEventHandler handler = Adicionar;
            if (handler != null) handler(this, EventArgs.Empty);
        }

        public ProdutoEncontradoModel()
        {
            Collection = new ObservableCollection<Produto>();
        }
    }
}
