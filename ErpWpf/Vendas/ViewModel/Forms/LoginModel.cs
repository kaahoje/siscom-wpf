using System.Windows;
using System.Windows.Input;
using Erp.Business.Entity.Contabil.Pessoa.SubClass.PessoaFisica;
using Util.Wpf;

namespace Vendas.ViewModel.Forms
{
    public class LoginModel : FormModelGeneric<PessoaFisica>
    {
        private ICommand _cmdLogin;
        private bool _usuarioLogado;
        private Visibility _telaLoginVisibility;

        public LoginModel()
        {
            Entity = new PessoaFisica();
        }

        public Visibility TelaLoginVisibility
        {
            get { return _telaLoginVisibility; }
            set
            {
                _telaLoginVisibility = value;
                OnPropertyChanged("TelaLoginVisibility");
            }
        }

        public bool UsuarioLogado
        {
            get { return _usuarioLogado; }
            set
            {
                _usuarioLogado = value;
                if (value)
                {
                    TelaLoginVisibility = Visibility.Hidden;
                }
                else
                {
                    TelaLoginVisibility= Visibility.Visible;
                }
                OnPropertyChanged("UsuarioLogado");
            }
        }

        public ICommand CmdLogin
        {
            get { return _cmdLogin ?? (_cmdLogin = new RelayCommandBase(o => Login())); }
            set { _cmdLogin = value; }
        }

        private void Login()
        {
            if (PessoaFisicaRepository.AutenticarUsuario(Entity.Login, Entity.Senha))
            {
                App.Usuario = PessoaFisicaRepository.GetByLogin(Entity.Login);
                UsuarioLogado = true;
            }
            
        }

        public void Logout()
        {
            App.Usuario = null;
            UsuarioLogado = false;
        }
    }
}
