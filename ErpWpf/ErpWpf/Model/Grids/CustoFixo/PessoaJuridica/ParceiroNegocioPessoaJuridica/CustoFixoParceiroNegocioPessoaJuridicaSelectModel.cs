using System.Collections.ObjectModel;
using Erp.Business.Entity.Contabil.Pessoa.SubClass.PessoaJuridica.SubClass.ParceiroNegocio.ClassesRelacionadas;
using Erp.View.Selections.CustoFixo.PessoaJuridica.ParceiroNegocioPessoaJuridica;

namespace Erp.Model.Grids.CustoFixo.PessoaJuridica.ParceiroNegocioPessoaJuridica
{
    public class CustoFixoParceiroNegocioPessoaJuridicaSelectModel : ModelSelectGeneric<CustoFixoParceiroNegocioPessoaJuridica>
    {
        public CustoFixoParceiroNegocioPessoaJuridicaSelectModel()
        {
            Collection = new ObservableCollection<CustoFixoParceiroNegocioPessoaJuridica>();
            WindowSelect = new CustoFixoParceiroNegocioPessoaJuridicaSelectView();
            WindowSelect.DataContext = this;
        }
    }
}
