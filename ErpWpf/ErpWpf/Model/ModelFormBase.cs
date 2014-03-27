using System;
using System.Linq;
using System.Windows;
using System.Windows.Input;
using DevExpress.Xpf.Core;
using Erp.Business.Enum;
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
        private ICommand _cmdPesquisar;
        private bool _isSalvar = true;
        private bool _isExcluir = false; 
        private bool _isPesquisar = true;

        

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
            get { return _keySair ?? (_keySair = new KeyGesture(Key.F4,ModifierKeys.Control)); }
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
        public bool TelaPermitida()
        {
            var permissao = App.Usuario.PermissaoFormulario.SingleOrDefault(x => x.Formulario == Formulario);

            if (permissao == null)
            {
                IsTelaVisibility = Visibility.Hidden;
                MensagemInformativa("Usuário sem permissão para acessar este cadastro.");
                return false;
            }

            if (!permissao.Exclui && !permissao.Insere && !permissao.Pesquisa)
            {
                IsTelaVisibility = Visibility.Hidden;
                MensagemInformativa("Usuário sem permissão para acessar este cadastro.");
                return false;
            }
            return true;
        }

        
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
                OnFechar();
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
            
        }



        #endregion

        #region Propriedades

        public virtual bool IsPesquisar
        {
            get { return _isPesquisar; }
            set
            {
                _isPesquisar = value; 
                OnPropertyChanged("IsPesquisar");
            }
        }

        public virtual bool IsExcluir
        {
            get { return _isExcluir; }
            set
            {
                _isExcluir = value;
                OnPropertyChanged("IsExcluir");
            }
        }

        public virtual bool IsSalvar
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
