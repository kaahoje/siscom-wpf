using System.Collections.Generic;

namespace Erp.Business.Entity.Sistema.Menu
{
    public class SistemaMenu
    {
        public virtual int Id { get; set; }

        public virtual string Nome { get; set; }

        public virtual string Descricao { get; set; }

        public virtual string Url { get; set; }

        public virtual string PathIcone { get; set; }

        public virtual SistemaMenu MenuMaster { get; set; }
        public virtual bool Habilitado { get; set; }

        public virtual IList<SistemaMenu> SubMenus { get; set; }

        public SistemaMenu()
        {
            SubMenus = new List<SistemaMenu>();
        }
    }
}
