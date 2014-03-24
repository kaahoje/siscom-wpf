using System.Collections.ObjectModel;
using Erp.Business.Entity.Contabil.Pessoa.SubClass.PessoaJuridica.SubClass.ParceiroNegocio.ClassesRelacionadas;
using Erp.View.Selections.Titulos.PessoaJuridica.ParceiroNegocioPessoaJuridica;

namespace Erp.Model.Grids.Titulo.PessoaJuridica.ParceiroNegocioPessoaJuridica
{
    public class TituloParceiroNegocioPessoaJuridicaSelectModel : ModelSelectGeneric<TituloParceiroNegocioPessoaJuridica>
    {
        public TituloParceiroNegocioPessoaJuridicaSelectModel()
        {
            Collection = new ObservableCollection<TituloParceiroNegocioPessoaJuridica>();
            WindowSelect = new TituloParceiroNegocioPessoaJuridicaSelectView();
            WindowSelect.DataContext = this;
        }
    }
}
