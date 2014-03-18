using System.Collections.ObjectModel;
using DevExpress.Xpf.Ribbon.Customization;
using Erp.Business.Entity.Estoque.Produto.ClassesRelacionadas;
using Erp.Properties;
using Erp.View.Selections;

namespace Erp.Model.Grids
{
    public class UnidadeSelectModel : ModelSelectGeneric<Unidade>
    {
        public UnidadeSelectModel()
        {
            WindowSelect = new UnidadeSelectView();
            Collection = new ObservableCollection<Unidade>();
        }

        protected override void Filtrar()
        {
            if (!string.IsNullOrEmpty(Filter) && Filter.Length >= Settings.Default.MinLenghtPesquisa)
            {
                Collection.Clear();
                Collection.AddRange(UnidadeRepository.GetByRange(Filter, 0, Settings.Default.TakePesquisa));
            }
        }
    }
}
