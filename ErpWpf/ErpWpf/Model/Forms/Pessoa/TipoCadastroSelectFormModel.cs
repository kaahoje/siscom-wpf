using System.Windows;
using System.Windows.Input;
using Erp.Enum;
using Erp.View.Forms.CustoFixo.PessoaFisica.ParceiroNegocioPessoaFisica;
using Erp.View.Forms.CustoFixo.PessoaJuridica.ParceiroNegocioPessoaJuridica;
using Erp.View.Forms.Lancamento.PessoaFisica.ParceiroNegocioPessoaFisica;
using Erp.View.Forms.Lancamento.PessoaJuridica.ParceiroNegocioPessoaJuridica;
using Erp.View.Forms.Pessoa.PessoaFisica.ParceiroNegocioPessoaFisica;
using Erp.View.Forms.Pessoa.PessoaJuridica.ParceiroNegocioPessoaJuridica;
using Erp.View.Forms.Titulo.PessoaFisica.ParceiroNegocioPessoaFisica;
using Erp.View.Forms.Titulo.PessoaJuridica.ParceiroNegocioPessoaJuridica;
using Util.Wpf;

namespace Erp.Model.Forms.Pessoa
{
    public class TipoCadastroSelectFormModel : ModelBase
    {
        private TipoCadastroPessoa _tipoCadastroPessoa;

        public TipoCadastroPessoa TipoCadastroPessoa
        {
            get { return _tipoCadastroPessoa; }
            set
            {
                if (value == _tipoCadastroPessoa) return;
                _tipoCadastroPessoa = value;
                OnPropertyChanged();
            }
        }

        #region keys

        public KeyGesture KeyPessoaFisica { get { return new KeyGesture(Key.F, ModifierKeys.Control); } }
        public KeyGesture KeyPessoaJuridica { get { return new KeyGesture(Key.J, ModifierKeys.Control); } }
        public KeyGesture KeySair { get { return new KeyGesture(Key.Escape); } }

        #endregion
        #region Commands

        public ICommand CmdAbrirPessoaFisica { get { return new RelayCommandBase(x => AbrirPessoaFisica()); } }

        public ICommand CmdAbrirPessoaJuridica { get { return new RelayCommandBase(x => AbrirPessoaJuridica()); } }
        public ICommand CmdSair { get { return new RelayCommandBase(x => Sair()); } }


        #endregion
        #region Operacoes

        public void AbrirPessoaFisica()
        {
            switch (TipoCadastroPessoa)
            {
                case TipoCadastroPessoa.CustoFixo:
                    new CustoFixoParceiroNegocioPessoaFisicaFormView().ShowDialog();
                    break;
                case TipoCadastroPessoa.Lancamento:
                    new LancamentoParceiroNegocioPessoaFisicaFormView().ShowDialog();
                    break;
                case TipoCadastroPessoa.ParceiroNegocio:
                    new ParceiroNegocioPessoaFisicaFormView().ShowDialog();
                    break;
                case TipoCadastroPessoa.Titulo:
                    new TituloParceiroNegocioPessoaFisicaFormView().ShowDialog();
                    break;
            }

        }

        public void AbrirPessoaJuridica()
        {
            switch (TipoCadastroPessoa)
            {
                case TipoCadastroPessoa.CustoFixo:
                    new CustoFixoParceiroNegocioPessoaJuridicaFormView().ShowDialog();
                    break;
                case TipoCadastroPessoa.Lancamento:
                    new LancamentoParceiroNegocioPessoaJuridicaFormView().ShowDialog();
                    break;
                case TipoCadastroPessoa.ParceiroNegocio:
                    new ParceiroNegocioPessoaJuridicaFormView().ShowDialog();
                    break;
                case TipoCadastroPessoa.Titulo:
                    new TituloParceiroNegocioPessoaJuridicaFormView().ShowDialog();
                    break;
            }
        }


        

        public void Sair()
        {
            IsTelaVisibility = Visibility.Hidden;
        }

        #endregion
    }
}
