using System.Collections.ObjectModel;
using DevExpress.Xpf.Ribbon.Customization;
using Erp.Business.Entity.Estoque.Produto.ClassesRelacionadas;
using Erp.Properties;
using Erp.View.Selections;

namespace Erp.Model.Grids
{
    public class GrupoProdutoSelectModel : ModelSelectGeneric<GrupoProduto>
    {
        public GrupoProdutoSelectModel()
        {
            WindowSelect = new GrupoProdutoSelectView();
            Collection = new ObservableCollection<GrupoProduto>();
            WindowSelect.DataContext = this;
        }

        protected override void Filtrar()
        {
            if (!string.IsNullOrEmpty(Filter) && Filter.Length >= Settings.Default.MinLenghtPesquisa)
            {
                Collection.Clear();
                Collection.AddRange(GrupoProdutoRepository.GetByRange(Filter,Settings.Default.MinLenghtPesquisa));
            }
        }
    }
}
