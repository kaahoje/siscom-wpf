using System;
using System.Windows.Input;
using Erp.Business.Entity.Contabil.Pessoa.SubClass.PessoaFisica;
using Erp.Business.Enum;
using Erp.Model.Grids.Pessoa.PessoaFisica;
using Erp.View.Forms.Pessoa.PessoaFisica;
using Util.Wpf;

namespace Erp.Model.Forms.Pessoa.PessoaFisica
{
    public class PessoaFisicaFormModel : PessoaFormModel,IPessoa
    {
        public virtual Business.Entity.Contabil.Pessoa.SubClass.PessoaFisica.PessoaFisica EntityPessoaFisica
        {
            get { return (Business.Entity.Contabil.Pessoa.SubClass.PessoaFisica.PessoaFisica) Entity; }
            set
            {
                Entity = value; 
                OnPropertyChanged("EntityPessoaFisica");
            }
        }

        public PessoaFisicaFormModel()
        {
            Entity = new Business.Entity.Contabil.Pessoa.SubClass.PessoaFisica.PessoaFisica();
            ModelSelect = new PessoaFisicaSelectModel();
            IsSalvar = false;
        }


        public override void Excluir()
        {
            try
            {
                if (ConfirmDelete())
                {
                    Entity.Status = Status.Excluido;
                    PessoaFisicaRepository.Save(EntityPessoaFisica);
                    EntityPessoaFisica = new Business.Entity.Contabil.Pessoa.SubClass.PessoaFisica.PessoaFisica();
                    base.Excluir();
                }
            }
            catch (Exception ex)
            {
                MensagemErroBancoDados(ex.Message);
            }
        }

        #region Commands

        public ICommand CmdIrParaPessoaFisica { get { return new RelayCommandBase(x => IrParaPessoaFisica()); } }



        #endregion

        #region Operations

        public virtual void  IrParaPessoaFisica()
        {
            new PessoaFisicaFormView().ShowDialog();
        }

        #endregion
        
    }
}
