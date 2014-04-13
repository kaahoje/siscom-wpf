using Erp.Business.Entity.Contabil;
using NHibernate.Criterion;

namespace Erp.Relatorios.CustosFixos
{
    public partial class CustoFixoReport : BaseIntegerPeriodeLandscape
    {
        public CustoFixoReport()
        {
            InitializeComponent();
            valorInicial.Description = "Dia inicial";
            valorFinal.Description = "Dia final";

            valorInicial.Value = 1;
            valorFinal.Value = 31;
            ParametersRequestSubmit += CustoFixoReport_ParametersRequestSubmit;
        }

        void CustoFixoReport_ParametersRequestSubmit(object sender, DevExpress.XtraReports.Parameters.ParametersRequestEventArgs e)
        {
            bindingSource.DataSource = CustoFixoRepository.GetListAtivos(GetExpression());
        }

        
        public override AbstractCriterion GetExpression()
        {
            return Restrictions.Between("DiaVencimento", valorInicial.Value, valorFinal.Value);
        }
    }
}
