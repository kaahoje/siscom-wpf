using System.Collections.ObjectModel;
using DevExpress.Xpf.Ribbon.Customization;
using Erp.Business.Entity.Fiscal;
using Erp.Properties;
using Erp.View.Selections;


namespace Erp.Model.Grids
{
    public class NotaFiscalSelectModel : ModelSelectGeneric<NotaFiscal>
    {
        public NotaFiscalSelectModel()
        {
           
            WindowSelect = new NotaFiscalSelectView();
            Collection = new ObservableCollection<NotaFiscal>();
            WindowSelect.DataContext = this;
        
        }
        public bool Entrada { get; set; }
        protected override void Filtrar()
        {
            if (!string.IsNullOrEmpty(Filter) && Filter.Length >= Settings.Default.MinLenghtPesquisa)
            {
                Collection.Clear();
                if (Entrada)
                {
                    Collection.AddRange(NotaFiscalRepository.GetByRangeEntrada(Filter, Settings.Default.TakePesquisa));
                }
                else
                {
                    Collection.AddRange(NotaFiscalRepository.GetByRangeSaida(Filter, Settings.Default.TakePesquisa));
                }
                
            }
        }
    }
}
