using System;
using System.Windows.Input;
using Erp.Business.Entity.Contabil.Pessoa.ClassesRelacionadas;
using Erp.Business.Entity.Contabil.Pessoa.ClassesRelacionadas.Endereco;
using Erp.Business.Entity.Contabil.Pessoa.SubClass.PessoaJuridica;
using Erp.Business.Enum;
using Erp.Model.Grids;
using Erp.Model.Grids.Pessoa.PessoaJuridica;
using FluentNHibernate.Conventions;
using Util.Wpf;

namespace Erp.Model.Forms.Pessoa.PessoaJuridica
{
    public class PessoaJuridicaFormModel : PessoaFormModel,IPessoa
    {
        

        public PessoaJuridicaFormModel()
        {
            Entity = new Business.Entity.Contabil.Pessoa.SubClass.PessoaJuridica.PessoaJuridica();
            ModelSelect = new PessoaJuridicaSelectModel();
            
        }

        public override void Salvar()
        {
            MensagemErroBancoDados("Não é possível salvar ou editar uma pessoa jurídica.");
        }

        public Business.Entity.Contabil.Pessoa.SubClass.PessoaJuridica.PessoaJuridica EntityPessoaJuridica
        {
            get { return (Business.Entity.Contabil.Pessoa.SubClass.PessoaJuridica.PessoaJuridica) Entity; }
            set
            {
                Entity = value; 
                OnPropertyChanged("EntityPessoaJuridica");
            }
        }

        public override void Excluir()
        {
            try
            {
                if (ConfirmDelete())
                {
                    Entity.Status = Status.Excluido;
                    PessoaJuridicaRepository.Save(EntityPessoaJuridica);
                    EntityPessoaJuridica = new Business.Entity.Contabil.Pessoa.SubClass.PessoaJuridica.PessoaJuridica();
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
