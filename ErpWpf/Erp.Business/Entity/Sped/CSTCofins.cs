using System;

namespace Erp.Business.Entity.Sped
{
    [Serializable]
    public class CstCofins
    {
        public virtual int Id { get; set; }
        public virtual string Codigo { get; set; }
        public virtual string Descricao { get; set; }
    }
}