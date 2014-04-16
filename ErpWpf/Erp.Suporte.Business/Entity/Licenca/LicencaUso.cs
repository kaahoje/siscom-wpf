using System;
using System.Runtime.Serialization;
using Erp.Suporte.Business.Enum;

namespace Erp.Suporte.Business.Entity.Licenca
{
    [DataContract]
    public class LicencaUso
    {
        public virtual int Id { get; set; }
        public virtual DateTime DataConcessao { get; set; }
        public virtual DateTime DataRevogacao { get; set; }
        [DataMember]
        public virtual string Codigo { get; set; }
        [DataMember]
        public virtual StatusLicenca Status { get; set; }
    }
}
