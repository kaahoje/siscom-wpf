using System.Collections.ObjectModel;
using Erp.Business.Entity.Contabil.Pessoa.ClassesRelacionadas.Endereco;
using Erp.Properties;
using Erp.View.Selections;

namespace Erp.Model.Grids
{
    public class EnderecoSelectModel : ModelSelectGeneric<Endereco>
    {
        public EnderecoSelectModel()
        {
            Collection = new ObservableCollection<Endereco>();
            WindowSelect = new EnderecoSelectView();
        }

        protected override void Filtrar()
        {
            if (!string.IsNullOrEmpty(Filter) && Filter.Length >= Settings.Default.MinLenghtPesquisa)
            {
                Collection = new ObservableCollection<Endereco>(EnderecoRepository.GetEnderecoRange(Filter,0,Settings.Default.TakePesquisa));
            }
        }
    }
}
