using System;
using Erp.Business.Entity.Contabil.Pessoa.SubClass.PessoaJuridica.SubClass.ParceiroNegocio;
using Erp.Business.Enum;
using Erp.Model.Grids.Pessoa.PessoaJuridica.ParceiroNegocioPessoaJuridica;

namespace Erp.Model.Forms.Pessoa.PessoaJuridica.ParceiroNegocioPessoaJuridica
{
    public class ParceiroNegocioPessoaJuridicaFormModel : PessoaJuridicaFormModel, IPessoa
    {
        

        public ParceiroNegocioPessoaJuridicaFormModel()
        {
            Entity = new Business.Entity.Contabil.Pessoa.SubClass.PessoaJuridica.SubClass.ParceiroNegocio.ParceiroNegocioPessoaJuridica();
            ModelSelect = new ParceiroNegocioPessoaJuridicaSelectModel();
        }

        public
            Business.Entity.Contabil.Pessoa.SubClass.PessoaJuridica.SubClass.ParceiroNegocio.
                ParceiroNegocioPessoaJuridica EntityParceiroNegocioPessoaJuridica
        {
            get { return (Business.Entity.Contabil.Pessoa.SubClass.PessoaJuridica.SubClass.ParceiroNegocio.ParceiroNegocioPessoaJuridica) Entity; }
            set { Entity = value; }
        }

        public override void Excluir()
        {
            try
            {
                if (ConfirmDelete())
                {
                    Entity.Status = Status.Excluido;
                    ParceiroNegocioPessoaJuridicaRepository.Save(EntityParceiroNegocioPessoaJuridica);
                    EntityParceiroNegocioPessoaJuridica = new Business.Entity.Contabil.Pessoa.SubClass.PessoaJuridica.SubClass.ParceiroNegocio.ParceiroNegocioPessoaJuridica();
                    base.Excluir();
                }
            }
            catch (Exception ex)
            {
                MensagemErroBancoDados(ex.Message);
            }
        }

        public override void Salvar()
        {
            try
            {
                if (IsValid(Entity))
                {
                    ParceiroNegocioPessoaJuridicaRepository.Save(EntityParceiroNegocioPessoaJuridica);
                    EntityParceiroNegocioPessoaJuridica = new Business.Entity.Contabil.Pessoa.SubClass.PessoaJuridica.SubClass.ParceiroNegocio.ParceiroNegocioPessoaJuridica();
                    base.Salvar();
                }
            }
            catch (Exception ex)
            {
                MensagemErroBancoDados(ex.Message);
            }
        }
        
    }
}
