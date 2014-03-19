using System;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Windows.Input;
using Util;
using Util.Wpf;
using Vendas.Annotations;

namespace Vendas.ViewModel.Forms
{
    public delegate void SairEventHandler(object sender, EventArgs e);
    public class FormModelBase : INotifyPropertyChanged
    {
        private ICommand _cmdSalvar;
        private ICommand _cmdSair;

        #region Eventos

        public event SairEventHandler Sair;

        protected virtual void OnSair()
        {
            SairEventHandler handler = Sair;
            if (handler != null) handler(this, EventArgs.Empty);
        }

        #endregion

        #region KeyGestures

        public KeyGesture KeySalvar { get { return new KeyGesture(Key.F6);} }
        public KeyGesture KeyFechar { get { return new KeyGesture(Key.Escape);} }

        #endregion

        #region Commands

        public ICommand CmdSalvar
        {
            get
            {
                return _cmdSalvar ?? (_cmdSalvar = new RelayCommandBase(x => Salvar()));
                
            }
            set
            {
                _cmdSalvar = value; 
                OnPropertyChanged("CmdSalvar");
            }

        }

        public ICommand CmdSair
        {
            get { return _cmdSair ?? (_cmdSair = new RelayCommandBase(x => Fechar())); }
            set
            {
                _cmdSair = value; 
                OnPropertyChanged("CmdSair");
            }
        }

        #endregion

        public void Fechar()
        {
            OnSair();
        }
        public virtual void Salvar()
        {
            OperacaoConcluida();
            OnSair();
        }

        protected void OperacaoConcluida()
        {
            CustomMessageBox.MensagemInformativa("Operação concluída com sucesso.");
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
