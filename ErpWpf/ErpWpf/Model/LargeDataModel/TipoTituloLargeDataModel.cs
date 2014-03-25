using System.Collections.ObjectModel;
using Erp.Business.Entity.Contabil;
using Util.Wpf;

namespace Erp.Model.LargeDataModel
{
    public class TipoTituloLargeDataModel : LargeDataModelGeneric<TipoTitulo>
    {
        public TipoTituloLargeDataModel()
        {
            Collection = new ObservableCollection<TipoTitulo>(TipoTituloRepository.GetListAtivos());
        }
        public override void Filtrar()
        {
            
        }
    }
}
