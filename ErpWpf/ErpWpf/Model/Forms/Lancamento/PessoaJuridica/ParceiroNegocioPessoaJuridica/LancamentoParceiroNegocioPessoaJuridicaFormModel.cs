using Erp.Business.Entity.Contabil.Pessoa.SubClass.PessoaJuridica.SubClass.ParceiroNegocio.ClassesRelacionadas;
using Erp.Model.Grids.Lancamento.PessoaJuridica.ParceiroNegocioPessoaJuridica;
using Erp.Model.LargeDataModel;

namespace Erp.Model.Forms.Lancamento.PessoaJuridica.ParceiroNegocioPessoaJuridica
{
    public class LancamentoParceiroNegocioPessoaJuridicaFormModel : ModelFormGeneric<LancamentoParceiroNegocioPessoaJuridica>
    {
        private ParceiroNegocioPessoaJuridicaLargeDataModel _parceiroNegocioPessoaJuridicaLargeData;
        private PlanoContaReferencialLargeDataModel _planoContaReferencialLargeData;

        public LancamentoParceiroNegocioPessoaJuridicaFormModel()
        {
            Entity = new LancamentoParceiroNegocioPessoaJuridica();
            ModelSelect = new LancamentoParceiroNegocioPessoaJuridicaSelectModel();
            
        }

        public override bool IsSalvar
        {
            get
            {
                return false;
            }
            set
            {
                
            }
        }

        public override bool IsExcluir
        {
            get
            {
                return false;
            }
            set
            {
                
            }
        }

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

        public PlanoContaReferencialLargeDataModel PlanoContaReferencialLargeData
        {
            get { return _planoContaReferencialLargeData ?? (_planoContaReferencialLargeData = new PlanoContaReferencialLargeDataModel()); }
            set
            {
                if (Equals(value, _planoContaReferencialLargeData)) return;
                _planoContaReferencialLargeData = value;
                OnPropertyChanged();
            }
        }
    }
}
