﻿using System;
using System.Windows;
using System.Windows.Input;
using DevExpress.Xpf.Core;
using Util.Wpf;

namespace Erp.Model
{
    public class ModelFormBase : ModelBase
    {
        public ModelFormBase()
        {

        }
        public ModelFormBase(string columnName)
        {

            MensagemOperacaoConcluida = "Operação concluída com sucesso.";
            ComplementoMensagem = "";
        }
        private ICommand _cmdExcluir;
        private ICommand _cmdSalvar;
        private ICommand _cmdSair;
        private KeyGesture _keySair;
        private KeyGesture _keyExcluir;
        private KeyGesture _keySalvar;
        private bool _isSalvar = true;
        private bool _isExcluir = true;
        private ICommand _cmdPesquisar;

        #region Keys
        public KeyGesture KeyPesquisa
        {
            get
            {
                return new KeyGesture(Key.F5);
            }
        }
        public KeyGesture KeySalvar
        {
            get { return _keySalvar ?? (_keyExcluir = new KeyGesture(Key.F6)); }
            set
            {
                _keySalvar = value;
                OnPropertyChanged("KeySalvar");
            }
        }

        public KeyGesture KeyExcluir
        {
            get { return _keyExcluir ?? (_keyExcluir = new KeyGesture(Key.F7)); }
            set
            {
                _keyExcluir = value;
                OnPropertyChanged("KeyExcluir");
            }
        }

        public KeyGesture KeySair
        {
            get { return _keySair ?? (_keySair = new KeyGesture(Key.Escape)); }
            set
            {
                _keySair = value;
                OnPropertyChanged("KeySair");
            }
        }

        #endregion

        #region Commands

        public ICommand CmdPesquisar
        {
            get { return _cmdPesquisar ?? (_cmdPesquisar = new RelayCommandBase(x => Pesquisar())); }
            set
            {
                _cmdPesquisar = value;
                OnPropertyChanged("CmdPesquisar");
            }
        }

        public ICommand CmdExcluir
        {
            get { return _cmdExcluir ?? (_cmdExcluir = new RelayCommandBase(x => Excluir())); }
            set
            {
                _cmdExcluir = value;
                OnPropertyChanged("CmdExcluir");
            }
        }

        public ICommand CmdSalvar
        {
            get { return _cmdSalvar ?? (_cmdSalvar = new RelayCommandBase(x => Salvar())); }
            set
            {
                _cmdSalvar = value;
                OnPropertyChanged("CmdSalvar");
            }
        }

        public ICommand CmdSair
        {
            get { return _cmdSair ?? (_cmdSair = new RelayCommandBase(x => Sair())); }
            set
            {
                _cmdSair = value;
                OnPropertyChanged("CmdSair");
            }
        }

        #endregion

        #region Operacoes

        public virtual void Pesquisar()
        {

        }

        public virtual void Salvar()
        {
            OperacaoConcluida();
        }

        public virtual void Excluir()
        {
            OperacaoConcluida();
        }
        public virtual void Sair()
        {
            var result = DXMessageBox.Show(null, "Deseja realmente sair deste formulário?", "Atenção",
                MessageBoxButton.YesNo, MessageBoxImage.Question, MessageBoxResult.Yes);
            if (result == MessageBoxResult.Yes)
            {
                IsVisible = Visibility.Hidden;
            }

        }



        protected void EntityChanged(object entity)
        {
            var prop = entity.GetType().GetProperty("Id");
            if (prop != null)
            {
                var value = (int)prop.GetValue(entity);
                IsExcluir = value != 0;
            }

        }

        protected virtual void OperacaoConcluida()
        {
            DXMessageBox.Show(string.Format(MensagemOperacaoConcluida, ComplementoMensagem));
            IsVisible = Visibility.Hidden;
        }



        #endregion

        #region Eventos



        #endregion

        #region Propriedades



        public bool IsExcluir
        {
            get { return _isExcluir; }
            set
            {
                _isExcluir = value;
                OnPropertyChanged("IsExcluir");
            }
        }

        public bool IsSalvar
        {
            get { return _isSalvar; }
            set
            {
                _isSalvar = value;
                OnPropertyChanged("IsSalvar");
            }
        }




        #endregion



    }


}
