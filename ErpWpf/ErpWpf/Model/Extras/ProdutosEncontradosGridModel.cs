using System.Collections.ObjectModel;
using Erp.Business.Entity.Estoque.Produto;
using Erp.View.Extras;

namespace Erp.Model.Extras
{
    public  class ProdutosEncontradosGridModel : ModelSelectGeneric<Produto>
    {
        public ProdutosEncontradosGridModel()
        {
            WindowSelect = new ProdutosEncontradosSelectView();
            WindowSelect.DataContext = this;
        }
        protected override void Filtrar()
        {
            if (!string.IsNullOrEmpty(Filter))
            {
                Collection.Clear();
                Collection = new ObservableCollection<Produto>(ProdutoRepository.GetByRange(Filter));
            }
        }
    }
}
