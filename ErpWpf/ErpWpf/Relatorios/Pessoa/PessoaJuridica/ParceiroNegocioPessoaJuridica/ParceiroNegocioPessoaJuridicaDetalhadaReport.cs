using DevExpress.XtraReports.Parameters;
using Erp.Business.Entity.Contabil.Pessoa.SubClass.PessoaJuridica.SubClass.ParceiroNegocio;

namespace Erp.Relatorios.Pessoa.PessoaJuridica.ParceiroNegocioPessoaJuridica
{
    public partial class ParceiroNegocioPessoaJuridicaDetalhadaReport : PessoaJuridicaDetalhadaReport
    {
        public ParceiroNegocioPessoaJuridicaDetalhadaReport()
        {
            InitializeComponent();
            bindingSource.DataSource = ParceiroNegocioPessoaJuridicaRepository.GetListAtivos();
        }

        private void ParceiroNegocioPessoaJuridicaDetalhadaReport_ParametersRequestSubmit(object sender, ParametersRequestEventArgs e)
        {
            
        }

    }
}
