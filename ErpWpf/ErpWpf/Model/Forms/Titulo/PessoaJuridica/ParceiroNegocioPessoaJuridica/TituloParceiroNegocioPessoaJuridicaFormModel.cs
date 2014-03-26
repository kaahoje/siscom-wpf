using System;
using DevExpress.XtraPrinting.Native;
using Erp.Business.Entity.Contabil.Pessoa.SubClass.PessoaJuridica.SubClass.ParceiroNegocio.ClassesRelacionadas;
using Erp.Business.Enum;
using Erp.Model.Grids.Titulo.PessoaJuridica.ParceiroNegocioPessoaJuridica;
using Erp.Model.LargeDataModel;

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
    }
}
