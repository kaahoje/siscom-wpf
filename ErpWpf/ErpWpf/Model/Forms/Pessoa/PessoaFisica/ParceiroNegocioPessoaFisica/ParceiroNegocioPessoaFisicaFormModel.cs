using System;
using System.Collections.ObjectModel;
using System.Windows.Input;
using AutoMapper;
using DevExpress.Xpf.Ribbon.Customization;
using Erp.Business;
using Erp.Business.Dicionary;
using Erp.Business.Entity.Contabil.Pessoa.SubClass.PessoaFisica.ClassesRelacionadas;
using Erp.Business.Entity.Contabil.Pessoa.SubClass.PessoaFisica.SubClass.ParceiroNegocio;
using Erp.Business.Enum;
using Erp.Business.Validation;
using Erp.Model.Grids.Pessoa.PessoaFisica.ParceiroNegocioPessoaFisica;
using Erp.Model.LargeDataModel;
using Erp.View.Forms.Pessoa.PessoaFisica.ParceiroNegocioPessoaFisica;
using Util.Wpf;

namespace Erp.Model.Forms.Pessoa.PessoaFisica.ParceiroNegocioPessoaFisica
{
   public  class ParceiroNegocioPessoaFisicaFormModel : PessoaFisicaFormModel
   {
       private ObservableCollection<PermissaoFormularioPessoaFisica> _permissaoFormulario;
       private ObservableCollection<PermissaoRelatorioPessoaFisica> _permissaoRelatorio;
       private PessoaFisicaLargeDataModel _pessoaFisicaLargeData;
       private PermissaoFormularioPessoaFisica _currentPermissaoFormulario;
       private PermissaoRelatorioPessoaFisica _currentPermissaoRelatorio;
       private FormularioDictionary _formularioDictionary;
       private RelatorioDictionary _relatorioDictionary;
       

       public ParceiroNegocioPessoaFisicaFormModel()
       {
           EntityParceiroNegocioPessoaFisica = new Business.Entity.Contabil.Pessoa.SubClass.PessoaFisica.SubClass.ParceiroNegocio.ParceiroNegocioPessoaFisica();
           ModelSelect = new ParceiroNegocioPessoaFisicaSelectModel();
           IsSalvar = true; 
       }
       
       public Business.Entity.Contabil.Pessoa.SubClass.PessoaFisica.SubClass.ParceiroNegocio.ParceiroNegocioPessoaFisica
           EntityParceiroNegocioPessoaFisica
       {
           get { return Entity as Business.Entity.Contabil.Pessoa.SubClass.PessoaFisica.SubClass.ParceiroNegocio.ParceiroNegocioPessoaFisica; }
           set
           {
               Entity = value; 
               OnPropertyChanged();
               OnPropertyChanged("EntityPessoaFisica");
           }
       }

       public override Business.Entity.Contabil.Pessoa.Pessoa Entity
       {
           get { return base.Entity; }
           set
           {
               if (Equals(value, base.Entity)) return;
               base.Entity = value;
               
               PermissaoFormulario.Clear();
               PermissaoRelatorio.Clear();

               if (EntityParceiroNegocioPessoaFisica != null)
               {
                   PermissaoFormulario.AddRange(EntityPessoaFisica.PermissaoFormulario);
                   PermissaoRelatorio.AddRange(EntityPessoaFisica.PermissaoRelatorio);
               }

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
                   EntityParceiroNegocioPessoaFisica.Cpf =
                       Validation.GetOnlyNumber(EntityParceiroNegocioPessoaFisica.Cpf);
                   ParceiroNegocioPessoaFisicaRepository.Save(EntityParceiroNegocioPessoaFisica);
                   EntityParceiroNegocioPessoaFisica = new Business.Entity.Contabil.Pessoa.SubClass.PessoaFisica.SubClass.ParceiroNegocio.ParceiroNegocioPessoaFisica();
                   base.Excluir();
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
               if (IsValid(Entity))
               {
                   Mapper.CreateMap(typeof (ParceiroNegocioPessoaFisicaFormModel),
                       typeof (
                           Business.Entity.Contabil.Pessoa.SubClass.PessoaFisica.SubClass.ParceiroNegocio.ParceiroNegocioPessoaFisica));
                   Mapper.Map(this, Entity);
                   EntityParceiroNegocioPessoaFisica.Cpf =
                       Validation.GetOnlyNumber(EntityParceiroNegocioPessoaFisica.Cpf);
                   ParceiroNegocioPessoaFisicaRepository.Save(EntityParceiroNegocioPessoaFisica);
                   EntityParceiroNegocioPessoaFisica = new Business.Entity.Contabil.Pessoa.SubClass.PessoaFisica.SubClass.ParceiroNegocio.ParceiroNegocioPessoaFisica();
                   base.Salvar();
               }
           }
           catch (Exception ex)
           {
               MensagemErroBancoDados(ex.Message);
               Utils.GerarLog(ex);
           }
       }


       public override void IrParaPessoaFisica()
       {
           new ParceiroNegocioPessoaFisicaFormView().ShowDialog();
       }

       public PessoaFisicaLargeDataModel PessoaFisicaLargeData
       {
           get { return _pessoaFisicaLargeData ?? (_pessoaFisicaLargeData = new PessoaFisicaLargeDataModel()); }
           set
           {
               if (Equals(value, _pessoaFisicaLargeData)) return;
               _pessoaFisicaLargeData = value;
               OnPropertyChanged();
           }
       }

       public PermissaoFormularioPessoaFisica CurrentPermissaoFormulario
       {
           get { return _currentPermissaoFormulario; }
           set
           {
               if (Equals(value, _currentPermissaoFormulario)) return;
               _currentPermissaoFormulario = value;
               OnPropertyChanged();
           }
       }

       public PermissaoRelatorioPessoaFisica CurrentPermissaoRelatorio
       {
           get { return _currentPermissaoRelatorio; }
           set
           {
               if (Equals(value, _currentPermissaoRelatorio)) return;
               _currentPermissaoRelatorio = value;
               OnPropertyChanged();
           }
       }

       public ICommand CmdAddPermissaoFormulario { get { return new RelayCommandBase(x => AddPermissaoFormulario()); } }

       void AddPermissaoFormulario()
       {
           PermissaoFormulario.Add(new PermissaoFormularioPessoaFisica());
       }
       public ICommand CmdRemovePermissaoFormulario { get { return new RelayCommandBase(x => RemovePermissaoFormulario()); } }

       void RemovePermissaoFormulario()
       {
           if (CurrentPermissaoFormulario != null)
           {
               PermissaoFormulario.Remove(CurrentPermissaoFormulario);
           }
       }

       public ICommand CmdAddPermissaoRelatorio { get { return new RelayCommandBase(x => AddPermissaoRelatorio()); } }

       void AddPermissaoRelatorio()
       {
           PermissaoRelatorio.Add(new PermissaoRelatorioPessoaFisica());
       }

       public ICommand CmdRemovePermissaoRelatorio { get { return new RelayCommandBase(x => RemovePermissaoRelatorio()); } }

       void RemovePermissaoRelatorio()
       {
           if (CurrentPermissaoRelatorio != null)
           {
               PermissaoRelatorio.Remove(CurrentPermissaoRelatorio);
           }
       }

       public FormularioDictionary FormularioDictionary
       {
           get { return _formularioDictionary ?? (_formularioDictionary = new FormularioDictionary()); }
           set
           {
               if (Equals(value, _formularioDictionary)) return;
               _formularioDictionary = value;
               OnPropertyChanged();
           }
       }

       public RelatorioDictionary RelatorioDictionary
       {
           get { return _relatorioDictionary ?? (_relatorioDictionary = new RelatorioDictionary()); }
           set
           {
               if (Equals(value, _relatorioDictionary)) return;
               _relatorioDictionary = value;
               OnPropertyChanged();
           }
       }

       public ObservableCollection<PermissaoFormularioPessoaFisica> PermissaoFormulario
       {
           get { return _permissaoFormulario ?? (_permissaoFormulario = new ObservableCollection<PermissaoFormularioPessoaFisica>()); }
           set
           {
               if (Equals(value, _permissaoFormulario)) return;
               _permissaoFormulario = value;
               OnPropertyChanged();
           }
       }

       public ObservableCollection<PermissaoRelatorioPessoaFisica> PermissaoRelatorio
       {
           get { return _permissaoRelatorio ?? (_permissaoRelatorio = new ObservableCollection<PermissaoRelatorioPessoaFisica>()); }
           set
           {
               if (Equals(value, _permissaoRelatorio)) return;
               _permissaoRelatorio = value;
               OnPropertyChanged();
           }
       }
   }
}
