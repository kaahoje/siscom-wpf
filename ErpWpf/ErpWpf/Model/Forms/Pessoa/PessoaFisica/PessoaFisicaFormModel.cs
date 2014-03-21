using System;
using Erp.Business.Entity.Contabil.Pessoa.SubClass.PessoaFisica;
using Erp.Business.Enum;
using Erp.Model.Grids.Pessoa.PessoaFisica;

namespace Erp.Model.Forms.Pessoa.PessoaFisica
{
    public class PessoaFisicaFormModel : PessoaFormModel,IPessoa
    {
        public Business.Entity.Contabil.Pessoa.SubClass.PessoaFisica.PessoaFisica EntityPessoaFisica
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

        public override void Salvar()
        {
            MensagemErroBancoDados("Não é possível editar ou alterar uma pessoa física.");
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

        
    }
}
