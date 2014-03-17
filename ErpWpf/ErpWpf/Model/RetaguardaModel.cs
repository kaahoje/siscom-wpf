﻿using System;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Windows.Controls;
using System.Windows.Input;
using DevExpress.Xpf.Docking;
using Erp.View.Forms;
using ErpWpf.Annotations;
using Util.Wpf;

namespace Erp.Model
{
    public delegate void TelaAbertaEventHandler(object sender, TelaAbertaEventArgs e);

    public class RetaguardaModel :INotifyPropertyChanged
    {
        
        
        #region Eventos

        public event TelaAbertaEventHandler TelaAberta;

        protected virtual void OnTelaAberta(string caption, UserControl control)
        {
            TelaAbertaEventHandler handler = TelaAberta;
            
            if (handler != null) handler(this, new TelaAbertaEventArgs()
            {
                Control = control,
                Caption = caption
            });
        }

        #endregion

        #region Keys

        
        public KeyGesture KeyTelaProduto
        {
            get
            {
                return new KeyGesture(Key.P,ModifierKeys.Alt);
            }
        }
        public KeyGesture KeyTelaCondicaoPagamento
        {
            get
            {
                return new KeyGesture(Key.C,ModifierKeys.Alt);
            }
        }
        public KeyGesture KeyTelaFormaPagamento
        {
            get
            {
                return new KeyGesture(Key.F,ModifierKeys.Alt);
            }
        }
        public KeyGesture KeyTelaTransferencias
        {
            get
            {
                return new KeyGesture(Key.F,ModifierKeys.Alt);
            }
        }
        public KeyGesture KeyTelaLancamentos
        {
            get
            {
                return new KeyGesture(Key.F,ModifierKeys.Alt);
            }
        }

        #endregion
        #region Properties
        #endregion
        #region Commands

        public ICommand CmdAbrirTelaGrupoProduto
        {
            get { return new RelayCommandBase(x=> AbrirTelaGrupoProduto());}
        }

        public ICommand CmdAbrirTelaProduto
        {
            get { return new RelayCommandBase(o=>AbrirTelaProduto()); }
            
        }
        public ICommand CmdAbrirTelaFormaPagamento
        {
            get { return  new RelayCommandBase(o=>AbrirTelaFormaPagamento()); }
            
        }
        public ICommand CmdAbrirTelaNcm
        {
            get { return new RelayCommandBase(o=>AbrirTelaNcm()); }
            
        }

        public ICommand CmdAbrirTelaCondicaoPagamento
        {
            get { return new RelayCommandBase(x=> AbrirTelaCondicaoPagamento()); }
            
        }

        #endregion

        #region Comandos de abertura de tela

        public void AbrirTelaGrupoProduto()
        {
            new GrupoProdutoFormView().ShowDialog();
        }
        public void AbrirTelaProduto()
        {
            new ProdutoFormView().ShowDialog();
        }
        public void AbrirTelaFormaPagamento()
        {
            new FormaPagamentoFormView().ShowDialog();
        }
        public void AbrirTelaNcm()
        {
            new NcmFormView().ShowDialog();
        }

        public void AbrirTelaCondicaoPagamento()
        {
            new CondicaoPagamentoFormView().ShowDialog();
        }

        #endregion
       
        public void AbrirTela(string caption, UserControl control)
        {
            OnTelaAberta(caption,control);
        }

        public void FecharTela(DocumentPanel panel)
        {
            
        }

        public event PropertyChangedEventHandler PropertyChanged;

        [NotifyPropertyChangedInvocator]
        protected virtual void OnPropertyChanged([CallerMemberName] string propertyName = null)
        {
            PropertyChangedEventHandler handler = PropertyChanged;
            if (handler != null) handler(this, new PropertyChangedEventArgs(propertyName));
        }
    }

    public class TelaAbertaEventArgs : EventArgs
    {
        public string Caption { get; set; }
        public UserControl Control { get; set; }
    }
}