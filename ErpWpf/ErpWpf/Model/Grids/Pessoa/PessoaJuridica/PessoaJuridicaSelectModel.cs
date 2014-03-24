using System.Collections.ObjectModel;
using Erp.View.Selections.Pessoa.PessoaJuridica;

namespace Erp.Model.Grids.Pessoa.PessoaJuridica
{
    public class PessoaJuridicaSelectModel : ModelSelectGeneric<Business.Entity.Contabil.Pessoa.SubClass.PessoaJuridica.PessoaJuridica>
    {
        public PessoaJuridicaSelectModel()
        {
            Collection = new ObservableCollection<Business.Entity.Contabil.Pessoa.SubClass.PessoaJuridica.PessoaJuridica>();
            WindowSelect = new PessoaJuridicaSelectView();
            WindowSelect.DataContext = this;
        }
    }
}
