using DevExpress.XtraReports.Parameters;
using Erp.Business.Entity.Contabil.Pessoa.SubClass.PessoaJuridica.SubClass.ParceiroNegocio.ClassesRelacionadas;

namespace Erp.Relatorios.Lancamentos.ParceiroNegocioPessoaJuridica
{
    public partial class LancamentoParceiroNegocioPessoaJuridicaResumidoPeriodoReport : LancamentoResumidoPeriodoReport
    {
        public LancamentoParceiroNegocioPessoaJuridicaResumidoPeriodoReport()
        {
            InitializeComponent();
        }

        private void LancamentoParceiroNegocioPessoaJuridicaResumidoPeriodoReport_ParametersRequestSubmit(object sender, ParametersRequestEventArgs e)
        {
            bindingSource.DataSource = LancamentoParceiroNegocioPessoaJuridicaRepository.GetListAtivos(GetExpression());
        }

    }
}
