using System;
using AutoMapper;
using Erp.Business.Entity.Contabil.Pessoa.SubClass.PessoaJuridica.SubClass.ParceiroNegocio;
using Erp.Business.Enum;
using Erp.Business.Validation;
using Erp.Model.Grids.Pessoa.PessoaJuridica.ParceiroNegocioPessoaJuridica;
using Erp.View.Forms.Pessoa.PessoaJuridica.ParceiroNegocioPessoaJuridica;

namespace Erp.Model.Forms.Pessoa.PessoaJuridica.ParceiroNegocioPessoaJuridica
{
    public class ParceiroNegocioPessoaJuridicaFormModel : PessoaJuridicaFormModel, IPessoa
    {
        private Business.Entity.Contabil.Pessoa.Pessoa _entity1;


        public ParceiroNegocioPessoaJuridicaFormModel()
        {
            Entity = new Business.Entity.Contabil.Pessoa.SubClass.PessoaJuridica.SubClass.ParceiroNegocio.ParceiroNegocioPessoaJuridica();
            ModelSelect = new ParceiroNegocioPessoaJuridicaSelectModel();
            IsSalvar = true;
        }

        public override Business.Entity.Contabil.Pessoa.Pessoa Entity
        {
            get { return _entity1; }
            set
            {
                if (Equals(value, _entity1)) return;
                _entity1 = value;
                OnPropertyChanged();
                OnPropertyChanged("EntityPessoaJuridica");
                OnPropertyChanged("EntityParceiroNegocioPessoaJuridica");
            }
        }

        public
            Business.Entity.Contabil.Pessoa.SubClass.PessoaJuridica.SubClass.ParceiroNegocio.
                ParceiroNegocioPessoaJuridica EntityParceiroNegocioPessoaJuridica
        {
            get { return (Business.Entity.Contabil.Pessoa.SubClass.PessoaJuridica.SubClass.ParceiroNegocio.ParceiroNegocioPessoaJuridica) Entity; }
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
                Mapper.CreateMap(typeof(ParceiroNegocioPessoaJuridicaFormModel),
                        typeof(
                            Business.Entity.Contabil.Pessoa.SubClass.PessoaJuridica.SubClass.ParceiroNegocio.
                                ParceiroNegocioPessoaJuridica));
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
            }
        }

        public override void IrParaPessoaJuridica()
        {
            new ParceiroNegocioPessoaJuridicaFormView().ShowDialog();
        }
    }
}
