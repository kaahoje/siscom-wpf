using Erp.Business;

namespace Erp.Suporte.Business.Entity.Licenca
{
    public class LicencaConcedidaRepository : RepositoryBase<LicencaConcedida>
    {
        public static LicencaConcedida GetByCodigo(string codigo)
        {
            return GetQueryOver().Where(x => x.Codigo.Equals(codigo)).SingleOrDefault();
        }
    }
}
