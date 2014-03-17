using System;

namespace Erp.Business.Entity.Sped
{
    [Serializable]
    public class CstPis
    {
        public virtual int Id { get; set; }
        public virtual string Cst { get; set; }
        public virtual string Descricao { get; set; }
    }
}