using System.Security.Cryptography.X509Certificates;
using Erp.Business;
using Erp.Business.Enum;

namespace Erp.Suporte.Business.Entity.Cliente.PessoaJuridica
{
    public class ClientePessoaJuridicaRepository : RepositoryBase<ClientePessoaJuridica>
    {
        public static ClientePessoaJuridica GetByCnpj(string cnpj)
        {
            return GetQueryOver().Where(x => x.Cnpj.Equals(cnpj) && x.Status == Status.Ativo).SingleOrDefault();
        }
    }
}
