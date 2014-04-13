using DevExpress.XtraReports.Parameters;
using Erp.Business.Entity.Contabil.Pessoa.SubClass.PessoaFisica.SubClass.ParceiroNegocio.ClassesRelacionadas;

namespace Erp.Relatorios.Titulos.ParceiroNegocioPessoaFisica
{
    public partial class TituloParceiroNegocioPessoaFisicaPeriodoReport : TituloPeriodoReport
    {
        public TituloParceiroNegocioPessoaFisicaPeriodoReport()
        {
            InitializeComponent();
        }

        private void TituloParceiroNegocioPessoaFisicaPeriodoReport_ParametersRequestSubmit(object sender, ParametersRequestEventArgs e)
        {
            bindingSource.DataSource = TituloParceiroNegocioPessoaFisicaRepository.GetListAtivos(GetExpression());
        }

    }
}
