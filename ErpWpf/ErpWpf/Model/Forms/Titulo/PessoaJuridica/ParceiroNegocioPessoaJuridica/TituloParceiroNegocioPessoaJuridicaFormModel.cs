using System;
using System.Windows.Input;
using DevExpress.XtraPrinting.Native;
using Erp.Business;
using Erp.Business.Entity.Contabil.Pessoa.SubClass.PessoaFisica.SubClass.ParceiroNegocio.ClassesRelacionadas;
using Erp.Business.Entity.Contabil.Pessoa.SubClass.PessoaJuridica.SubClass.ParceiroNegocio.ClassesRelacionadas;
using Erp.Business.Enum;
using Erp.Model.Grids.Titulo.PessoaJuridica.ParceiroNegocioPessoaJuridica;
using Erp.Model.LargeDataModel;
using Util.Wpf;

namespace Erp.Model.Forms.Titulo.PessoaJuridica.ParceiroNegocioPessoaJuridica
{
    public class TituloParceiroNegocioPessoaJuridicaFormModel : ModelFormGeneric<TituloParceiroNegocioPessoaJuridica>
    {
        
        public TituloParceiroNegocioPessoaJuridicaFormModel()
        {
            Entity = new TituloParceiroNegocioPessoaJuridica();
            ModelSelect = new TituloParceiroNegocioPessoaJuridicaSelectModel();
        }

        private ParceiroNegocioPessoaJuridicaLargeDataModel _parceiroNegocioPessoaJuridicaLargeData;
        public ParceiroNegocioPessoaJuridicaLargeDataModel ParceiroNegocioPessoaJuridicaLargeData
        {
            get { return _parceiroNegocioPessoaJuridicaLargeData ?? (_parceiroNegocioPessoaJuridicaLargeData = new ParceiroNegocioPessoaJuridicaLargeDataModel()); }
            set
            {
                if (Equals(value, _parceiroNegocioPessoaJuridicaLargeData)) return;
                _parceiroNegocioPessoaJuridicaLargeData = value;
                OnPropertyChanged();
            }
        }

        public override void Excluir()
        {
            try
            {
                if (ConfirmDelete())
                {
                    Entity.Status = Status.Excluido;
                    TituloParceiroNegocioPessoaJuridicaRepository.Save(Entity);
                    Entity = new TituloParceiroNegocioPessoaJuridica();
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
                    TituloParceiroNegocioPessoaJuridicaRepository.Save(Entity);
                    Entity = new TituloParceiroNegocioPessoaJuridica();
                    base.Salvar();
                }
            }
            catch (Exception ex)
            {
                MensagemErroBancoDados(ex.Message);
                Utils.GerarLog(ex);
            }
        }
        private TipoTituloLargeDataModel _tipoTituloLargeData;
        
        public TipoTituloLargeDataModel TipoTituloLargeData
        {
            get { return _tipoTituloLargeData ?? (_tipoTituloLargeData = new TipoTituloLargeDataModel()); }
            set
            {
                if (Equals(value, _tipoTituloLargeData)) return;
                _tipoTituloLargeData = value;
                OnPropertyChanged();
            }
        }

        public KeyGesture KeyBaixarTitutlo { get { return new KeyGesture(Key.B, ModifierKeys.Control);} }

        public ICommand CmdBaixarTitulo { get { return new RelayCommandBase(x => BaixarTitulo()); } }

        public override TituloParceiroNegocioPessoaJuridica Entity
        {
            get { return base.Entity; }
            set
            {
                if (Equals(value, base.Entity)) return;
                base.Entity = value;
                OnPropertyChanged();
                OnPropertyChanged("IsBaixaTitulo");
            }
        }

        private void BaixarTitulo()
        {
            try
            {
                if (IsValid(Entity))
                {
                    if (Entity.Id == 0)
                    {
                        TituloParceiroNegocioPessoaJuridicaRepository.Save(Entity);
                    }
                    TituloParceiroNegocioPessoaJuridicaRepository.BaixarTitulo(Entity);
                    MensagemInformativa("Título baixado com sucesso.");
                }
            }
            catch (Exception ex)
            {
                MensagemErroBancoDados(ex.Message);
            }
        }

        
        public bool IsBaixaTitulo
        {
            get
            {
                return GetPermissao().Edita;
                
            }
            set
            {
                OnPropertyChanged();
            }
        }

    }
}
