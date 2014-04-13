using System.Collections.ObjectModel;
using System.Windows.Input;
using DevExpress.Xpf.Ribbon.Customization;
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

        public override Business.Entity.Contabil.Pessoa.Pessoa Entity
        {
            get { return base.Entity; }
            set
            {
                base.Entity = value;
                Enderecos.Clear();
                EnderecoEletronicos.Clear();
                ContatoTelefonicos.Clear();

                Enderecos.AddRange(Entity.Enderecos);
                EnderecoEletronicos.AddRange(Entity.EnderecoEletronicos);
                ContatoTelefonicos.AddRange(Entity.ContatoTelefonicos);
            }
        }

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
                if (value != null)
                {
                    Cep = value.Endereco.Cep;
                }
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
            CurrentEndereco = new PessoaEndereco()
            {
                Status = Status.Ativo, 
                TipoEndereco = TipoEndereco.Cobranca,
                Pessoa = Entity
            };
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
            CurrentEnderecoEletronico = new PessoaContatoEletronico()
            {
                Pessoa = Entity
            };
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
            CurrentContatoTelefonico = new PessoaTelefone()
            {
                Pessoa = Entity
            };
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
            if (CurrentEndereco != null && CurrentEndereco.Endereco != null && 
                !Cep.Equals(CurrentEndereco.Endereco.Cep))
            {
                if (string.IsNullOrEmpty(Cep) && !string.IsNullOrEmpty(CurrentEndereco.Endereco.Cep))
                {
                    Cep = CurrentEndereco.Endereco.Cep;
                    return;
                }
                select.Filter = Cep;
                // Se houver algum CEP encontrado
                if (select.Collection.IsNotEmpty())
                {
                    // Se o endereço atual for nulo adiciona um.
                    if (CurrentEndereco == null)
                    {
                        AddEndereco();
                    }
                    // Apenas verifica se o endereço atual não é nulo para evitar erros.
                    if (CurrentEndereco != null)
                    {
                        // Se houver apenas um CEP para o valor informado no campo cep então carrega-o.
                        if (select.Collection.Count == 1)
                        {
                            CurrentEndereco.Endereco = select.Collection[0];
                        }
                            // Se houver mais de um endereço para o valor informado no campo CEP abre um dialogo de seleção.
                        else
                        {
                            select.WindowSelect.ShowDialog();
                            // Se o usuário selecionar algum endereço passa para CurrentEndereco se não cria um novo endereço.
                            CurrentEndereco.Endereco = @select.CurrentItem ?? new Endereco();
                        }
                        Cep = CurrentEndereco.Endereco.Cep;
                    }
                }
                else
                {
                    if (!string.IsNullOrEmpty(Cep))
                    {
                        MensagemInformativa("Não existe um endereço que contenha todo ou parte do CEP informado.");}
                    
                }
            }
            
        }

        public string Cep
        {
            get { return _cep ?? (_cep = ""); }
            set
            {
                _cep = value;
                OnPropertyChanged("Cep");
            }
        }
        
    }
}
