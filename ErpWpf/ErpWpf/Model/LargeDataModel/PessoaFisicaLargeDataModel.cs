using System.Linq;
using DevExpress.Xpf.Ribbon.Customization;
using Erp.Business.Entity.Contabil.Pessoa.SubClass.PessoaFisica;
using Erp.Properties;
using Util.Wpf;

namespace Erp.Model.LargeDataModel
{
    public class PessoaFisicaLargeDataModel : LargeDataModelGeneric<PessoaFisica>
    {
        public override void Reset()
        {
            Collection.Clear();
            Collection.AddRange(PessoaFisicaRepository.GetListAtivos().Take(Settings.Default.TakePesquisa));
        }

        public override void Filtrar()
        {
            if (!string.IsNullOrEmpty(Filter) && Filter.Length >= Settings.Default.MinLenghtPesquisa)
            {
                Collection.Clear();
                Collection.AddRange(PessoaFisicaRepository.GetByRange(Filter, Settings.Default.TakePesquisa));
            }
        }
    }
}
