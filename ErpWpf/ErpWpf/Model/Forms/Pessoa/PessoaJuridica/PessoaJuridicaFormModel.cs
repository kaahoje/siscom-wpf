using System;
using System.Windows.Input;
using Erp.Business.Entity.Contabil.Pessoa.ClassesRelacionadas;
using Erp.Business.Entity.Contabil.Pessoa.ClassesRelacionadas.Endereco;
using Erp.Business.Entity.Contabil.Pessoa.SubClass.PessoaJuridica;
using Erp.Business.Enum;
using Erp.Model.Grids;
using Erp.Model.Grids.Pessoa.PessoaJuridica;
using FluentNHibernate.Conventions;
using Util.Wpf;

namespace Erp.Model.Forms.Pessoa.PessoaJuridica
{
    public class PessoaJuridicaFormModel : ModelFormGeneric<Business.Entity.Contabil.Pessoa.SubClass.PessoaJuridica.PessoaJuridica>,IPessoa
    {
        public PessoaJuridicaFormModel()
        {
            Entity = new Business.Entity.Contabil.Pessoa.SubClass.PessoaJuridica.PessoaJuridica();
            ModelSelect = new PessoaJuridicaSelectModel();
        }

        public override void Salvar()
        {
            MensagemErroBancoDados("Não é possível salvar ou editar uma pessoa jurídica.");
        }

        public override void Excluir()
        {
            try
            {
                if (ConfirmDelete())
                {
                    Entity.Status = Status.Excluido;
                    PessoaJuridicaRepository.Save(Entity);
                    Entity = new Business.Entity.Contabil.Pessoa.SubClass.PessoaJuridica.PessoaJuridica();
                    base.Excluir();
                }
            }
            catch (Exception ex)
            {
                MensagemErroBancoDados(ex.Message);
            }
        }

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
            Entity.Enderecos.Add(CurrentEndereco);
            OnPropertyChanged("Entity");
        }

        public void RemoveEndereco()
        {
            Entity.Enderecos.Remove(CurrentEndereco);
            CurrentEndereco = null;
            OnPropertyChanged("Entity");
        }

        public void AddEnderecoEletronico()
        {
            CurrentEnderecoEletronico = new PessoaContatoEletronico();
            Entity.EnderecoEletronicos.Add(CurrentEnderecoEletronico);
            OnPropertyChanged("Entity");
        }

        public void RemoveEnderecoEletronico()
        {
            Entity.EnderecoEletronicos.Remove(CurrentEnderecoEletronico);
            CurrentEnderecoEletronico = null;
            OnPropertyChanged("Entity");
        }

        public void AddContatoTelefonico()
        {
            CurrentContatoTelefonico = new PessoaTelefone();
            Entity.ContatoTelefonicos.Add(CurrentContatoTelefonico);
            OnPropertyChanged("Entity");
        }

        public void RemoveContatoTelefonico()
        {
            Entity.ContatoTelefonicos.Add(CurrentContatoTelefonico);
            CurrentContatoTelefonico = null;
            OnPropertyChanged("Entity");
        }

        public void BuscarEndereco()
        {
            var select = new EnderecoSelectModel();
            select.Filter = CurrentEndereco.Endereco.Cep;
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
    }
}
