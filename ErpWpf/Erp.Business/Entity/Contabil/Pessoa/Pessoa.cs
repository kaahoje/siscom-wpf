using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Runtime.CompilerServices;
using Erp.Business.Annotations;
using Erp.Business.Entity.Contabil.Pessoa.ClassesRelacionadas;
using Erp.Business.Enum;

namespace Erp.Business.Entity.Contabil.Pessoa
{
    [Serializable]
    public class Pessoa : INotifyPropertyChanged
    {
        private IList<PessoaEndereco> _enderecos;
        private IList<PessoaTelefone> _contatoTelefonicos;
        private IList<PessoaContatoEletronico> _enderecoEletronicos;

        public Pessoa()
        { 
            Enderecos = new List<PessoaEndereco>();
            ContatoTelefonicos = new List<PessoaTelefone>();
            EnderecoEletronicos = new List<PessoaContatoEletronico>();
        }

        public virtual int Id { get; set; }

        [Display(Description = "Data em que o cliente foi cadastrado", Name = "Data de cadastro:", Order = 0)]
        [Required(ErrorMessage = Constants.MessageRequiredError)]
        public virtual DateTime DataCadastro { get; set; }


        public virtual IList<PessoaEndereco> Enderecos
        {
            get { return _enderecos; }
            set
            {
                if (Equals(value, _enderecos)) return;
                _enderecos = value;
                OnPropertyChanged();
                OnPropertyChanged("PrimeiroEndereco");
            }
        }

        public virtual IList<PessoaTelefone> ContatoTelefonicos
        {
            get { return _contatoTelefonicos; }
            set
            {
                if (Equals(value, _contatoTelefonicos)) return;
                _contatoTelefonicos = value;
                OnPropertyChanged();
                OnPropertyChanged("PrimeiroTelefone");
            }
        }

        public virtual IList<PessoaContatoEletronico> EnderecoEletronicos
        {
            get { return _enderecoEletronicos; }
            set
            {
                if (Equals(value, _enderecoEletronicos)) return;
                _enderecoEletronicos = value;
                OnPropertyChanged();
                OnPropertyChanged("PrimeiroContatoEletronico");
            }
        }

        public virtual PessoaEndereco PrimeiroEndereco
        {
            get
            {
                return Enderecos.FirstOrDefault();
            }
        }

        public virtual PessoaTelefone PrimeiroTelefone
        {
            get
            {
                return ContatoTelefonicos.FirstOrDefault();
            }
        }

        public virtual PessoaContatoEletronico PrimeiroContatoEletronico
        {
            get
            {
                return EnderecoEletronicos.FirstOrDefault();
            }
        }

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