using System.Linq;

namespace Erp.Business.Entity.Contabil.Pessoa.SubClass.PessoaJuridica
{
    public class PessoaJuridicaRepository : RepositoryBase<PessoaJuridica>
    {
        public static PessoaJuridica GetByCnpj(string val)
        {
            return GetList().SingleOrDefault(juridica => juridica.Cnpj == val);
        }
    }
}
