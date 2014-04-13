using DevExpress.XtraReports.UI;
using NHibernate.Criterion;

namespace Erp.Relatorios
{
    public partial class BaseLandscape : XtraReport
    {
        public BaseLandscape()
        {
            InitializeComponent();
        }

        public virtual AbstractCriterion GetExpression()
        {
            return null;
        }
    }
}
