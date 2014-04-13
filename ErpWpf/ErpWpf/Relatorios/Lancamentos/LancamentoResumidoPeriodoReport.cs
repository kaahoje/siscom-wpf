using DevExpress.XtraReports.Parameters;
using Erp.Business.Entity.Contabil;
using NHibernate.Criterion;

namespace Erp.Relatorios.Lancamentos
{
    public partial class LancamentoResumidoPeriodoReport : BaseDatePeriodeLandscape
    {
        public LancamentoResumidoPeriodoReport()
        {
            InitializeComponent();
        }

        public override AbstractCriterion GetExpression()
        {
            return Restrictions.Between("DataLancamento", DataInicialAbreviada(), DataFinalAbreviada());
        }

        private void LancamentoResumidoPeriodoReport_ParametersRequestSubmit(object sender, ParametersRequestEventArgs e)
        {
            bindingSource.DataSource = LancamentoRepository.GetListAtivos(GetExpression());
        }
    }
}
