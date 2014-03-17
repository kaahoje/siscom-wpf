using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using Erp.Business.Entity.Contabil.Pessoa.ClassesRelacionadas;
using Erp.Business.Enum;

namespace Erp.Business.Entity.Contabil.Pessoa
{
    [Serializable]
    public class Pessoa 
    {
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
        
        
      
        
        public virtual IList<PessoaEndereco> Enderecos { get; set; }
        public virtual IList<PessoaTelefone> ContatoTelefonicos { get; set; }
        public virtual IList<PessoaContatoEletronico> EnderecoEletronicos { get; set; }

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
    }
}