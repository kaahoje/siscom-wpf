using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Runtime.CompilerServices;
using System.Windows;
using System.Windows.Input;
using DevExpress.Xpf.Core;
using Erp.Annotations;
using Erp.Business;
using FluentNHibernate.Conventions;
using Util;
using Util.Wpf;

namespace Erp.Model
{
    public delegate void FecharEventHandler(object sender, EventArgs e);
    public class ModelBase : INotifyPropertyChanged, IDataErrorInfo
    {
        protected string MensagemFuncaoNaoSuportada = "Esta função não é suportada pelo formulário";
        private Visibility _isVisible;
        private bool _isCancelado;
        public Constants Constants {get {return new Constants();}}


        private Dictionary<string, string> errorMessages = new Dictionary<string, string>();
        private string _error;
        private string _mensagemOperacaoConcluida;
        private string _complementoMensagem;
        private bool _isLimpar = true;

        #region KeyGestures

        public KeyGesture KeyLimpar { get { return new KeyGesture(Key.L, ModifierKeys.Control); } }

        #endregion

        #region Eventos

        public event PropertyChangedEventHandler PropertyChanged;

        [NotifyPropertyChangedInvocator]
        protected virtual void OnPropertyChanged([CallerMemberName] string propertyName = null)
        {
            PropertyChangedEventHandler handler = PropertyChanged;
            if (handler != null) handler(this, new PropertyChangedEventArgs(propertyName));
        }

        public event FecharEventHandler Fechar;

        protected virtual void OnFechar()
        {
            FecharEventHandler handler = Fechar;
            if (handler != null) handler(this, EventArgs.Empty);
        }

        #endregion

        #region Propriedades

        public String ComplementoMensagem
        {
            get { return _complementoMensagem ?? (_complementoMensagem = ""); }
            set
            {
                _complementoMensagem = value;
                OnPropertyChanged("ComplementoMensagem");
            }
        }

        public string MensagemOperacaoConcluida
        {
            get { return _mensagemOperacaoConcluida ?? (_mensagemOperacaoConcluida = "Operação concluída com sucesso."); }
            set
            {
                _mensagemOperacaoConcluida = value;
                OnPropertyChanged("MensagemOperacaoConcluida");
            }
        }

        public string this[string columnName]
        {
            get
            {
                if (errorMessages.ContainsKey(columnName))
                    return errorMessages[columnName];
                return null;

            }
        }




        public string Error
        {
            get { return _error; }
            private set
            {
                _error = value;
                OnPropertyChanged("Error");
            }
        }

        public bool IsCancelado
        {
            get { return _isCancelado; }
            set
            {
                _isCancelado = value;
                OnPropertyChanged("IsCancelado");
            }
        }

        public Visibility IsVisible
        {
            get { return _isVisible; }
            set
            {
                _isVisible = value;
                OnPropertyChanged("IsVisible");
            }
        }

        public bool IsLimpar
        {
            get { return _isLimpar; }
            set
            {
                _isLimpar = value; 
                OnPropertyChanged("IsLimpar");
            }
        }

        #endregion

        #region Commands

        public ICommand CmdLimpar
        {
            get
            {
                return new RelayCommandBase(x => Limpar());
            }
        }

        #endregion

        #region Operações
        public static void MensagemErro(string mensagem)
        {
            CustomMessageBox.MensagemErro(mensagem);
            
        }
        public static void MensagemInformativa(string mensagem)
        {
            CustomMessageBox.MensagemInformativa(mensagem);
            
        }

        public static void MensagemErroBancoDados(string mensagem)
        {
            CustomMessageBox.MensagemErroBancoDados(mensagem);
            
        }
        public virtual void Limpar()
        {

        }
        protected bool ConfirmDelete()
        {
            var result = DXMessageBox.Show(null, "Deseja realmente excluir este registro?", "Atenção",
               MessageBoxButton.YesNo, MessageBoxImage.Question, MessageBoxResult.Yes);
            if (result == MessageBoxResult.Yes)
            {
                return true;
            }
            return false;
        }

        protected void Validate(object entity)
        {
            errorMessages.Clear();
            Error = "";
            var properties = entity.GetType().GetProperties();
            foreach (var propertyInfo in properties)
            {
                var attributes = propertyInfo.GetCustomAttributes(typeof(ValidationAttribute), true);
                var displayAttributes = propertyInfo.GetCustomAttributes(typeof(DisplayAttribute), true);
                foreach (var attribute in attributes)
                {
                    var attr = attribute as ValidationAttribute;
                    var displayName = "";
                    if(displayAttributes.IsNotEmpty())displayName = displayAttributes.IsEmpty() ? propertyInfo.Name : ((DisplayAttribute)displayAttributes[0]).Name;
                    if (attr == null) continue;

                    var propValue = propertyInfo.GetValue(entity);



                    if (attr.IsValid(propValue)) continue;
                    var msg = string.Format(attr.ErrorMessage, displayName);
                    errorMessages.Add(propertyInfo.Name, msg);
                    Error += msg;
                    MensagemErroBancoDados(msg);
                    return;
                }
            }

        }





        public bool IsValid(object obj)
        {
            Validate(obj);
            if (errorMessages.IsEmpty()) return true;
            return false;
        }
        #endregion
    }
}
