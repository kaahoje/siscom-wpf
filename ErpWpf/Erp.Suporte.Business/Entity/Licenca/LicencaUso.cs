using System;
using Util.Enum;

namespace Erp.Suporte.Business.Entity.Licenca
{
    public class LicencaUso
    {
        public virtual int Id { get; set; }
        public virtual DateTime DataConcessao { get; set; }
        public virtual DateTime DataRevogacao { get; set; }
        public virtual string CodigoLicenca { get; set; }
        public virtual StatusLicenca Status { get; set; }
    }
}
