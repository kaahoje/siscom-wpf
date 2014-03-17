using System;
using System.Collections.Generic;
using Erp.Business.Entity.Sped;
using Erp.Business.Enum;
using Remotion.Linq.Collections;

namespace Erp.Business.Entity.Contabil
{
    public class Transferencia
    {
        public Transferencia()
        {
            Lancamentos = new ObservableCollection<Lancamento>();
        }

        public virtual int Id { get; set; }
        public virtual DateTime DataTransferencia { get; set; }
        public virtual PlanoContaReferencial ContaOrigem { get; set; }
        public virtual PlanoContaReferencial ContaDestino { get; set; }
        public virtual decimal Valor { get; set; }
        public virtual IList<Lancamento> Lancamentos { get; set; }
        public virtual Status Status { get; set; }
    }
}