using System.ComponentModel;
using System.Runtime.CompilerServices;
using Erp.Business.Annotations;
using Erp.Business.Enum;

namespace Erp.Business.Entity.Contabil.Pessoa.SubClass.PessoaFisica.ClassesRelacionadas
{
    public class PermissaoFormularioPessoaFisica : INotifyPropertyChanged
    {
        private Formulario _formulario;
        private bool _pesquisa;
        private bool _insere;
        private bool _exclui;
        private bool _atualiza;
        private bool _edita;

        public virtual int Id { get; set; }
        public virtual Formulario Formulario
        {
            get { return _formulario; }
            set
            {
                if (value == _formulario) return;
                _formulario = value;
                OnPropertyChanged();
            }
        }

        public virtual bool Pesquisa
        {
            get { return _pesquisa; }
            set
            {
                if (value.Equals(_pesquisa)) return;
                _pesquisa = value;
                OnPropertyChanged();
            }
        }

        public virtual bool Insere
        {
            get { return _insere; }
            set
            {
                if (value.Equals(_insere)) return;
                _insere = value;
                OnPropertyChanged();
            }
        }

        public virtual bool Edita
        {
            get { return _edita; }
            set
            {
                if (value.Equals(_edita)) return;
                _edita = value;
                OnPropertyChanged();
            }
        }

        public virtual bool Exclui
        {
            get { return _exclui; }
            set
            {
                if (value.Equals(_exclui)) return;
                _exclui = value;
                OnPropertyChanged();
            }
        }

        public virtual event PropertyChangedEventHandler PropertyChanged;

        [NotifyPropertyChangedInvocator]
        protected virtual void OnPropertyChanged([CallerMemberName] string propertyName = null)
        {
            PropertyChangedEventHandler handler = PropertyChanged;
            if (handler != null) handler(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}
