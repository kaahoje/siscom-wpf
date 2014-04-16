using Erp.Business.Entity.Contabil.Pessoa;
using Erp.Suporte.Business.Entity.Cliente.PessoaFisica;

namespace Erp.Suporte.Business.Entity.Suporte.PessoaFisica
{
    public class SolicitacaoSuportePessoaFisica : SolicitacaoSuporte
    {
        /// <summary>
        /// Informação da empresa que solicitou o suporte.
        /// </summary>
        public virtual ClientePessoaFisica Solicitante { get; set; }
    }
}
