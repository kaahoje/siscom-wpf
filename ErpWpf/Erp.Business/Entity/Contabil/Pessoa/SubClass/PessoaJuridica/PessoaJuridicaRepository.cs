using System.Linq;

namespace Erp.Business.Entity.Contabil.Pessoa.SubClass.PessoaJuridica
{
    public class PessoaJuridicaRepository : RepositoryBase<PessoaJuridica>
    {
        public static bool ExisteCnpj(PessoaJuridica entity)
        {
            if (entity.Id == 0)
            {
                if (GetByCnpj(entity.Cnpj) != null)
                {
                    return true;
                }
            }
            
            return false;
        }
        public static PessoaJuridica GetByCnpj(string val)
        {
            return GetList().SingleOrDefault(juridica => juridica.Cnpj == val);
        }

        
    }
}
