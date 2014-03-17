using System;

namespace Erp.Business.Entity.Fiscal.ClassesRelacionadas
{
    [Serializable]
    public class Cfop
    {
        public virtual int Id { get; set; }
        public virtual int CodigoCfop { get; set; }
        public virtual String Aplicacao { get; set; }
    }
}