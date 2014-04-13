using DevExpress.XtraReports.Parameters;
using Erp.Business.Entity.Contabil.Pessoa.SubClass.PessoaJuridica.SubClass.ParceiroNegocio.ClassesRelacionadas;

namespace Erp.Relatorios.CustosFixos.ParceiroNegocioPessoaJuridica
{
    public partial class CustoFixoParceiroNegocioPessoaJuridicaReport : CustoFixoReport
    {
        public CustoFixoParceiroNegocioPessoaJuridicaReport()
        {
            InitializeComponent();
        }

        private void ParameterSubmit(object sender, ParametersRequestEventArgs e)
        {
            bindingSource.DataSource = CustoFixoParceiroNegocioPessoaJuridicaRepository.GetListAtivos(GetExpression());
        }

    }
}
