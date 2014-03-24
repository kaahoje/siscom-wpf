using System;
using AutoMapper;
using Erp.Business.Entity.Contabil.Pessoa.SubClass.PessoaFisica.SubClass.ParceiroNegocio;
using Erp.Business.Enum;
using Erp.Model.Grids.Pessoa.PessoaFisica.ParceiroNegocioPessoaFisica;
using Erp.View.Forms.Pessoa.PessoaFisica.ParceiroNegocioPessoaFisica;

namespace Erp.Model.Forms.Pessoa.PessoaFisica.ParceiroNegocioPessoaFisica
{
   public  class ParceiroNegocioPessoaFisicaFormModel : PessoaFisicaFormModel,IPessoa
   {
       private Business.Entity.Contabil.Pessoa.Pessoa _entity1;

       public ParceiroNegocioPessoaFisicaFormModel()
       {
           Entity = new Business.Entity.Contabil.Pessoa.SubClass.PessoaFisica.SubClass.ParceiroNegocio.ParceiroNegocioPessoaFisica();
           ModelSelect = new ParceiroNegocioPessoaFisicaSelectModel();
           IsSalvar = true; 
       }
       
       public Business.Entity.Contabil.Pessoa.SubClass.PessoaFisica.SubClass.ParceiroNegocio.ParceiroNegocioPessoaFisica
           EntityParceiroNegocioPessoaFisica
       {
           get { return (Business.Entity.Contabil.Pessoa.SubClass.PessoaFisica.SubClass.ParceiroNegocio.ParceiroNegocioPessoaFisica) Entity; }
           set { Entity = value; }
       }

       public override Business.Entity.Contabil.Pessoa.Pessoa Entity
       {
           get { return _entity1; }
           set
           {
               if (Equals(value, _entity1)) return;
               _entity1 = value;
               OnPropertyChanged();
               OnPropertyChanged("EntityPessoaFisica");
               OnPropertyChanged("EntityParceiroNegocioPessoaFisica");
           }
       }

       public override void Excluir()
       {
           try
           {
               if (ConfirmDelete())
               {
                   Entity.Status = Status.Excluido;
                   ParceiroNegocioPessoaFisicaRepository.Save(EntityParceiroNegocioPessoaFisica);
                   EntityParceiroNegocioPessoaFisica = new Business.Entity.Contabil.Pessoa.SubClass.PessoaFisica.SubClass.ParceiroNegocio.ParceiroNegocioPessoaFisica();
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
                   Mapper.CreateMap(typeof (ParceiroNegocioPessoaFisicaFormModel),
                       typeof (
                           Business.Entity.Contabil.Pessoa.SubClass.PessoaFisica.SubClass.ParceiroNegocio.
                               ParceiroNegocioPessoaFisica));
                   Mapper.Map(this, Entity);
                   ParceiroNegocioPessoaFisicaRepository.Save(EntityParceiroNegocioPessoaFisica);
                   EntityParceiroNegocioPessoaFisica = new Business.Entity.Contabil.Pessoa.SubClass.PessoaFisica.SubClass.ParceiroNegocio.ParceiroNegocioPessoaFisica();
                   base.Salvar();
               }
           }
           catch (Exception ex)
           {
               MensagemErroBancoDados(ex.Message);
           }
       }


       public override void IrParaPessoaFisica()
       {
           new ParceiroNegocioPessoaFisicaFormView().ShowDialog();
       }
   }
}
