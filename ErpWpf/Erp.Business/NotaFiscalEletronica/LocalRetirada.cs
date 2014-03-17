using System;

namespace Erp.Business.NotaFiscalEletronica
{
    [Serializable]
    public class LocalRetirada
    {
        public virtual string CNPJ { get; set; }
        public virtual string CPF { get; set; }
        // Logradouro.
        public virtual string xLgr { get; set; }
        // Número.
        public virtual string nro { get; set; }
        // Complemento.
        public virtual string xCpl { get; set; }
        // Bairro.
        public virtual string xBairro { get; set; }
        // Código do município.
        public virtual int cMun { get; set; }
        // Nome do município.
        public virtual string xMun { get; set; }
        // Sigla da UF.
        public virtual string UF { get; set; }
    }
}