using Erp.Business.Entity.Contabil.Pessoa.SubClass.PessoaJuridica.SubClass.ParceiroNegocio;

namespace Erp.Suporte.Business.Entity.Licenca.PessoaJuridica
{
    public class LicencaUsoPessoaJuridica: LicencaUso
    {
        public virtual ParceiroNegocioPessoaJuridica ParceiroNegocioPessoaJuridica { get; set; }
    }
}
