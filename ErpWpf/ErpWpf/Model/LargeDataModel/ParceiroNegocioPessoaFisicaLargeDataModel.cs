using System;
using System.Collections.ObjectModel;
using System.Linq;
using DevExpress.Xpf.Ribbon.Customization;
using Erp.Business.Entity.Contabil.Pessoa.SubClass.PessoaFisica.SubClass.ParceiroNegocio;
using Erp.Properties;
using Util.Wpf;

namespace Erp.Model.LargeDataModel
{
    public class ParceiroNegocioPessoaFisicaLargeDataModel : LargeDataModelGeneric<ParceiroNegocioPessoaFisica>
    {
        public ParceiroNegocioPessoaFisicaLargeDataModel()
        {
            try
            {
                try
                {
                    Collection = new ObservableCollection<ParceiroNegocioPessoaFisica>();
                    Reset();
                }
                catch (Exception)
                {
                    
                }
                
            }
            catch (Exception)
            {
                
            }
            
        }

        public override void Reset()
        {
            Collection.Clear();
            Collection.AddRange(ParceiroNegocioPessoaFisicaRepository.GetList().Take(Settings.Default.TakePesquisa));
        }

        public override void Filtrar()
        {
            if (!string.IsNullOrEmpty(Filter) && Filter.Length >= Settings.Default.MinLenghtPesquisa)
            {
                Collection.Clear();
                Collection.AddRange(ParceiroNegocioPessoaFisicaRepository.GetByRange(Filter, Settings.Default.TakePesquisa));
            }
        }
    }
}
