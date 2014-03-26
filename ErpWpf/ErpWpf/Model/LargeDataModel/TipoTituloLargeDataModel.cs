using System;
using System.Collections.ObjectModel;
using System.Linq;
using DevExpress.Xpf.Ribbon.Customization;
using Erp.Business.Entity.Contabil;
using Erp.Properties;
using Util.Wpf;

namespace Erp.Model.LargeDataModel
{
    public class TipoTituloLargeDataModel : LargeDataModelGeneric<TipoTitulo>
    {
        public TipoTituloLargeDataModel()
        {
            try
            {
                Collection = new ObservableCollection<TipoTitulo>();
                Reset();
            }
            catch (Exception)
            {
                
            }
            
        }

        public override void Reset()
        {
            Collection.Clear();
            Collection.AddRange(TipoTituloRepository.GetListAtivos().Take(Settings.Default.TakePesquisa));
        }

        public override void Filtrar()
        {
            if (!string.IsNullOrEmpty(Filter) && Filter.Length >= Settings.Default.MinLenghtPesquisa)
            {
                Collection.Clear();
                Collection.AddRange(TipoTituloRepository.GetByRange(Filter, Settings.Default.TakePesquisa));
            }
        }
    }
}
