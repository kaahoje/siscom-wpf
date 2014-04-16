using Erp.Business;
using Erp.Business.Enum;

namespace Erp.Suporte.Business.Entity.Cliente.PessoaFisica
{
    public class ClientePessoaFisicaRepository : RepositoryBase<ClientePessoaFisica>
    {
        public static ClientePessoaFisica GetByCpf(string cpf)
        {
            return GetQueryOver().Where(x => x.Cpf.Equals(cpf) && x.Status == Status.Ativo).SingleOrDefault();
        }
    }
}
