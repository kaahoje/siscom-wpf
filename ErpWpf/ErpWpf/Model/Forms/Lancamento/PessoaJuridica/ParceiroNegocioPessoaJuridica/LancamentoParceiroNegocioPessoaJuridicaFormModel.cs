using Erp.Business.Entity.Contabil.Pessoa.SubClass.PessoaJuridica.SubClass.ParceiroNegocio.ClassesRelacionadas;
using Erp.Model.Grids.Lancamento.PessoaJuridica.ParceiroNegocioPessoaJuridica;
using Erp.Model.LargeDataModel;

namespace Erp.Model.Forms.Lancamento.PessoaJuridica.ParceiroNegocioPessoaJuridica
{
    public class LancamentoParceiroNegocioPessoaJuridicaFormModel : ModelFormGeneric<LancamentoParceiroNegocioPessoaJuridica>
    {
        private ParceiroNegocioPessoaJuridicaLargeDataModel _parceiroNegocioPessoaJuridicaLargeData;

        public LancamentoParceiroNegocioPessoaJuridicaFormModel()
        {
            Entity = new LancamentoParceiroNegocioPessoaJuridica();
            ModelSelect = new LancamentoParceiroNegocioPessoaJuridicaSelectModel();
        }

        public ParceiroNegocioPessoaJuridicaLargeDataModel ParceiroNegocioPessoaJuridicaLargeData
        {
            get { return _parceiroNegocioPessoaJuridicaLargeData; }
            set
            {
                if (Equals(value, _parceiroNegocioPessoaJuridicaLargeData)) return;
                _parceiroNegocioPessoaJuridicaLargeData = value;
                OnPropertyChanged();
            }
        }
    }
}
