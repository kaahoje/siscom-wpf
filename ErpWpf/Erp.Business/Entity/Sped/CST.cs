using System;

namespace Erp.Business.Entity.Sped
{
    [Serializable]
    public class Cst
    {
        public virtual string Codigo { get; set; }
        public virtual string Descricao { get; set; }
        public virtual string Origem { get; set; }
        public virtual string TributacaoIcms { get; set; }
        public virtual string AliquotaIcms { get; set; }
        public virtual string ValorBaseIcms { get; set; }
        public virtual string ValorIcms { get; set; }
        public virtual string ValorBaseIcmsST { get; set; }
        public virtual string ValorIcmsST { get; set; }
        public virtual string ValorReduzidoBase { get; set; }
    }
}