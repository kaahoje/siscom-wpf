using DevExpress.Xpf.Ribbon.Customization;
using Erp.Business.Entity.Sped;
using Erp.Properties;
using Util.Wpf;

namespace Erp.Model.LargeDataModel
{
    public class PlanoContaReferencialLargeDataModel : LargeDataModelGeneric<PlanoContaReferencial>
    {
        public override void Filtrar()
        {
            if (!string.IsNullOrEmpty(Filter) && Filter.Length >= Settings.Default.MinLenghtPesquisa)
            {
                Collection.Clear();
                Collection.AddRange(PlanoContaReferencialRepository.GetByRange(Filter, Settings.Default.TakePesquisa));
            }
        }
    }
}
