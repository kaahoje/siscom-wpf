using Erp.Business.Entity.Contabil.Pessoa.SubClass.PessoaFisica.SubClass.ParceiroNegocio;

namespace Erp.Suporte.Business.Entity.Licenca.PessoaFisica
{
    public class LicencaUsoPessoaFisica: LicencaUso
    {
        public virtual ParceiroNegocioPessoaFisica ParceiroNegocioPessoaFisica { get; set; }
    }
}
