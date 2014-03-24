using System.Collections.ObjectModel;
using Erp.Business.Entity.Contabil.Pessoa.SubClass.PessoaJuridica.SubClass.ParceiroNegocio.ClassesRelacionadas;
using Erp.View.Selections.Lancamento.PessoaFisica.ParceiroNegocioPessoaFisica;

namespace Erp.Model.Grids.Lancamento.PessoaFisica.ParceiroNegocioPessoaFisica
{
    public class LancamentoParceiroNegocioPessoaFisicaSelectModel : ModelSelectGeneric<LancamentoParceiroNegocioPessoaJuridica>
    {
        public LancamentoParceiroNegocioPessoaFisicaSelectModel()
        {
            Collection = new ObservableCollection<LancamentoParceiroNegocioPessoaJuridica>();
            WindowSelect = new LancamentoParceiroNegocioPessoaFisicaSelectView();
            WindowSelect.DataContext = this;
        }
    }
}
