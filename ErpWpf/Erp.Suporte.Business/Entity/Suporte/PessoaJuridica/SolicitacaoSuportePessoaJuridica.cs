using Erp.Suporte.Business.Entity.Cliente.PessoaJuridica;

namespace Erp.Suporte.Business.Entity.Suporte.PessoaJuridica
{
    public class SolicitacaoSuportePessoaJuridica :SolicitacaoSuporte
    {
        /// <summary>
        /// Informação da empresa que solicitou o suporte.
        /// </summary>
        public virtual ClientePessoaJuridica Solicitante { get; set; }
    }
}
