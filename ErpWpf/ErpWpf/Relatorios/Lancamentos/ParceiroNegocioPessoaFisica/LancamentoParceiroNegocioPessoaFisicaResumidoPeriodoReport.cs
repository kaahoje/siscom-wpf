using DevExpress.XtraReports.Parameters;
using Erp.Business.Entity.Contabil.Pessoa.SubClass.PessoaFisica.SubClass.ParceiroNegocio.ClassesRelacionadas;

namespace Erp.Relatorios.Lancamentos.ParceiroNegocioPessoaFisica
{
    public partial class LancamentoParceiroNegocioPessoaFisicaResumidoPeriodoReport : LancamentoResumidoPeriodoReport
    {
        public LancamentoParceiroNegocioPessoaFisicaResumidoPeriodoReport()
        {
            InitializeComponent();
        }

        private void LancamentoParceiroNegocioPessoaFisicaResumidoPeriodoReport_ParametersRequestSubmit(object sender, ParametersRequestEventArgs e)
        {
            bindingSource.DataSource = LancamentoParceiroNegocioPessoaFisicaRepository.GetListAtivos(GetExpression());
        }

    }
}
