using System.Collections.ObjectModel;
using DevExpress.Xpf.Ribbon.Customization;
using Erp.Business.Entity.Estoque.Produto.ClassesRelacionadas;
using Erp.Properties;
using Erp.View.Selections;

namespace Erp.Model.Grids
{
    public class SubGrupoProdutoSelectModel : ModelSelectGeneric<SubGrupoProduto>
    {
        public SubGrupoProdutoSelectModel()
        {
            WindowSelect = new SubGrupoProdutoSelectView();
            Collection = new ObservableCollection<SubGrupoProduto>();
        }

        protected override void Filtrar()
        {
            if (!string.IsNullOrEmpty(Filter) && Filter.Length >= Settings.Default.MinLenghtPesquisa)
            {
                Collection.Clear();
                Collection.AddRange(SubGrupoProdutoRepository.GetByRange(Filter, Settings.Default.TakePesquisa));
            }
        }
    }
}
