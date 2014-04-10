using System;
using System.Windows.Input;
using Erp.Business;
using Erp.Business.Entity.Contabil.Pessoa.SubClass.PessoaFisica.SubClass.ParceiroNegocio.ClassesRelacionadas;
using Erp.Business.Enum;
using Erp.Model.Grids.Titulo.PessoaFisica.ParceiroNegocioPessoaFisica;
using Erp.Model.LargeDataModel;
using Util.Wpf;

namespace Erp.Model.Forms.Titulo.PessoaFisica.ParceiroNegocioPessoaFisica
{
    public class TituloParceiroNegocioPessoaFisicaFormModel : ModelFormGeneric<TituloParceiroNegocioPessoaFisica>
    {
        public TituloParceiroNegocioPessoaFisicaFormModel()
        {
            Entity = new TituloParceiroNegocioPessoaFisica();
            ModelSelect = new TituloParceiroNegocioPessoaFisicaSelecModel();
        }
        private ParceiroNegocioPessoaFisicaLargeDataModel _parceiroNegocioPessoaFisicaLargeData;
        public ParceiroNegocioPessoaFisicaLargeDataModel ParceiroNegocioPessoaFisicaLargeData
        {
            get { return _parceiroNegocioPessoaFisicaLargeData ?? (_parceiroNegocioPessoaFisicaLargeData = new ParceiroNegocioPessoaFisicaLargeDataModel()); }
            set
            {
                if (Equals(value, _parceiroNegocioPessoaFisicaLargeData)) return;
                _parceiroNegocioPessoaFisicaLargeData = value;
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
                    TituloParceiroNegocioPessoaFisicaRepository.Save(Entity);
                    Entity = new TituloParceiroNegocioPessoaFisica();
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
                    TituloParceiroNegocioPessoaFisicaRepository.Save(Entity);
                    Entity = new TituloParceiroNegocioPessoaFisica();
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

        public KeyGesture KeyBaixarTitutlo { get { return new KeyGesture(Key.B, ModifierKeys.Control); } }

        public ICommand CmdBaixarTitulo { get { return new RelayCommandBase(x => BaixarTitulo()); } }

        private void BaixarTitulo()
        {
            try
            {
                
                if (IsValid(Entity))
                {
                    if (Entity.Id == 0)
                    {
                        TituloParceiroNegocioPessoaFisicaRepository.Save(Entity);
                    }
                    TituloParceiroNegocioPessoaFisicaRepository.BaixarTitulo(Entity);
                    MensagemInformativa("Título baixado com sucesso.");
                }
            }
            catch (Exception ex)
            {
                MensagemErroBancoDados(ex.Message);
            }
        }

        public override TituloParceiroNegocioPessoaFisica Entity
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
