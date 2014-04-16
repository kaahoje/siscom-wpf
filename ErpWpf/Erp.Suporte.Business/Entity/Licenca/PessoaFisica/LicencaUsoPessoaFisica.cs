using Erp.Business.Entity.Contabil.Pessoa.SubClass.PessoaFisica.SubClass.ParceiroNegocio;
using Erp.Suporte.Business.Entity.Cliente.PessoaFisica;

namespace Erp.Suporte.Business.Entity.Licenca.PessoaFisica
{
    public class LicencaUsoPessoaFisica: LicencaUso
    {
        public virtual ClientePessoaFisica ParceiroNegocioPessoaFisica { get; set; }
    }
}
