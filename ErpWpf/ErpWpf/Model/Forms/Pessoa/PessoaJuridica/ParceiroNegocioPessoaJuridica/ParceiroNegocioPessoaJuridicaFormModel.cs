using System;
using AutoMapper;
using Erp.Business;
using Erp.Business.Entity.Contabil.Pessoa.SubClass.PessoaJuridica.SubClass.ParceiroNegocio;
using Erp.Business.Enum;
using Erp.Business.Validation;
using Erp.Model.Grids.Pessoa.PessoaJuridica.ParceiroNegocioPessoaJuridica;
using Erp.View.Forms.Pessoa.PessoaJuridica.ParceiroNegocioPessoaJuridica;

namespace Erp.Model.Forms.Pessoa.PessoaJuridica.ParceiroNegocioPessoaJuridica
{
    public class ParceiroNegocioPessoaJuridicaFormModel : PessoaJuridicaFormModel, IPessoa
    {
        public ParceiroNegocioPessoaJuridicaFormModel()
        {
            Entity = new Business.Entity.Contabil.Pessoa.SubClass.PessoaJuridica.SubClass.ParceiroNegocio.ParceiroNegocioPessoaJuridica();
            ModelSelect = new ParceiroNegocioPessoaJuridicaSelectModel();
            IsSalvar = true;
        }

        public override Business.Entity.Contabil.Pessoa.Pessoa Entity
        {
            get { return base.Entity; }
            set
            {
                if (Equals(value, base.Entity)) return;
                base.Entity = value;
                OnPropertyChanged("EntityPessoaJuridica");
                OnPropertyChanged("EntityParceiroNegocioPessoaJuridica");
            }
        }

        public
            Business.Entity.Contabil.Pessoa.SubClass.PessoaJuridica.SubClass.ParceiroNegocio.ParceiroNegocioPessoaJuridica EntityParceiroNegocioPessoaJuridica
        {
            get { return Entity as Business.Entity.Contabil.Pessoa.SubClass.PessoaJuridica.SubClass.ParceiroNegocio.ParceiroNegocioPessoaJuridica; }
            set
            {
                Entity = value; 
                OnPropertyChanged();
                OnPropertyChanged("Entity");
                OnPropertyChanged("EntityPessoaJuridica");
                
            }
        }

        public override void Excluir()
        {
            try
            {
                if (ConfirmDelete())
                {
                    EntityParceiroNegocioPessoaJuridica.Cnpj =
                        Validation.GetOnlyNumber(EntityParceiroNegocioPessoaJuridica.Cnpj);
                    Entity.Status = Status.Excluido;
                    ParceiroNegocioPessoaJuridicaRepository.Save(EntityParceiroNegocioPessoaJuridica);
                    EntityParceiroNegocioPessoaJuridica = new Business.Entity.Contabil.Pessoa.SubClass.PessoaJuridica.SubClass.ParceiroNegocio.ParceiroNegocioPessoaJuridica();
                    OperacaoConcluida();
                }
            }
            catch (Exception ex)
            {
                MensagemErroBancoDados(ex.Message);
                Utils.GerarLog(ex);
            }
        }

        public override void Salvar()
        {
            try
            {
                Mapper.CreateMap(typeof(ParceiroNegocioPessoaJuridicaFormModel),
                        typeof(
                            Business.Entity.Contabil.Pessoa.SubClass.PessoaJuridica.SubClass.ParceiroNegocio.ParceiroNegocioPessoaJuridica));
                Mapper.Map(this, Entity);
                if (IsValid(Entity))
                {
                    EntityParceiroNegocioPessoaJuridica.Cnpj =
                        Validation.GetOnlyNumber(EntityParceiroNegocioPessoaJuridica.Cnpj);
                    ParceiroNegocioPessoaJuridicaRepository.Save(EntityParceiroNegocioPessoaJuridica);
                    EntityParceiroNegocioPessoaJuridica = new Business.Entity.Contabil.Pessoa.SubClass.PessoaJuridica.SubClass.ParceiroNegocio.ParceiroNegocioPessoaJuridica();
                    base.Salvar();
                }
            }
            catch (Exception ex)
            {
                MensagemErroBancoDados(ex.Message);
                Utils.GerarLog(ex);
            }
        }

        public override void IrParaPessoaJuridica()
        {
            new ParceiroNegocioPessoaJuridicaFormView().ShowDialog();
        }
    }
}
