using System.Collections.Generic;
using System.Collections.ObjectModel;
using Erp.Business.Enum;

namespace Erp.Business.Entity.Contabil.ClassesRelacoinadas
{
    public class MesGerado
    {
        public MesGerado()
        {
            Titulos = new ObservableCollection<Titulo>();
        }

        public virtual int Id { get; set; }
        public virtual int Mes { get; set; }
        public virtual int Ano { get; set; }
        public virtual IList<Titulo> Titulos { get; set; }
        public virtual Status Status { get; set; }
    }
}