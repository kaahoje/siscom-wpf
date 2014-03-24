using System.Collections.ObjectModel;
using DevExpress.Xpf.Ribbon.Customization;
using Erp.Business.Entity.Sped;
using Erp.Properties;
using Erp.View.Selections;

namespace Erp.Model.Grids
{
    public class NcmSelectModel : ModelSelectGeneric<Ncm>
    {
        public NcmSelectModel()
        {
            WindowSelect = new NcmSelectView();
            Collection = new ObservableCollection<Ncm>();
            WindowSelect.DataContext = this;
        }

        protected override void Filtrar()
        {
            if (!string.IsNullOrEmpty(Filter) && Filter.Length >= Settings.Default.MinLenghtPesquisa)
            {
                Collection.Clear();
                Collection.AddRange(NcmRepository.GetByRange(Filter, Settings.Default.TakePesquisa));
            }
            base.Filtrar();
        }
    }
}
