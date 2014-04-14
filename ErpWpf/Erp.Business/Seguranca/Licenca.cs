using System;
using Erp.Business.Entity.Contabil.Pessoa.SubClass.PessoaFisica;
using Erp.Business.Entity.Contabil.Pessoa.SubClass.PessoaJuridica;
using Erp.Business.Entity.Contabil.Pessoa.SubClass.PessoaJuridica.SubClass.ParceiroNegocio;
using Erp.Business.Enum;

namespace Erp.Business.Seguranca
{
    [Serializable]
    public class Licenca
    {
        public virtual string Documento { get; set; }
        public virtual string NomeCliente { get; set; }
        public virtual string Logradouro { get; set; }
        public virtual string Numero { get; set; }
        public virtual string Cep { get; set; }
        public virtual string Bairro { get; set; }
        public virtual StatusLicenca Status { get; set; }
        public virtual string Codigo { get; set; }
    }
}
