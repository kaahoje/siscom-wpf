using System.Windows;
using System.Windows.Input;
using Erp.View.Forms.Pessoa.PessoaFisica;
using Erp.View.Forms.Pessoa.PessoaFisica.ParceiroNegocioPessoaFisica;
using Erp.View.Forms.Pessoa.PessoaJuridica;
using Erp.View.Forms.Pessoa.PessoaJuridica.ParceiroNegocioPessoaJuridica;
using Util.Wpf;

namespace Erp.Model.Forms.Pessoa
{
    public class ParceiroNegocioSelectFormModel : ModelBase
    {

        #region keys

        public KeyGesture KeyPessoaFisica { get { return new KeyGesture(Key.F,ModifierKeys.Control);} }
        public KeyGesture KeyPessoaJuridica { get { return new KeyGesture(Key.J,ModifierKeys.Control);} }
        public KeyGesture KeyParceiroNegocioPessoaFisica { get { return new KeyGesture(Key.F,ModifierKeys.Control);} }
        public KeyGesture KeyParceiroNegocioPessoaJuridica { get { return new KeyGesture(Key.J, ModifierKeys.Control); } }
        public KeyGesture KeySair { get { return new KeyGesture(Key.Escape); } }

        #endregion
        #region Commands

        public ICommand CmdAbrirParceiroNegocioPessoaFisica { get { return new RelayCommandBase(x => AbrirParceiroNegocioPessoaFisica()); } }

        public ICommand CmdAbrirParceiroNegocioPessoaJuridica { get { return new RelayCommandBase(x => AbrirParceiroNegocioPessoaJuridica()); } }

        public ICommand CmdAbrirPessoaFisica { get { return new RelayCommandBase(x => AbrirPessoaFisica()); } }

        public ICommand CmdAbrirPessoaJuridica { get { return new RelayCommandBase(x => AbrirPessoaJuridica()); } }
        public ICommand CmdSair { get { return new RelayCommandBase(x => Sair()); } }

        
        #endregion
        #region Operacoes

        public void AbrirPessoaFisica()
        {
            new PessoaFisicaFormView().ShowDialog();
        }

        public void AbrirPessoaJuridica()
        {
            new PessoaJuridicaFormView().ShowDialog();
        }

        private void AbrirParceiroNegocioPessoaJuridica()
        {
            new ParceiroNegocioPessoaJuridicaFormView().ShowDialog();
        }

        public void AbrirParceiroNegocioPessoaFisica()
        {
            new ParceiroNegocioPessoaFisicaFormView().ShowDialog();
        }


        public void Sair()
        {
            IsTelaVisibility = Visibility.Hidden;
        }

        #endregion
    }
}
