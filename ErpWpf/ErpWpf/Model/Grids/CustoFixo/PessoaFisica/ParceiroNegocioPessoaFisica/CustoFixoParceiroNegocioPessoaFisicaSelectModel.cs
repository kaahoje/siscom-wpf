using System.Collections.ObjectModel;
using DevExpress.Xpf.Ribbon.Customization;
using Erp.Business.Entity.Contabil.Pessoa.SubClass.PessoaFisica.SubClass.ParceiroNegocio.ClassesRelacionadas;
using Erp.Business.Entity.Vendas.Pedido.ClassesRelacionadas;
using Erp.Properties;
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

        protected override void Filtrar()
        {
            if (!string.IsNullOrEmpty(Filter) && Filter.Length >= Settings.Default.MinLenghtPesquisa)
            {
                Collection.Clear();
                Collection.AddRange(CustoFixoParceiroNegocioPessoaFisicaRepository.GetByRange(Filter, Settings.Default.TakePesquisa));
            }
            base.Filtrar();
        }
    }
}
