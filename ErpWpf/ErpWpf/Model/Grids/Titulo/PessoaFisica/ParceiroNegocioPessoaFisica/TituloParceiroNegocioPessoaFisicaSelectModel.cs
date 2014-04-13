using System.Collections.ObjectModel;
using DevExpress.Xpf.Ribbon.Customization;
using Erp.Business.Entity.Contabil.Pessoa.SubClass.PessoaFisica.SubClass.ParceiroNegocio.ClassesRelacionadas;
using Erp.Properties;
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

        protected override void Filtrar()
        {
            if (!string.IsNullOrEmpty(Filter) && Filter.Length >= Settings.Default.MinLenghtPesquisa)
            {
                Collection.Clear();
                Collection.AddRange(TituloParceiroNegocioPessoaFisicaRepository.GetByRange(Filter, Settings.Default.TakePesquisa));
            }
            base.Filtrar();
        }
    }
}
