using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Windows.Input;
using Erp.Business.Annotations;
using Erp.Business.Dicionary;
using Util.Wpf;
using Vendas.Dictionarys;
using Vendas.Enums;
using Vendas.Properties;

namespace Vendas.ViewModel
{
    public class ConfiguracaoModel : INotifyPropertyChanged
    {
        public ConfiguracaoModel()
        {
            Settings = Settings.Default;
        }
        private FabricanteEcfDictionary _fabricanteEcfDictionary;
        private TipoPdvDictionary _tipoPdvDictionary;
        private Settings _settings;

        public Settings Settings
        {
            get { return _settings ?? (_settings = Settings.Default); }
            set
            {
                if (Equals(value, _settings)) return;
                _settings = value;
                OnPropertyChanged();
            }
        }

        public FabricanteEcfDictionary FabricanteEcfDictionary
        {
            get { return _fabricanteEcfDictionary ?? (_fabricanteEcfDictionary = new FabricanteEcfDictionary()); }
            set
            {
                if (Equals(value, _fabricanteEcfDictionary)) return;
                _fabricanteEcfDictionary = value;
                OnPropertyChanged();
            }
        }

        public TipoPdvDictionary TipoPdvDictionary
        {
            get { return _tipoPdvDictionary ?? (_tipoPdvDictionary = new TipoPdvDictionary()); }
            set
            {
                if (Equals(value, _tipoPdvDictionary)) return;
                _tipoPdvDictionary = value;
                OnPropertyChanged();
            }
        }

        public event PropertyChangedEventHandler PropertyChanged;

        [NotifyPropertyChangedInvocator]
        protected virtual void OnPropertyChanged([CallerMemberName] string propertyName = null)
        {
            PropertyChangedEventHandler handler = PropertyChanged;
            if (handler != null) handler(this, new PropertyChangedEventArgs(propertyName));
        }
        public ICommand CmdSalvar { get { return new RelayCommandBase(x=>Salvar());} }

        private void Salvar()
        {
            Settings.Save();
        }
    }
}
