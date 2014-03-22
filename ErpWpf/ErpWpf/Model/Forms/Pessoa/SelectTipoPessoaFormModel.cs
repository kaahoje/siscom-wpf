using System.Windows.Input;
using Erp.View.Forms.Pessoa;
using Erp.View.Forms.Pessoa.PessoaFisica;
using Erp.View.Forms.Pessoa.PessoaFisica.ParceiroNegocioPessoaFisica;
using Erp.View.Forms.Pessoa.PessoaJuridica.ParceiroNegocioPessoaJuridica;
using Util.Wpf;

namespace Erp.Model.Forms.Pessoa
{
    public class SelectTipoPessoaFormModel : ModelBase
    {
        #region Commands

        public ICommand CmdAbrirParceiroNegocioPessoaFisica { get { return new RelayCommandBase(x => AbrirParceiroNegocioPessoaFisica()); } }

        public ICommand CmdAbrirParceiroNegocioPessoaJuridica { get { return new RelayCommandBase(x => AbrirParceiroNegocioPessoaJuridica()); } }

        public ICommand CmdAbrirPessoaFisica { get { return new RelayCommandBase(x => AbrirPessoaFisica()); } }

        public ICommand CmdAbrirPessoaJuridica { get { return new RelayCommandBase(x => AbrirPessoaJuridica()); } }

        #endregion
        #region Operacoes

        public void AbrirPessoaFisica()
        {
            new PessoaFisicaFormView().ShowDialog();
        }

        public void AbrirPessoaJuridica()
        {

        }

        private void AbrirParceiroNegocioPessoaJuridica()
        {
            new ParceiroNegocioPessoaJuridicaFormView().ShowDialog();
        }

        public void AbrirParceiroNegocioPessoaFisica()
        {
            new ParceiroNegocioPessoaFisicaFormView().ShowDialog();
        }

        #endregion
    }
}
