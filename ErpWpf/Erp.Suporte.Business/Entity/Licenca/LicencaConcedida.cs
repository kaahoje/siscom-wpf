using System;
using System.Runtime.Serialization;
using Util.Seguranca;

namespace Erp.Suporte.Business.Entity.Licenca
{
    [DataContract]
    public class LicencaConcedida:LicencaUso
    {
        [DataMember]
        public virtual string IdMaquinaCliente { get; set; }
        [DataMember]
        public virtual string Documento { get; set; }
        [DataMember]
        public virtual string NomeCliente { get; set; }
        [DataMember]
        public virtual string Logradouro { get; set; }
        [DataMember]
        public virtual string Numero { get; set; }
        [DataMember]
        public virtual string Cep { get; set; }
        [DataMember]
        public virtual string Bairro { get; set; }
        [DataMember]
        public virtual string Mac { get; set; }
        [DataMember]
        public virtual string SistemaOperacional { get; set; }
        [DataMember]
        public virtual string VersaoSistemaOperacional { get; set; }
        [DataMember]
        public virtual string Processador { get; set; }

        public virtual string GetPessoaData()
        {
            return string.Format("{0};{1};{2};{3};{4};{5};",
                Documento,NomeCliente,Logradouro,Numero,Cep,Bairro);
            
        }

        public virtual string GetCodigo()
        {
            var dados = GetPessoaData() + Mac + SistemaOperacional + VersaoSistemaOperacional + Processador;
            return new Criptografia.CriptHash().GetHash(dados);
        }
    }
}
