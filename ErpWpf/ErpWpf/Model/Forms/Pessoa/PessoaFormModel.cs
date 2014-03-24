using System.Collections.ObjectModel;
using System.Windows.Input;
using Erp.Business.Entity.Contabil.Pessoa.ClassesRelacionadas;
using Erp.Business.Entity.Contabil.Pessoa.ClassesRelacionadas.Endereco;
using Erp.Business.Enum;
using Erp.Model.Grids;
using FluentNHibernate.Conventions;
using Util.Wpf;


namespace Erp.Model.Forms.Pessoa
{
    public class PessoaFormModel : ModelFormGeneric<Business.Entity.Contabil.Pessoa.Pessoa>,IPessoa
    {
        private ICommand _cmdAddEndereco;
        private ICommand _cmdRemoveEndereco;
        private ICommand _cmdAddContatoTelefonico;
        private ICommand _cmdRemoveContatoTelefonico;
        private ICommand _cmdAddEnderecoEletronico;
        private ICommand _cmdRemoveEnderecoEletronico;
        private PessoaEndereco _currentEndereco;
        private PessoaContatoEletronico _currentEnderecoEletronico;
        private PessoaTelefone _currentContatoTelefonico;
        private ICommand _cmdBuscarEndereco;
        private string _cep;
        private ObservableCollection<PessoaTelefone> _contatoTelefonicos;
        private ObservableCollection<PessoaContatoEletronico> _enderecoEletronicos;
        private ObservableCollection<PessoaEndereco> _enderecos;

        public ObservableCollection<PessoaEndereco> Enderecos
        {
            get { return _enderecos ?? (_enderecos = new ObservableCollection<PessoaEndereco>()); }
            set
            {
                if (Equals(value, _enderecos)) return;
                _enderecos = value;
                OnPropertyChanged();
            }
        }

        public ObservableCollection<PessoaContatoEletronico> EnderecoEletronicos
        {
            get { return _enderecoEletronicos ?? (_enderecoEletronicos = new ObservableCollection<PessoaContatoEletronico>()); }
            set
            {
                if (Equals(value, _enderecoEletronicos)) return;
                _enderecoEletronicos = value;
                OnPropertyChanged();
            }
        }

        public ObservableCollection<PessoaTelefone> ContatoTelefonicos
        {
            get { return _contatoTelefonicos ?? (_contatoTelefonicos = new ObservableCollection<PessoaTelefone>()); }
            set
            {
                if (Equals(value, _contatoTelefonicos)) return;
                _contatoTelefonicos = value;
                OnPropertyChanged();
            }
        }

        public ICommand CmdAddEndereco
        {
            get { return _cmdAddEndereco ?? (_cmdAddEndereco = new RelayCommandBase(x => AddEndereco())); }
            set
            {
                _cmdAddEndereco = value;
                OnPropertyChanged("CmdAddEndereco");
            }
        }

        public ICommand CmdRemoveEndereco
        {
            get { return _cmdRemoveEndereco ?? (_cmdRemoveEndereco = new RelayCommandBase(x => RemoveEndereco())); }
            set
            {
                _cmdRemoveEndereco = value;
                OnPropertyChanged("CmdRemoveEndereco");
            }
        }

        public ICommand CmdAddContatoTelefonico
        {
            get { return _cmdAddContatoTelefonico ?? (_cmdAddContatoTelefonico = new RelayCommandBase(x => AddContatoTelefonico())); }
            set
            {
                _cmdAddContatoTelefonico = value;
                OnPropertyChanged("CmdAddContatoTelefonico");
            }
        }

        public ICommand CmdRemoveContatoTelefonico
        {
            get { return _cmdRemoveContatoTelefonico ?? (_cmdRemoveContatoTelefonico = new RelayCommandBase(x => RemoveContatoTelefonico())); }
            set
            {
                _cmdRemoveContatoTelefonico = value;
                OnPropertyChanged("CmdRemoveContatoTelefonico");
            }
        }

        public ICommand CmdAddEnderecoEletronico
        {
            get { return _cmdAddEnderecoEletronico ?? (_cmdAddEnderecoEletronico = new RelayCommandBase(x => AddEnderecoEletronico())); }
            set
            {
                _cmdAddEnderecoEletronico = value;
                OnPropertyChanged("CmdAddEnderecoEletronico");
            }
        }

        public ICommand CmdRemoveEnderecoEletronico
        {
            get { return _cmdRemoveEnderecoEletronico ?? (_cmdRemoveEnderecoEletronico = new RelayCommandBase(x => RemoveEnderecoEletronico())); }
            set
            {
                _cmdRemoveEnderecoEletronico = value;
                OnPropertyChanged("CmdRemoveEnderecoEletronico");
            }
        }

        public ICommand CmdBuscarEndereco
        {
            get { return _cmdBuscarEndereco ?? (_cmdBuscarEndereco = new RelayCommandBase(x => BuscarEndereco())); }
            set
            {
                _cmdBuscarEndereco = value;
                OnPropertyChanged();
            }
        }

        public PessoaEndereco CurrentEndereco
        {
            get { return _currentEndereco; }
            set
            {
                _currentEndereco = value;
                OnPropertyChanged("CurrentEndereco");
            }
        }

        public PessoaContatoEletronico CurrentEnderecoEletronico
        {
            get { return _currentEnderecoEletronico; }
            set
            {
                _currentEnderecoEletronico = value;
                OnPropertyChanged("CurrentEnderecoEletronico");
            }
        }

        public PessoaTelefone CurrentContatoTelefonico
        {
            get { return _currentContatoTelefonico; }
            set
            {
                _currentContatoTelefonico = value;
                OnPropertyChanged("CurrentContatoTelefonico");
            }
        }

        public void AddEndereco()
        {
            CurrentEndereco = new PessoaEndereco() { Status = Status.Ativo, TipoEndereco = TipoEndereco.Cobranca };
            Enderecos.Add(CurrentEndereco);
            OnPropertyChanged("Entity");
        }

        public void RemoveEndereco()
        {
            Enderecos.Remove(CurrentEndereco);
            CurrentEndereco = null;
            OnPropertyChanged("Entity");
        }

        public void AddEnderecoEletronico()
        {
            CurrentEnderecoEletronico = new PessoaContatoEletronico();
            EnderecoEletronicos.Add(CurrentEnderecoEletronico);
            OnPropertyChanged("Entity");
        }

        public void RemoveEnderecoEletronico()
        {
            EnderecoEletronicos.Remove(CurrentEnderecoEletronico);
            CurrentEnderecoEletronico = null;
            OnPropertyChanged("Entity");
        }

        public void AddContatoTelefonico()
        {
            CurrentContatoTelefonico = new PessoaTelefone();
            ContatoTelefonicos.Add(CurrentContatoTelefonico);
            OnPropertyChanged("Entity");
        }

        public void RemoveContatoTelefonico()
        {
            ContatoTelefonicos.Remove(CurrentContatoTelefonico);
            CurrentContatoTelefonico = null;
            OnPropertyChanged();
            OnPropertyChanged("Entity");
        }

        public void BuscarEndereco()
        {
            var select = new EnderecoSelectModel();
            select.Filter = Cep;
            if (select.Collection.IsNotEmpty())
            {
                if (select.Collection.Count == 1)
                {
                    CurrentEndereco.Endereco = select.CurrentItem;
                }
                else
                {
                    select.WindowSelect.ShowDialog();
                    CurrentEndereco.Endereco = @select.CurrentItem ?? new Endereco();
                }
            }
            else
            {
                MensagemInformativa("Não existe um endereço que contenha todo ou parte do CEP informado.");
            }
        }

        public string Cep
        {
            get { return _cep; }
            set
            {
                _cep = value;
                OnPropertyChanged("Cep");
            }
        }
    }
}
