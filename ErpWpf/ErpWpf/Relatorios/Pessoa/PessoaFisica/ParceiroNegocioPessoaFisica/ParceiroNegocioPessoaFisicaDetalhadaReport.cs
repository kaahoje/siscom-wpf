using DevExpress.XtraReports.Parameters;
using Erp.Business.Entity.Contabil.Pessoa.SubClass.PessoaFisica.SubClass.ParceiroNegocio;

namespace Erp.Relatorios.Pessoa.PessoaFisica.ParceiroNegocioPessoaFisica
{
    public partial class ParceiroNegocioPessoaFisicaDetalhadaReport : PessoaFisicaDetalhadaReport
    {
        public ParceiroNegocioPessoaFisicaDetalhadaReport()
        {
            InitializeComponent();
            bindingSource.DataSource = ParceiroNegocioPessoaFisicaRepository.GetListAtivos();
        }

        private void ParceiroNegocioPessoaFisicaDetalhadaReport_ParametersRequestSubmit(object sender, ParametersRequestEventArgs e)
        {
            
        }

    }
}
