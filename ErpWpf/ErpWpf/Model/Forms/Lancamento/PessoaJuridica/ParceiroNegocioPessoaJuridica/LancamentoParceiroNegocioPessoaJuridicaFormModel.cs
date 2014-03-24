using Erp.Business.Entity.Contabil.Pessoa.SubClass.PessoaJuridica.SubClass.ParceiroNegocio.ClassesRelacionadas;
using Erp.Model.Grids.Lancamento.PessoaJuridica.ParceiroNegocioPessoaJuridica;

namespace Erp.Model.Forms.Lancamento.PessoaJuridica.ParceiroNegocioPessoaJuridica
{
    public class LancamentoParceiroNegocioPessoaJuridicaFormModel : ModelFormGeneric<LancamentoParceiroNegocioPessoaJuridica>
    {
        public LancamentoParceiroNegocioPessoaJuridicaFormModel()
        {
            Entity = new LancamentoParceiroNegocioPessoaJuridica();
            ModelSelect = new LancamentoParceiroNegocioPessoaJuridicaSelectModel();
        }
    }
}
