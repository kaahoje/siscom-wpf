using System;
using System.Runtime.Serialization;

namespace RestauranteService.DataContracts
{
    [DataContract]
    public class ParcialMesaDataContract
    {
        [DataMember]
        public virtual Guid IdGuid { get; set; }
        [DataMember]
        public virtual int Mesa { get; set; }
        [DataMember]
        public virtual int IdGarcon { get; set; }
        [DataMember]
        public virtual int CaixaEmissor { get; set; }
        [DataMember]
        public virtual TimeSpan HoraSolicitacao { get; set; }
        [DataMember]
        public virtual TimeSpan HoraImpressao { get; set; }
        public virtual bool Concluida { get; set; }
        public virtual bool Impressa { get; set; }
        
        public ParcialMesaDataContract()
        {
            IdGuid = Guid.NewGuid();
            HoraSolicitacao = DateTime.Now.TimeOfDay;
        }
    }
}