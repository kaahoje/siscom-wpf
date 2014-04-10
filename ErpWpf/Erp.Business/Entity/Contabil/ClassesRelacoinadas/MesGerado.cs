using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using Erp.Business.Annotations;
using Erp.Business.Enum;

namespace Erp.Business.Entity.Contabil.ClassesRelacoinadas
{
    public class MesGerado : INotifyPropertyChanged
    {
        private int _mes;
        private int _ano;

        public MesGerado()
        {
            Titulos = new ObservableCollection<Titulo>();
        }

        public virtual int Id { get; set; }

        public virtual int Mes
        {
            get
            {
                if (_mes == 0)
                {
                    _mes = DateTime.Now.Month;
                }
                return _mes;
            }
            set
            {
                if (value == _mes) return;
                _mes = value;
                OnPropertyChanged();
            }
        }

        public virtual int Ano
        {
            get
            {
                _ano = DateTime.Now.Year;
                return _ano;
            }
            set
            {
                if (value == _ano) return;
                _ano = value;
                OnPropertyChanged();
            }
        }

        public virtual IList<Titulo> Titulos { get; set; }
        public virtual Status Status { get; set; }
        public virtual event PropertyChangedEventHandler PropertyChanged;

        [NotifyPropertyChangedInvocator]
        protected virtual void OnPropertyChanged([CallerMemberName] string propertyName = null)
        {
            PropertyChangedEventHandler handler = PropertyChanged;
            if (handler != null) handler(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}