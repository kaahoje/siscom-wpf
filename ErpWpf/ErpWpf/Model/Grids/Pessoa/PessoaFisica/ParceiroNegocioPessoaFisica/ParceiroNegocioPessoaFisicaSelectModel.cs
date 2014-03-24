using System.Collections.ObjectModel;
using DevExpress.Xpf.Ribbon.Customization;
using Erp.Business.Entity.Contabil.Pessoa.SubClass.PessoaFisica.SubClass.ParceiroNegocio;
using Erp.Properties;
using Erp.View.Selections.Pessoa.PessoaFisica.ParceiroNegocioPessoaFisica;

namespace Erp.Model.Grids.Pessoa.PessoaFisica.ParceiroNegocioPessoaFisica
{
    public class ParceiroNegocioPessoaFisicaSelectModel : ModelSelectGeneric<Business.Entity.Contabil.Pessoa.SubClass.PessoaFisica.SubClass.ParceiroNegocio.ParceiroNegocioPessoaFisica>
    {
        public ParceiroNegocioPessoaFisicaSelectModel()
        {
            Collection = new ObservableCollection<Business.Entity.Contabil.Pessoa.SubClass.PessoaFisica.SubClass.ParceiroNegocio.ParceiroNegocioPessoaFisica>();
            WindowSelect = new ParceiroNegocioPessoaFisicaSelectView();
            WindowSelect.DataContext = this;
        }

        protected override void Filtrar()
        {
            if (!string.IsNullOrEmpty(Filter) && Filter.Length >= Settings.Default.MinLenghtPesquisa)
            {
                Collection.Clear();
                Collection.AddRange(ParceiroNegocioPessoaFisicaRepository.GetByRange(Filter, Settings.Default.TakePesquisa));
            }
            base.Filtrar();
            
        }
    }
}
