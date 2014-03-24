using Erp.Business.Entity.Contabil.Pessoa.SubClass.PessoaFisica.SubClass.ParceiroNegocio.ClassesRelacionadas;
using Erp.Model.Grids.Titulo.PessoaFisica.ParceiroNegocioPessoaFisica;

namespace Erp.Model.Forms.Titulo.PessoaFisica.ParceiroNegocioPessoaFisica
{
    public class TituloParceiroNegocioPessoaFisicaFormModel : ModelFormGeneric<TituloParceiroNegocioPessoaFisica>
    {
        public TituloParceiroNegocioPessoaFisicaFormModel()
        {
            Entity = new TituloParceiroNegocioPessoaFisica();
            ModelSelect = new TituloParceiroNegocioPessoaFisicaSelecModel();
        }
    }
}
