using System;
using System.Collections.ObjectModel;
using System.Linq;
using System.Windows;
using System.Windows.Forms;
using System.Windows.Input;
using AutoMapper;
using DevExpress.Xpf.Ribbon.Customization;
using Ecf.Forms;
using Erp.Business.Entity.Vendas.Pedido.Restaurante;
using Erp.Business.Enum;
using RestauranteService;
using Util;
using Util.Wpf;
using Vendas.Component.View.Telas;
using Vendas.ViewModel.Forms;
using MessageBox = System.Windows.Forms.MessageBox;
using RestauranteService = RestauranteService.RestauranteService;

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
        private static global::RestauranteService.RestauranteService _service;

        #region Funções de restaurante para o caixa.

        public static global::RestauranteService.RestauranteService Service
        {
            get
            {
                if (_service == null)
                {
                    _service = new global::RestauranteService.RestauranteService();
                }
                return _service;
            }
            set { _service = value; }
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
                if (CurrentItem != null)
                {
                    CurrentItem.TelaPedidoVisible = value;
                }

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

        public event AcaoConcluidaEventHandler AcaoConcluida;

        protected virtual void OnAcaoConcluida()
        {
            AcaoConcluidaEventHandler handler = AcaoConcluida;
            if (handler != null) handler(this, EventArgs.Empty);
        }

        #endregion

        private void TrocarMesa()
        {
            try
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
            catch (Exception ex)
            {
                CustomMessageBox.MensagemErro(ex.Message);
                Erp.Business.Utils.GerarLog(ex);
            }

        }

        private void ProcurarMesa()
        {
            try
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
            catch (Exception ex)
            {
                CustomMessageBox.MensagemErro(ex.Message);
                Erp.Business.Utils.GerarLog(ex);
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
                CustomMessageBox.MensagemErro(ex.Message);
                Erp.Business.Utils.GerarLog(ex);
            }


        }
        private void NovaEntrega()
        {
            try
            {
                CurrentItem = new PedidoRestauranteModel();
                CurrentItem.NovoPedidoEntrega();
            }
            catch (Exception ex)
            {
                CustomMessageBox.MensagemErro(ex.Message);
                Erp.Business.Utils.GerarLog(ex);
            }

        }
        private void NovoBalcao()
        {
            try
            {
                CurrentItem = new PedidoRestauranteModel();
                CurrentItem.NovoPedidoBalcao();
            }
            catch (Exception ex)
            {
                CustomMessageBox.MensagemErro(ex.Message);
                Erp.Business.Utils.GerarLog(ex);
            }

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
                        Mapper.CreateMap(typeof(PedidoRestauranteModel), typeof(PedidoRestaurante));
                        Mapper.Map(mesa, mesa.EntityRestaurante);
                        Utils.ParcialMesa(mesa.EntityRestaurante);
                    }
                    else
                    {
                        CustomMessageBox.MensagemInformativa("A mesa não está aberta ou não foi confirmada ainda.");
                    }
                }

            }
            catch (Exception ex)
            {
                CustomMessageBox.MensagemErro(ex.Message);
                Erp.Business.Utils.GerarLog(ex);
            }

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
                    if (ped == null)
                    {
                        return;
                    }
                    if (!ped.IsPagamentoCancelado)
                    {
                        Collection.Remove(ped);

                        CurrentItem = null;
                    }
                }
                else
                {
                    var ped = GetEntrega(CurrentItem.EntityRestaurante.Controle.Controle);
                    FecharEntrega();
                    if (!ped.IsPagamentoCancelado)
                    {
                        CurrentItem = null;
                    }
                }
                AtualizarMesasAbertas();
                OnAcaoConcluida();
            }
            catch (Exception ex)
            {
                CustomMessageBox.MensagemErro(ex.Message);
                Erp.Business.Utils.GerarLog(ex);
            }

        }

        private void FecharMesa()
        {
            try
            {
                if (CurrentItem.EntityRestaurante.Local == LocalPedidoRestaurante.Mesa)
                {
                    CurrentItem.FecharPedido();

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
                        if (CurrentItem.FecharPedido()) Service.FecharMesa(mesa.EntityRestaurante.Mesa);

                    }
                }
            }
            catch (Exception ex)
            {
                CustomMessageBox.MensagemErro(ex.Message);
                Erp.Business.Utils.GerarLog(ex);
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
                        if (entrega.FecharPedido()) Service.FecharEntrega(numControle.Value);
                    }
                }
            }
            catch (Exception ex)
            {
                CustomMessageBox.MensagemErro(ex.Message);
                Erp.Business.Utils.GerarLog(ex);
            }

        }

        private void CancelarPedido()
        {
            try
            {
                if (CurrentItem == null)
                {
                    return;
                }

                if (CurrentItem.EntityRestaurante.Local == LocalPedidoRestaurante.Mesa)
                {
                    var result = MessageBox.Show("Deseja realmente cancelar esta mesa", "Cancelar mesa", MessageBoxButtons.YesNo, MessageBoxIcon.Asterisk, MessageBoxDefaultButton.Button2);
                    if (result == DialogResult.Yes)
                    {
                        Service.CancelarMesa(CurrentItem.EntityRestaurante.Mesa);

                    }

                }
                else
                {
                    var result = MessageBox.Show("Deseja realmente cancelar esta entrega", "Cancelar entrega", MessageBoxButtons.YesNo, MessageBoxIcon.Asterisk, MessageBoxDefaultButton.Button2);
                    if (result == DialogResult.Yes)
                    {
                        Service.CancelarEntrega(CurrentItem.EntityRestaurante.Controle.Controle);
                    }

                }
                AtualizarMesasAbertas();
            }
            catch (Exception ex)
            {
                CustomMessageBox.MensagemErro(ex.Message);
                Erp.Business.Utils.GerarLog(ex);
            }


        }
        private void ConfirmarPedido()
        {
            try
            {
                if (CurrentItem == null)
                {
                    return;
                }
                if (CurrentItem.EntityRestaurante == null)
                {
                    return;
                }
                if (!CurrentItem.EntityRestaurante.Confirmado)
                {
                    TrataRetornoRestauranteService(Service.ConfirmarPedido(CurrentItem.EntityRestaurante));
                    AtualizarMesasAbertas();
                    CurrentItem = null;
                }
            }
            catch (Exception ex)
            {
                CustomMessageBox.MensagemErro(ex.Message);
                Erp.Business.Utils.GerarLog(ex);
            }


        }

        private void AtualizarMesasAbertas()
        {
            Collection.Clear();
            foreach (var pedido in Service.GetMesasAbertas())
            {
                Collection.Add(new PedidoRestauranteModel()
                {
                    Entity = pedido
                });
            }
            
        }

        public static void TrataRetornoRestauranteService(StatusComando statusComando)
        {
            switch (statusComando)
            {
                    case StatusComando.ConcluidoSucesso:
                    break;
                default:
                    CustomMessageBox.MensagemErro(Service.GetLastException());
                    break;
            }
        }

        //private void RemoveEntrega(PedidoRestauranteModel entrega)
        //{
        //    try
        //    {
        //        FilaEntrega.Remove(entrega);
        //        if (CurrentItem != null && CurrentItem.IdGuid == entrega.IdGuid)
        //        {
        //            CurrentItem = null;
        //        }
        //    }
        //    catch (Exception ex)
        //    {
        //        CustomMessageBox.MensagemErro(ex.Message);
        //        Erp.Business.Utils.GerarLog(ex);
        //    }

        //}

        //private void RemoveMesa(PedidoRestauranteModel mesa)
        //{
        //    try
        //    {
        //        if (mesa.EntityRestaurante.Confirmado)
        //        {
        //            Collection.Remove(mesa);
        //        }
        //        if (CurrentItem != null && CurrentItem.EntityRestaurante.Mesa == mesa.EntityRestaurante.Mesa)
        //        {
        //            CurrentItem = null;
        //        }
        //        FilaSalao.Remove(mesa);
        //    }
        //    catch (Exception ex)
        //    {
        //        CustomMessageBox.MensagemErro(ex.Message);
        //        Erp.Business.Utils.GerarLog(ex);
        //    }


        //}

        private PedidoRestauranteModel GetMesa(int mesa)
        {
            return new PedidoRestauranteModel() { Entity = Service.GetMesa(mesa) };
        }
        private PedidoRestauranteModel GetEntrega(int controle)
        {
            return new PedidoRestauranteModel(){Entity = Service.GetEntrega(controle)};
        }
        public RestauranteModel()
        {
            
        }
    }
}
