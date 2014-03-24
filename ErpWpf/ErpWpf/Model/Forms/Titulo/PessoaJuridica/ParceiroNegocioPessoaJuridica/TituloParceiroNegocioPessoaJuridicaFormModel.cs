using Erp.Business.Entity.Contabil.Pessoa.SubClass.PessoaJuridica.SubClass.ParceiroNegocio.ClassesRelacionadas;
using Erp.Model.Grids.Titulo.PessoaJuridica.ParceiroNegocioPessoaJuridica;

namespace Erp.Model.Forms.Titulo.PessoaJuridica.ParceiroNegocioPessoaJuridica
{
    public class TituloParceiroNegocioPessoaJuridicaFormModel : ModelFormGeneric<TituloParceiroNegocioPessoaJuridica>
    {
        public TituloParceiroNegocioPessoaJuridicaFormModel()
        {
            Entity = new TituloParceiroNegocioPessoaJuridica();
            ModelSelect = new TituloParceiroNegocioPessoaJuridicaSelectModel();
        }
    }
}
