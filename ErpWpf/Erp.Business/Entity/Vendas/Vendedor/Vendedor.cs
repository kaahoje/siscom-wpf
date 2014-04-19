using Erp.Business.Entity.Contabil.Pessoa.SubClass.PessoaFisica.SubClass.ParceiroNegocio;
using Erp.Business.Entity.Trabalhista;
using Erp.Business.Enum;

namespace Erp.Business.Entity.Vendas.Vendedor
{
    public class Vendedor 
    {
        public virtual int Id { get; set; }
        /// <summary>
        /// Parceiro de negócios ao qual está vinculado o vendedor.
        /// </summary>
        public virtual Funcionario Funcionario { get; set; }
        public virtual decimal Comissao { get; set; }
        /// <summary>
        /// Define se o vendedor está escalado para o serviço no dia.
        /// </summary>
        public virtual bool Escalado { get; set; }
        
        /// <summary>
        /// Status do vendedor.
        /// </summary>
        public virtual Status Status { get; set; }
    }
}
