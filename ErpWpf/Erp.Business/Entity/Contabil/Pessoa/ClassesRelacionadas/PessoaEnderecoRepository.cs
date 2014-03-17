using System.Linq;
using Erp.Business.Enum;

namespace Erp.Business.Entity.Contabil.Pessoa.ClassesRelacionadas
{
    /// <summary>
    /// Classe repositório de "PessoaEndereco".
    /// </summary>
    public class PessoaEnderecoRepository : RepositoryBase<PessoaEndereco>
    {
        public static PessoaEndereco GetPrimeiroEnderecoResidencial()
        {
            var endereco = Session.QueryOver<PessoaEndereco>()
                .List().Where(x => x.TipoEndereco == TipoEndereco.Residencial)
                .Take(1)
                .SingleOrDefault();

            return endereco;
        }
    }
}
