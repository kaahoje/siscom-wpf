using System.Linq;
using Erp.Business.Enum;

namespace Erp.Business.Entity.Contabil.Pessoa.ClassesRelacionadas
{
    /// <summary>
    /// Classe repositório de "ContatoEletronico"
    /// </summary>
    public class PessoaContatoEletronicoRepository : RepositoryBase<PessoaContatoEletronico>
    {
        public static string GetPrimeiroEmail()
        {
            var email = Session.QueryOver<PessoaContatoEletronico>()
                .List()
                .Take(1)
                .SingleOrDefault(x => x.Tipo == TipoEmail.Email);
                
            return email != null ? email.Nick : string.Empty;
        }
    }
}