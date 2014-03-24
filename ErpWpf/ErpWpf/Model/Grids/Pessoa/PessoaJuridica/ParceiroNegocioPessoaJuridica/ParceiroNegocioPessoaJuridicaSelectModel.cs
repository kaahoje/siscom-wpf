using System.Collections.ObjectModel;
using DevExpress.Xpf.Ribbon.Customization;
using Erp.Business.Entity.Contabil.Pessoa.SubClass.PessoaJuridica.SubClass.ParceiroNegocio;
using Erp.Properties;
using Erp.View.Selections.Pessoa.PessoaJuridica.ParceiroNegocioPessoaJuridica;

namespace Erp.Model.Grids.Pessoa.PessoaJuridica.ParceiroNegocioPessoaJuridica
{
    public class ParceiroNegocioPessoaJuridicaSelectModel : ModelSelectGeneric<Business.Entity.Contabil.Pessoa.SubClass.PessoaJuridica.SubClass.ParceiroNegocio.ParceiroNegocioPessoaJuridica>
    {
        public ParceiroNegocioPessoaJuridicaSelectModel()
        {
            Collection = new ObservableCollection<Business.Entity.Contabil.Pessoa.SubClass.PessoaJuridica.SubClass.ParceiroNegocio.ParceiroNegocioPessoaJuridica>();
            WindowSelect = new ParceiroNegocioPessoaJuridicaSelectView();
            WindowSelect.DataContext = this;
        }

        protected override void Filtrar()
        {
            if (!string.IsNullOrEmpty(Filter) && Filter.Length >= Settings.Default.MinLenghtPesquisa)
            {
                Collection.Clear();
                Collection.AddRange(ParceiroNegocioPessoaJuridicaRepository.GetByRange(Filter, Settings.Default.TakePesquisa));
            }
            base.Filtrar();
            
        }
    }
}
