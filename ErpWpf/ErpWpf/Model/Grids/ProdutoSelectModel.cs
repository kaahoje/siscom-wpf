using System.Collections.ObjectModel;
using DevExpress.Xpf.Ribbon.Customization;
using Erp.Business.Entity.Estoque.Produto;
using Erp.Properties;
using Erp.View.Forms;
using Erp.View.Selections;

namespace Erp.Model.Grids
{
    public class ProdutoSelectModel : ModelSelectGeneric<Produto>
    {
        public ProdutoSelectModel()
        {
            WindowSelect = new ProdutoSelectView ();
            Collection = new ObservableCollection<Produto>();
            
        }
        protected override void Filtrar()
        {
            if (!string.IsNullOrEmpty(Filter) && Filter.Length >= Settings.Default.MinLenghtPesquisa)
            {
                Collection.Clear();
                Collection.AddRange(ProdutoRepository.GetByRange(Filter, Settings.Default.TakePesquisa));
            }
            base.Filtrar();
        }
        
    }
}
