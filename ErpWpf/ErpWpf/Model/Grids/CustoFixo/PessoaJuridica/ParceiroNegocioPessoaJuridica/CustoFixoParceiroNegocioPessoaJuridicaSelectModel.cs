using System.Collections.ObjectModel;
using DevExpress.Xpf.Ribbon.Customization;
using Erp.Business.Entity.Contabil.Pessoa.SubClass.PessoaFisica.SubClass.ParceiroNegocio.ClassesRelacionadas;
using Erp.Business.Entity.Contabil.Pessoa.SubClass.PessoaJuridica.SubClass.ParceiroNegocio.ClassesRelacionadas;
using Erp.Properties;
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

        protected override void Filtrar()
        {
            if (!string.IsNullOrEmpty(Filter) && Filter.Length >= Settings.Default.MinLenghtPesquisa)
            {
                Collection.Clear();
                Collection.AddRange(CustoFixoParceiroNegocioPessoaJuridicaRepository.GetByRange(Filter, Settings.Default.TakePesquisa));
            }
            base.Filtrar();
        }
    }
}
