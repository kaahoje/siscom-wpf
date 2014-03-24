using System.Collections.ObjectModel;
using DevExpress.Xpf.Ribbon.Customization;
using Erp.Business.Entity.Vendas.Pedido.ClassesRelacionadas;
using Erp.Properties;
using Erp.View.Selections;

namespace Erp.Model.Grids
{
    public class FormaPagamentoSelectModel : ModelSelectGeneric<FormaPagamento>
    {
        public FormaPagamentoSelectModel()
        {
            WindowSelect = new FormaPagamentoSelectView();
            Collection = new ObservableCollection<FormaPagamento>();
            WindowSelect.DataContext = this;
        }
        protected override void Filtrar()
        {
            if (!string.IsNullOrEmpty(Filter) && Filter.Length >= Settings.Default.MinLenghtPesquisa)
            {
                Collection.Clear();
                Collection.AddRange(FormaPagamentoRepository.GetByRange(Filter, Settings.Default.TakePesquisa));
            }
            base.Filtrar();
        }
    }
}
