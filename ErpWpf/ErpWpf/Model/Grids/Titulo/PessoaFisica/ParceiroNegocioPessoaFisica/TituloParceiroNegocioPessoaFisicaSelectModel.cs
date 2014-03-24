using System.Collections.ObjectModel;
using Erp.Business.Entity.Contabil.Pessoa.SubClass.PessoaFisica.SubClass.ParceiroNegocio.ClassesRelacionadas;
using Erp.View.Selections.Titulos.PessoaFisica.ParceiroNegocioPessoaFisica;

namespace Erp.Model.Grids.Titulo.PessoaFisica.ParceiroNegocioPessoaFisica
{
    public class TituloParceiroNegocioPessoaFisicaSelecModel : ModelSelectGeneric<TituloParceiroNegocioPessoaFisica>
    {
        public TituloParceiroNegocioPessoaFisicaSelecModel()
        {
            Collection = new ObservableCollection<TituloParceiroNegocioPessoaFisica>();
            WindowSelect = new TituloParceiroNegocioPessoaFisicaSelectView {DataContext = this};
        }
    }
}
