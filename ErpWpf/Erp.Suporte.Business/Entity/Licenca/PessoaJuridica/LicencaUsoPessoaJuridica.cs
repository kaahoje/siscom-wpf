using Erp.Business.Entity.Contabil.Pessoa.SubClass.PessoaJuridica.SubClass.ParceiroNegocio;
using Erp.Suporte.Business.Entity.Cliente.PessoaJuridica;

namespace Erp.Suporte.Business.Entity.Licenca.PessoaJuridica
{
    public class LicencaUsoPessoaJuridica: LicencaUso
    {
        public virtual ClientePessoaJuridica ParceiroNegocioPessoaJuridica { get; set; }
    }
}
