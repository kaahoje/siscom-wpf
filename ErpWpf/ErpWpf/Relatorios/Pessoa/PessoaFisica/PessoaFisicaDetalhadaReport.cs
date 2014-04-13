using DevExpress.XtraReports.Parameters;
using Erp.Business.Entity.Contabil.Pessoa.SubClass.PessoaFisica;

namespace Erp.Relatorios.Pessoa.PessoaFisica
{
    public partial class PessoaFisicaDetalhadaReport : PessoaDetalhadaReport
    {
        public PessoaFisicaDetalhadaReport()
        {
            InitializeComponent();
            bindingSource.DataSource = PessoaFisicaRepository.GetListAtivos();
        }

        private void PessoaFisicaDetalhadaReport_ParametersRequestSubmit(object sender, ParametersRequestEventArgs e)
        {
            
        }

    }
}
