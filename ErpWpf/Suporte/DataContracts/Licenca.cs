using System;
using System.Runtime.Serialization;
using Util.Enum;
using Util.Seguranca;

namespace Erp.Suporte.DataContracts
{
    [DataContract]
    [Serializable]
    public class Licenca
    {
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
        public virtual StatusLicenca Status { get; set; }
        [DataMember]
        public virtual string Codigo { get; set; }
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

        public virtual string GetPrimeiroCodigo()
        {
            var dados = GetPessoaData() + Environment.OSVersion + Environment.ProcessorCount + Environment.MachineName;
            return new Criptografia.CriptHash().GetHash(dados);
        }
    }
}
