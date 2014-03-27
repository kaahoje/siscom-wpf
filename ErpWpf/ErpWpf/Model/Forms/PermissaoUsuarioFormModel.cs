using System;
using System.Collections.ObjectModel;
using System.Windows.Input;
using AutoMapper;
using DevExpress.Xpf.Ribbon.Customization;
using Erp.Business.Dicionary;
using Erp.Business.Entity.Contabil.Pessoa.SubClass.PessoaFisica;
using Erp.Business.Entity.Contabil.Pessoa.SubClass.PessoaFisica.ClassesRelacionadas;
using Erp.Model.Grids;
using Erp.Model.LargeDataModel;
using Util.Wpf;

namespace Erp.Model.Forms
{
    public class PermissaoUsuarioFormModel : ModelFormGeneric<PessoaFisica>
    {
        

        public PermissaoUsuarioFormModel()
        {
            Entity = new PessoaFisica();
            ModelSelect = new PermissaoUsuarioSelectModel();

        }

        public override bool IsExcluir
        {
            get { return false; }
            set { }
        }



        public override PessoaFisica Entity
        {
            get { return base.Entity; }
            set
            {
                base.Entity = value;
                

                OnPropertyChanged();
            }
        }

        

        public override void Salvar()
        {
            try
            {
                Mapper.CreateMap(typeof(PermissaoUsuarioFormModel), typeof(PessoaFisica));
                Mapper.Map(this, Entity);
                if (Entity.Id == 0)
                {
                    throw new Exception("Não é possível inserir uma pessoa física. Para isso vá até o cadastro de" +
                                        " parceiro de negocio pessoa física.");
                }
                if (IsValid(Entity))
                {
                    PessoaFisicaRepository.Save(Entity);
                    Entity = new PessoaFisica();
                }
            }
            catch (Exception ex)
            {
                MensagemErroBancoDados(ex.Message);
            }
        }

        public override void Excluir()
        {
            MensagemErro("Não é possível excluir uma pessoa física por este cadastro. Para isso vá até o cadastro " +
                         "de parceiro de negocio pessoa física.");
        }

        
    }
}
