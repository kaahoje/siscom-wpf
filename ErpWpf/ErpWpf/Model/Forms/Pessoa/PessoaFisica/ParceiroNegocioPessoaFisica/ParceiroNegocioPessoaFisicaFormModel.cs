using System;
using System.Windows.Input;
using Erp.Business.Entity.Contabil.Pessoa.ClassesRelacionadas;
using Erp.Business.Entity.Contabil.Pessoa.ClassesRelacionadas.Endereco;
using Erp.Business.Entity.Contabil.Pessoa.SubClass.PessoaFisica.SubClass.ParceiroNegocio;
using Erp.Business.Enum;
using Erp.Model.Grids;
using Erp.Model.Grids.Pessoa.PessoaFisica.ParceiroNegocioPessoaFisica;
using FluentNHibernate.Conventions;
using Util.Wpf;

namespace Erp.Model.Forms.Pessoa.PessoaFisica.ParceiroNegocioPessoaFisica
{
   public  class ParceiroNegocioPessoaFisicaFormModel : PessoaFisicaFormModel,IPessoa
   {
       public ParceiroNegocioPessoaFisicaFormModel()
       {
           Entity = new Business.Entity.Contabil.Pessoa.SubClass.PessoaFisica.SubClass.ParceiroNegocio.ParceiroNegocioPessoaFisica();
           ModelSelect = new ParceiroNegocioPessoaFisicaSelectModel();
       }

       public Business.Entity.Contabil.Pessoa.SubClass.PessoaFisica.SubClass.ParceiroNegocio.ParceiroNegocioPessoaFisica
           EntityParceiroNegocioPessoaFisica
       {
           get { return (Business.Entity.Contabil.Pessoa.SubClass.PessoaFisica.SubClass.ParceiroNegocio.ParceiroNegocioPessoaFisica) Entity; }
           set { Entity = value; }
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
       
   }
}
