using System.Collections.ObjectModel;
using Erp.Business.Entity.Contabil.Pessoa.SubClass.PessoaJuridica.SubClass.ParceiroNegocio.ClassesRelacionadas;
using Erp.View.Selections.Lancamento.PessoaJuridica.ParceiroNegocioPessoaJuridica;

namespace Erp.Model.Grids.Lancamento.PessoaJuridica.ParceiroNegocioPessoaJuridica
{
    public class LancamentoParceiroNegocioPessoaJuridicaSelectModel : ModelSelectGeneric<LancamentoParceiroNegocioPessoaJuridica>
    {
        public LancamentoParceiroNegocioPessoaJuridicaSelectModel()
        {
            Collection = new ObservableCollection<LancamentoParceiroNegocioPessoaJuridica>();
            WindowSelect = new LancamentoParceiroNegocioPessoaJuridicaSelectView {DataContext = this};
        }
    }
}
