using System;
using System.Collections.ObjectModel;
using System.Linq;
using System.Windows;
using System.Windows.Forms;
using System.Windows.Input;
using Ecf.Forms;
using Erp.Business.Enum;
using Util;
using Util.Wpf;
using Vendas.Component.View.Telas;
using Vendas.ViewModel.Forms;
using MessageBox = System.Windows.Forms.MessageBox;

namespace Vendas.ViewModel.Grids
{
    public delegate void AcaoConcluidaEventHandler(object sender, EventArgs e);

    public class RestauranteModel : GridModelBase<PedidoRestauranteModel>
    {

        #region Keys

        public KeyGesture KeyTrocaMesa
        {
            get
            {
                return new KeyGesture(Key.T, ModifierKeys.Control);
            }
        }
        public KeyGesture KeyProcurarMesa
        {
            get
            {
                return new KeyGesture(Key.F9);
            }
        }
        public KeyGesture KeyNovaMesa
        {
            get
            {
                return new KeyGesture(Key.F2);
            }
        }
        public KeyGesture KeyNovoBalcao
        {
            get
            {
                return new KeyGesture(Key.F3);
            }
        }
        public KeyGesture KeyNovaEntrega
        {
            get
            {
                return new KeyGesture(Key.F4);
            }
        }
        public KeyGesture KeyFecharPedido
        {
            get
            {
                return new KeyGesture(Key.F6);
            }
        }
        public KeyGesture KeyConfirmarPedido
        {
            get
            {
                return new KeyGesture(Key.F5);
            }
        }
        public KeyGesture KeyCancelarPedido
        {
            get
            {
                return new KeyGesture(Key.Delete, ModifierKeys.Control);
            }
        }
        public KeyGesture KeyParcialMesa
        {
            get
            {
                return new KeyGesture(Key.F8);
            }
        }

        #endregion

        #region Commands

        public ICommand CmdMenuFiscal
        {
            get { return _cmdMenuFiscal ?? (_cmdMenuFiscal = new RelayCommandBase(o => MenuFiscal())); }

        }

        public ICommand CmdTrocarMesa
        {
            get
            {
                var ret = _cmdTrocarMesa ?? (_cmdTrocarMesa = new RelayCommandBase(o => TrocarMesa()));

                return ret;
            }
        }

        public ICommand CmdProcurarMesa
        {
            get { return _cmdProcurarMesa ?? (_cmdProcurarMesa = new RelayCommandBase(o => ProcurarMesa())); }

        }

        public ICommand CmdNovaMesa
        {
            get
            {
                var ret = _cmdNovaMesa ?? (_cmdNovaMesa = new RelayCommandBase(o => NovaMesa()));
                return ret;
            }
        }

        public ICommand CmdNovaEntrega
        {
            get
            {
                var ret = _cmdNovaEntrega ?? (_cmdNovaEntrega = new RelayCommandBase(o => NovaEntrega()));
                return ret;
            }
        }

        public ICommand CmdNovoBalcao
        {
            get
            {
                var ret = _cmdNovoBalcao ?? (_cmdNovoBalcao = new RelayCommandBase(o => NovoBalcao()));
                return ret;
            }
        }

        public ICommand CmdFecharPedido
        {
            get
            {
                var ret = _cmdFecharPedido ?? (_cmdFecharPedido = new RelayCommandBase(o => FecharPedido()));
                return ret;
            }

        }

        public ICommand CmdParcialMesa
        {
            get
            {
                var ret = _cmdParcialMesa ?? (_cmdParcialMesa = new RelayCommandBase(o => Parcial()));

                return ret;
            }
        }

        public ICommand CmdConfirmarPedido
        {
            get
            {
                var ret = _cmdConfirmarPedido ?? (_cmdConfirmarPedido = new RelayCommandBase(o => ConfirmarPedido()));

                return ret;
            }
        }

        public ICommand CmdCancelarPedido
        {
            get
            {
                var ret = _cmdCancelarPedido ?? (_cmdCancelarPedido = new RelayCommandBase(o => CancelarPedido()));
                return ret;
            }

        }

        #endregion Fim Commands

        private PedidoRestauranteModel _currentItem;
        private ObservableCollection<PedidoRestauranteModel> _filaEntrega;
        private ObservableCollection<PedidoRestauranteModel> _filaSalao;
        private bool _funcoesFilaVisible;
        private bool _funcoesPedidoVisible;
        private bool _entregasVisible;
        private ICommand _cmdTrocarMesa;
        private ICommand _cmdNovaMesa;
        private ICommand _cmdParcialMesa;
        private ICommand _cmdNovaEntrega;
        private ICommand _cmdNovoBalcao;
        private ICommand _cmdConfirmarPedido;
        private ICommand _cmdFecharPedido;
        private bool _confirmarPedidoVisible;
        private ICommand _cmdCancelarPedido;
        private Visibility _telaPedidoVisible = Visibility.Hidden;
        private ICommand _cmdProcurarMesa;
        private ICommand _cmdMenuFiscal;


        public ObservableCollection<PedidoRestauranteModel> FilaEntrega
        {
            get { return _filaEntrega; }
            set
            {
                _filaEntrega = value;
                OnPropertyChanged();
            }
        }

        public ObservableCollection<PedidoRestauranteModel> FilaSalao
        {
            get { return _filaSalao; }
            set
            {
                _filaSalao = value;
                OnPropertyChanged();
            }
        }

        public override PedidoRestauranteModel CurrentItem
        {
            get { return _currentItem; }
            set
            {
                _currentItem = value;
                if (_currentItem == null)
                {

                    FuncoesPedidoVisible = false;
                    TelaPedidoVisible = Visibility.Hidden;
                }
                else
                {
                    TelaPedidoVisible = Visibility.Visible;
                    FuncoesPedidoVisible = true;
                    FuncoesFilaVisible = false;
                    ConfirmarPedidoVisible = !CurrentItem.EntityRestaurante.Confirmado;
                }
                OnPropertyChanged("CurrentItem");

            }
        }

        public bool ConfirmarPedidoVisible
        {
            get { return _confirmarPedidoVisible; }
            set
            {
                _confirmarPedidoVisible = value;
                OnPropertyChanged();
            }
        }

        public Visibility TelaPedidoVisible
        {
            get { return _telaPedidoVisible; }
            set
            {
                _telaPedidoVisible = value;
                OnPropertyChanged();
            }
        }

        public bool FuncoesFilaVisible
        {
            get { return _funcoesFilaVisible; }
            set
            {
                _funcoesFilaVisible = value;
                OnPropertyChanged();
            }
        }

        public bool FuncoesPedidoVisible
        {
            get { return _funcoesPedidoVisible; }
            set
            {
                
                _funcoesPedidoVisible = value;
                OnPropertyChanged();
            }
        }

        public bool EntregasVisible
        {
            get { return _entregasVisible; }
            set
            {
                _entregasVisible = value;
                OnPropertyChanged();
            }
        }

        private void MenuFiscal()
        {
            new FormMenuFiscal(FormMenuFiscal.MenuFiscalTipo.Restaurante).ShowDialog();
        }
        private void TrocarMesa()
        {
            var numOrigem = new NumeroView();
            var numDestino = new NumeroView();
            numOrigem.ShowDialog();
            numDestino.ShowDialog();
            if (numDestino.Value == 0 || numOrigem.Value == 0)
            {
                return;
            }
            if (numOrigem.Value == numDestino.Value)
            {
                MessageBox.Show(string.Format("Mesa de destino é a mesma de origem"));
                return;
            }
            var entity = GetMesa(numOrigem.Value);
            if (entity == null)
            {
                MessageBox.Show(string.Format("A mesa {0} não está aberta", numOrigem.Value));
                return;
            }
            entity.EntityRestaurante.Mesa = numDestino.Value;
        }

        private void ProcurarMesa()
        {
            var numMesa = new NumeroView();
            numMesa.Title = "Informe o número da mesa";
            numMesa.ShowDialog();
            var mesa = GetMesa(numMesa.Value);
            if (mesa != null)
            {
                CurrentItem = mesa;
            }
            else
            {
                if (numMesa.Value != 0) MessageBox.Show("A mesa não está aberta no momento");
            }
        }

        private void NovaMesa()
        {
            try
            {
                var novaMesa = new PedidoRestauranteModel();


                if (novaMesa.NovoPedidoMesa())
                {
                    CurrentItem = novaMesa;
                }

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }


        }
        private void NovaEntrega()
        {
            CurrentItem = new PedidoRestauranteModel();
            CurrentItem.NovoPedidoEntrega();
        }
        private void NovoBalcao()
        {
            CurrentItem = new PedidoRestauranteModel();
            CurrentItem.NovoPedidoBalcao();
        }

        private void Parcial()
        {
            try
            {
                var numMesa = new NumeroView();
                numMesa.ShowDialog();
                if (numMesa.Value != 0)
                {
                    var mesa = GetMesa(numMesa.Value);
                    if (mesa != null)
                    {
                        Utils.ParcialMesa(mesa.EntityRestaurante);
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }

        }

        public event AcaoConcluidaEventHandler AcaoConcluida;

        protected virtual void OnAcaoConcluida()
        {
            AcaoConcluidaEventHandler handler = AcaoConcluida;
            if (handler != null) handler(this, EventArgs.Empty);
        }

        private void FecharPedido()
        {
            try
            {
                if (CurrentItem == null)
                {
                    return;
                }
                if (CurrentItem.EntityRestaurante.Local == LocalPedidoRestaurante.Mesa)
                {
                    var ped = GetMesa(CurrentItem.EntityRestaurante.Mesa);
                    FecharMesa();
                    Collection.Remove(ped);
                    FilaSalao.Remove(ped);
                }
                else
                {
                    var ped = GetEntrega(CurrentItem.EntityRestaurante.Controle.Controle);
                    FecharEntrega();
                    FilaEntrega.Remove(ped);

                }
                if (CurrentItem == null)
                {
                    TelaPedidoVisible = Visibility.Hidden;
                }
                OnAcaoConcluida();
            }
            catch (Exception ex)
            {
                CustomMessageBox.MensagemErro(ex.Message);
            }
            
        }

        private void FecharMesa()
        {
            try
            {
                if (CurrentItem.EntityRestaurante.Local == LocalPedidoRestaurante.Mesa)
                {
                    CurrentItem.FecharPedido();
                    CurrentItem = null;
                }
                else
                {
                    var numMesa = new NumeroView();
                    numMesa.ShowDialog();
                    if (numMesa.Value != 0)
                    {
                        var mesa = GetMesa(numMesa.Value);
                        if (mesa == null)
                        {
                            MessageBox.Show("A mesa não está aberta no momento");
                            return;
                        }
                        CurrentItem = mesa;
                        if (CurrentItem.FecharPedido()) RemoveMesa(mesa);

                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }

        }

        private void FecharEntrega()
        {
            try
            {
                var numControle = new NumeroView();
                numControle.ShowDialog();
                if (numControle.Value != 0)
                {
                    var entrega = GetEntrega(numControle.Value);
                    if (entrega != null)
                    {
                        if (entrega.FecharPedido()) RemoveEntrega(entrega);
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }

        }

        private void CancelarPedido()
        {

            if (CurrentItem == null)
            {
                return ;
            }

            if (CurrentItem.EntityRestaurante.Local == LocalPedidoRestaurante.Mesa)
            {
                var result = MessageBox.Show("Deseja realmente cancelar esta mesa", "Cancelar mesa", MessageBoxButtons.YesNo, MessageBoxIcon.Asterisk, MessageBoxDefaultButton.Button2);
                if (result == DialogResult.Yes)
                {
                    RemoveMesa(CurrentItem);
                }

            }
            else
            {
                var result = MessageBox.Show("Deseja realmente cancelar esta entrega", "Cancelar entrega", MessageBoxButtons.YesNo, MessageBoxIcon.Asterisk, MessageBoxDefaultButton.Button2);
                if (result == DialogResult.Yes)
                {
                    RemoveEntrega(CurrentItem);
                }

            }

        }
        private void ConfirmarPedido()
        {
            if (CurrentItem == null)
            {
                return;
            }
            if (!CurrentItem.EntityRestaurante.Confirmado)
            {
                switch (CurrentItem.EntityRestaurante.Local)
                {
                    case LocalPedidoRestaurante.Mesa:
                        var mesaAberta = GetMesa(CurrentItem.EntityRestaurante.Mesa);
                        if (mesaAberta != null)
                        {
                            foreach (var prod in CurrentItem.Produtos)
                            {
                                mesaAberta.AddProduto(prod);
                            }
                        }
                        else
                        {
                            Collection.Add(CurrentItem);
                        }
                        break;
                    default:
                        switch (CurrentItem.EntityRestaurante.Local)
                        {
                            case LocalPedidoRestaurante.Balcao:
                                FilaSalao.Add(CurrentItem);
                                break;
                            case LocalPedidoRestaurante.Entrega:
                                FilaEntrega.Add(CurrentItem);
                                break;
                        }
                        break;
                }
                CurrentItem.ConfirmarPedido();
                CurrentItem = null;
            }

        }
        private void RemoveEntrega(PedidoRestauranteModel entrega)
        {
            FilaEntrega.Remove(entrega);
            if (CurrentItem.IdGuid == entrega.IdGuid)
            {
                CurrentItem = null;
            }
        }

        private void RemoveMesa(PedidoRestauranteModel mesa)
        {
            Collection.Remove(mesa);
            Collection = Collection;
            FilaSalao.Remove(mesa);
            if (CurrentItem.IdGuid == mesa.IdGuid)
            {
                CurrentItem = null;
            }
        }

        private PedidoRestauranteModel GetMesa(int mesa)
        {
            return Collection.SingleOrDefault(m => m.EntityRestaurante.Mesa == mesa);
        }
        private PedidoRestauranteModel GetEntrega(int controle)
        {
            return Collection.SingleOrDefault(m => m.EntityRestaurante.Controle.Controle == controle);
        }
        public RestauranteModel()
        {
            Collection = new ObservableCollection<PedidoRestauranteModel>();
            FilaEntrega = new ObservableCollection<PedidoRestauranteModel>();
            FilaSalao = new ObservableCollection<PedidoRestauranteModel>();
            //for (int i = 0; i < 100; i++)
            //{
            //    Collection.Add(new PedidoRestauranteModel()
            //    {
            //        Entity = new PedidoRestaurante()
            //        {
            //            DataPedido = DateTime.Now,
            //            Mesa = i
            //        }
            //    });
            //}


        }
    }
}
