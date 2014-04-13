using DevExpress.XtraReports.Parameters;
using Erp.Business.Entity.Contabil;
using NHibernate.Criterion;

namespace Erp.Relatorios.Titulos
{
    public partial class TituloPeriodoReport : BaseDatePeriodePortrait
    {
        public TituloPeriodoReport()
        {
            InitializeComponent();
        }

        public override AbstractCriterion GetExpression()
        {

            var exp = Restrictions.Conjunction().Add(Restrictions.Between("DataVencimento", DataInicialAbreviada(), DataFinalAbreviada()));
            switch (entrada.Value.ToString())
            {
                case "Entrada":
                    exp.Add(Restrictions.Eq("AReceber", true));
                    break;
                case "Saida":
                    exp.Add(Restrictions.Eq("AReceber", false));
                    break;
            }
            switch (baixado.Value.ToString())
            {
                case "Baixado":
                    exp.Add(Restrictions.Eq("Baixado", true));
                    break;
                case "Aberto":
                    exp.Add(Restrictions.Eq("Baixado", false));
                    break;
            }
            return exp;
        }

        private void TituloPeriodoReport_ParametersRequestSubmit(object sender, ParametersRequestEventArgs e)
        {
            bindingSource.DataSource = TituloRepository.GetListAtivos(GetExpression());
        }
    }
}
