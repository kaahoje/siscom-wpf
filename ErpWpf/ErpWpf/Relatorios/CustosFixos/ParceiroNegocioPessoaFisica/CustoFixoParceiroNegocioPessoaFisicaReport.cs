using DevExpress.XtraReports.Parameters;
using Erp.Business.Entity.Contabil.Pessoa.SubClass.PessoaFisica.SubClass.ParceiroNegocio.ClassesRelacionadas;

namespace Erp.Relatorios.CustosFixos.ParceiroNegocioPessoaFisica
{
    public partial class CustoFixoParceiroNegocioPessoaFisicaReport : CustoFixoReport
    {
        public CustoFixoParceiroNegocioPessoaFisicaReport()
        {
            InitializeComponent();
        }

        private void RequestSubmit(object sender, ParametersRequestEventArgs e)
        {
            bindingSource.DataSource = CustoFixoParceiroNegocioPessoaFisicaRepository.GetListAtivos(GetExpression());
        }

    }
}
