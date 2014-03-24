using System.Collections.ObjectModel;
using Erp.View.Selections.Pessoa.PessoaFisica;

namespace Erp.Model.Grids.Pessoa.PessoaFisica
{
    public class PessoaFisicaSelectModel : ModelSelectGeneric<Business.Entity.Contabil.Pessoa.SubClass.PessoaFisica.PessoaFisica>
    {
        public PessoaFisicaSelectModel()
        {
            Collection = new ObservableCollection<Business.Entity.Contabil.Pessoa.SubClass.PessoaFisica.PessoaFisica>();
            WindowSelect = new PessoaFisicaSelectView();
            WindowSelect.DataContext = this;
        }
    }
}
