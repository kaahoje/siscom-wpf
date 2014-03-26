using System;
using Erp.Business.Entity.Contabil.Pessoa.SubClass.PessoaJuridica.SubClass.ParceiroNegocio.ClassesRelacionadas;
using Erp.Business.Enum;
using Erp.Model.Grids.CustoFixo.PessoaJuridica.ParceiroNegocioPessoaJuridica;
using Erp.Model.LargeDataModel;

namespace Erp.Model.Forms.CustoFixo.PessoaJuridica.ParceiroNegocioPessoaJuridica
{
    public class CustoFixoParceiroNegocioPessoaJuridicaFormModel : ModelFormGeneric<CustoFixoParceiroNegocioPessoaJuridica>
    {
        public CustoFixoParceiroNegocioPessoaJuridicaFormModel()
        {
            Entity = new CustoFixoParceiroNegocioPessoaJuridica();
            ModelSelect = new  CustoFixoParceiroNegocioPessoaJuridicaSelectModel();
        }

        public override void Excluir()
        {
            try
            {
                if (IsValid(Entity))
                {
                    Entity.Status = Status.Excluido;
                    CustoFixoParceiroNegocioPessoaJuridicaRepository.Save(Entity);
                    Entity = new CustoFixoParceiroNegocioPessoaJuridica();
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
                    CustoFixoParceiroNegocioPessoaJuridicaRepository.Save(Entity);
                    Entity = new CustoFixoParceiroNegocioPessoaJuridica();
                    base.Salvar();
                }
            }
            catch (Exception ex)
            {
                MensagemErroBancoDados(ex.Message);
            }
        }

        private TipoTituloLargeDataModel _tipoTituloLargeData;

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
