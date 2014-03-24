using DevExpress.Xpf.Ribbon.Customization;
using Erp.Business.Entity.Contabil;
using Erp.Properties;

namespace Erp.Model.Grids
{
    public class TipoTituloSelectModel : ModelSelectGeneric<TipoTitulo>
    {
        protected override void Filtrar()
        {
            if (!string.IsNullOrEmpty(Filter) && Filter.Length >= Settings.Default.MinLenghtPesquisa)
            {
                Collection.Clear();
                Collection.AddRange(TipoTituloRepository.GetByRange(Filter, Settings.Default.TakePesquisa));
            }
            base.Filtrar();
        }
    }
}
