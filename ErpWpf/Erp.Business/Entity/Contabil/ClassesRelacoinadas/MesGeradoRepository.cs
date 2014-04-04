using System.Linq;

namespace Erp.Business.Entity.Contabil.ClassesRelacoinadas
{
    public class MesGeradoRepository : RepositoryBase<MesGerado>
    {
        public static MesGerado GetByMesAno(int mes, int ano)
        {
            return GetList().SingleOrDefault(x => x.Ano == ano && x.Mes == mes);
        }
    }
}