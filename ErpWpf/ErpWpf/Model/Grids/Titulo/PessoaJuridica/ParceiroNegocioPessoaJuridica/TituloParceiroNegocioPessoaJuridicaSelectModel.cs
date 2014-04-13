using System.Collections.ObjectModel;
using DevExpress.Xpf.Ribbon.Customization;
using Erp.Business.Entity.Contabil.Pessoa.SubClass.PessoaJuridica.SubClass.ParceiroNegocio.ClassesRelacionadas;
using Erp.Properties;
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

        protected override void Filtrar()
        {
            if (!string.IsNullOrEmpty(Filter) && Filter.Length >= Settings.Default.MinLenghtPesquisa)
            {
                Collection.Clear();
                Collection.AddRange(TituloParceiroNegocioPessoaJuridicaRepository.GetByRange(Filter, Settings.Default.TakePesquisa));
            }
            base.Filtrar();
        }
    }
}
