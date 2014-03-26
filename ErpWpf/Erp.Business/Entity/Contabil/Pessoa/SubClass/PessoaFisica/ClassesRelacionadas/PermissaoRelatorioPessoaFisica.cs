using System.ComponentModel;
using System.Runtime.CompilerServices;
using Erp.Business.Annotations;
using Erp.Business.Enum;

namespace Erp.Business.Entity.Contabil.Pessoa.SubClass.PessoaFisica.ClassesRelacionadas
{
    public class PermissaoRelatorioPessoaFisica : INotifyPropertyChanged
    {

        public virtual Relatorios Relatorio { get; set; }
        public virtual bool Permitido { get; set; }

        public virtual event PropertyChangedEventHandler PropertyChanged;

        [NotifyPropertyChangedInvocator]
        protected virtual void OnPropertyChanged([CallerMemberName] string propertyName = null)
        {
            PropertyChangedEventHandler handler = PropertyChanged;
            if (handler != null) handler(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}
