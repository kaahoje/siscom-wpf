using System;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Windows;
using System.Windows.Input;
using Erp.Annotations;
using Erp.Business.Entity.Contabil.Pessoa.SubClass.PessoaFisica;
using Util;
using Util.Seguranca;
using Util.Wpf;

namespace Erp.Model.Forms
{
    public class LoginModelForm : ModelFormBase, INotifyPropertyChanged
    {
        private string _usuario;
        private string _senha;

        public string Usuario
        {
            get { return _usuario; }
            set
            {
                if (value == _usuario) return;
                _usuario = value;
                OnPropertyChanged();
            }
        }

        public string Senha
        {
            get { return _senha; }
            set
            {
                if (value == _senha) return;
                _senha = value;
                OnPropertyChanged();
            }
        }
        public ICommand CmdLogin { get{return new RelayCommandBase(x=>Login());} }

        private void Login()
        {
            try
            {

                var pessoa = PessoaFisicaRepository.GetByLogin(Usuario);
                var senha = Criptografia.CriptografarSenha(Senha);
                if (pessoa != null && senha.Equals(pessoa.Senha))
                {
                    App.Usuario = pessoa;
                    IsTelaVisibility = Visibility.Hidden;
                    return;
                }
                MensagemInformativa("Usuário ou senha inválido.");

            }
            catch (Exception ex)
            {
                CustomMessageBox.MensagemInformativa("Erro ao entrar:\n" + ex.Message);
            }
        }

       
    }
}
