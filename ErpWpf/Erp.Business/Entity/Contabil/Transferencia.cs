using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using Erp.Business.Annotations;
using Erp.Business.Entity.Sped;
using Erp.Business.Enum;
using Remotion.Linq.Collections;

namespace Erp.Business.Entity.Contabil
{
    public class Transferencia : INotifyPropertyChanged
    {
        private IList<Lancamento> _lancamentos;
        private PlanoContaReferencial _contaDestino;
        private PlanoContaReferencial _contaOrigem;
        private DateTime _dataTransferencia;

        public Transferencia()
        {
            Lancamentos = new ObservableCollection<Lancamento>();
        }

        public virtual int Id { get; set; }

        public virtual DateTime DataTransferencia
        {
            get { return _dataTransferencia; }
            set
            {
                if (value.Equals(_dataTransferencia)) return;
                _dataTransferencia = value;
                OnPropertyChanged();
            }
        }

        public virtual PlanoContaReferencial ContaOrigem
        {
            get { return _contaOrigem; }
            set
            {
                if (Equals(value, _contaOrigem)) return;
                _contaOrigem = value;
                OnPropertyChanged();
            }
        }

        public virtual PlanoContaReferencial ContaDestino
        {
            get { return _contaDestino; }
            set
            {
                if (Equals(value, _contaDestino)) return;
                _contaDestino = value;
                OnPropertyChanged();
            }
        }

        public virtual decimal Valor { get; set; }

        public virtual IList<Lancamento> Lancamentos
        {
            get { return _lancamentos; }
            set
            {
                if (Equals(value, _lancamentos)) return;
                _lancamentos = value;
                OnPropertyChanged();
            }
        }

        public virtual Status Status { get; set; }
        public virtual event PropertyChangedEventHandler PropertyChanged;

        [NotifyPropertyChangedInvocator]
        protected virtual void OnPropertyChanged([CallerMemberName] string propertyName = null)
        {
            var handler = PropertyChanged;
            if (handler != null) handler(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}