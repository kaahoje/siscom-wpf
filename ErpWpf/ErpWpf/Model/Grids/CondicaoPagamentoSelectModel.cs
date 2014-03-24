using System.Collections.ObjectModel;
using DevExpress.Xpf.Ribbon.Customization;
using Erp.Business.Entity.Vendas.Pedido.ClassesRelacionadas;
using Erp.Properties;
using Erp.View.Selections;

namespace Erp.Model.Grids
{
    public class CondicaoPagamentoSelectModel : ModelSelectGeneric<CondicaoPagamento>
    {
        public CondicaoPagamentoSelectModel()
        {
            WindowSelect = new CondicaoPagamentoSelectView();
            Collection = new ObservableCollection<CondicaoPagamento>();
            WindowSelect.DataContext = this;
        }
        protected override void Filtrar()
        {
            if (!string.IsNullOrEmpty(Filter) && Filter.Length >= Settings.Default.MinLenghtPesquisa)
            {
                Collection.Clear();
                Collection.AddRange(CondicaoPagamentoRepository.GetByRange(Filter,Settings.Default.TakePesquisa));
            }
            base.Filtrar();
        }

       
    }
}
