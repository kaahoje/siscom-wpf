using DevExpress.XtraReports.Parameters;
using Erp.Business.Entity.Contabil.Pessoa.SubClass.PessoaJuridica;

namespace Erp.Relatorios.Pessoa.PessoaJuridica
{
    public partial class PessoaJuridicaDetalhadaReport : PessoaDetalhadaReport
    {
        public PessoaJuridicaDetalhadaReport()
        {
            InitializeComponent();
            bindingSource.DataSource = PessoaJuridicaRepository.GetListAtivos();
        }

        private void PessoaJuridicaDetalhadaReport_ParametersRequestSubmit(object sender, ParametersRequestEventArgs e)
        {
            
        }

    }
}
