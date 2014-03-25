using DevExpress.Xpf.Ribbon.Customization;
using Erp.Business.Entity.Contabil.Pessoa.SubClass.PessoaJuridica.SubClass.ParceiroNegocio;
using Erp.Properties;
using Util.Wpf;

namespace Erp.Model.LargeDataModel
{
    public class ParceiroNegocioPessoaJuridicaLargeDataModel : LargeDataModelGeneric<ParceiroNegocioPessoaJuridica>
    {
        public override void Filtrar()
        {
            if (!string.IsNullOrEmpty(Filter) && Filter.Length >= Settings.Default.MinLenghtPesquisa)
            {
                Collection.Clear();
                Collection.AddRange(ParceiroNegocioPessoaJuridicaRepository.GetByRange(Filter, Settings.Default.TakePesquisa));
            }
        }
    }
}
