using System.Collections.ObjectModel;
using DevExpress.Xpf.Ribbon.Customization;
using Erp.Business.Entity.Estoque.Produto;
using Erp.Properties;
using Util.Wpf;

namespace Erp.Model.LargeDataModel
{
    public class ProdutoLargeDataModel : LargeDataModelGeneric<Produto>
    {
        public override void Reset()
        {
            Collection.Clear();

        }

        public override void Filtrar()
        {
            Collection.Clear();
            if (!string.IsNullOrEmpty(Filter))
            {
                Collection.AddRange(ProdutoRepository.GetByRange(Filter,Settings.Default.TakePesquisa));
            }
        }
    }
}
