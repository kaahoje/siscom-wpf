using System.Collections.ObjectModel;
using Erp.Business.Entity.Contabil.Pessoa.SubClass.PessoaFisica.SubClass.ParceiroNegocio.ClassesRelacionadas;
using Erp.View.Selections.CustoFixo.PessoaFisica.ParceiroNegocioPessoaFisica;

namespace Erp.Model.Grids.CustoFixo.PessoaFisica.ParceiroNegocioPessoaFisica
{
    public class CustoFixoParceiroNegocioPessoaFisicaSelectModel : ModelSelectGeneric<CustoFixoParceiroNegocioPessoaFisica>
    {
        public CustoFixoParceiroNegocioPessoaFisicaSelectModel()
        {
            Collection = new ObservableCollection<CustoFixoParceiroNegocioPessoaFisica>();
            WindowSelect = new CustoFixoParceiroNegocioPessoaFisicaSelectView();
            WindowSelect.DataContext = this;
        }
    }
}
