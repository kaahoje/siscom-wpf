using System.Linq;

namespace Erp.Business.Entity.Sistema.Menu
{
    public class SistemaMenuRepository : RepositoryBase<SistemaMenu>
    {
        public static SistemaMenu GetByName(string nome)
        {
            return GetList().SingleOrDefault(x => x.Descricao == nome);
        }
    }
}
