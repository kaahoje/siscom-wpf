using System.ComponentModel;
using System.Runtime.CompilerServices;
using Erp.Business.Annotations;
using Erp.Business.Enum;

namespace Erp.Business.Entity.Contabil.Pessoa.SubClass.PessoaFisica.ClassesRelacionadas
{
    public class PermissaoRelatorioPessoaFisica : INotifyPropertyChanged
    {
        private Relatorios _relatorio;
        private bool _permitido;
        public virtual int Id { get; set; }

        public virtual Relatorios Relatorio
        {
            get { return _relatorio; }
            set
            {
                if (value == _relatorio) return;
                _relatorio = value;
                OnPropertyChanged();
            }
        }

        public virtual bool Permitido
        {
            get { return _permitido; }
            set
            {
                if (value.Equals(_permitido)) return;
                _permitido = value;
                OnPropertyChanged();
            }
        }

        public virtual event PropertyChangedEventHandler PropertyChanged;

        [NotifyPropertyChangedInvocator]
        protected virtual void OnPropertyChanged([CallerMemberName] string propertyName = null)
        {
            var handler = PropertyChanged;
            if (handler != null) handler(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}
