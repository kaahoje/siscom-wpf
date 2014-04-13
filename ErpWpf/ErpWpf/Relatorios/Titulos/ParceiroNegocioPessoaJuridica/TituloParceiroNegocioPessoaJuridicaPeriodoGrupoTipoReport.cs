using DevExpress.XtraReports.Parameters;
using Erp.Business.Entity.Contabil.Pessoa.SubClass.PessoaJuridica.SubClass.ParceiroNegocio.ClassesRelacionadas;

namespace Erp.Relatorios.Titulos.ParceiroNegocioPessoaJuridica
{
    public partial class TituloParceiroNegocioPessoaJuridicaPeriodoGrupoTipoReport : TituloPeriodoGrupoTipoReport
    {
        public TituloParceiroNegocioPessoaJuridicaPeriodoGrupoTipoReport()
        {
            InitializeComponent();
        }

        private void TituloParceiroNegocioPessoaJuridicaPeriodoGrupoTipoReport_ParametersRequestSubmit(object sender, ParametersRequestEventArgs e)
        {
            bindingSource.DataSource = TituloParceiroNegocioPessoaJuridicaRepository.GetListAtivos(GetExpression());
        }

    }
}
