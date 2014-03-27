using System.Collections.ObjectModel;
using DevExpress.Xpf.Ribbon.Customization;
using Erp.Business.Entity.Contabil.Pessoa.SubClass.PessoaFisica;
using Erp.Properties;
using Erp.View.Selections;

namespace Erp.Model.Grids
{
    public class PermissaoUsuarioSelectModel : ModelSelectGeneric<PessoaFisica>
    {
        public PermissaoUsuarioSelectModel ()
        {
            Collection = new ObservableCollection<PessoaFisica>();
            WindowSelect = new PermissaoUsuarioSelectView();
            WindowSelect.DataContext = this;
        }
        protected override void Filtrar()
        {
            if (!string.IsNullOrEmpty(Filter) && Filter.Length >= Settings.Default.MinLenghtPesquisa)
            {
                
                Collection.Clear();
                Collection.AddRange(PessoaFisicaRepository.GetByRange(Filter, Settings.Default.TakePesquisa));
            }
        }
    }
}
