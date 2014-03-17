namespace Erp.Business.NotaFiscalEletronica
{
    public class EnderecoDestinatario
    {
        // Logradouro do emitente.
        public string xLgr { get; set; }
        // Número.
        public string nro { get; set; }
        // Complemento
        public string xCpl { get; set; }
        // Bairro
        public string xBairro { get; set; }
        // Código do município.
        public string cMun { get; set; }
        // Nome do município.
        public string xMun { get; set; }
        // Sigla da UF
        public string UF { get; set; }
        // Código do CEP
        public int CEP { get; set; }
        // Código do país
        public int cPais { get; set; }
        // Nome do pais.
        public string xPais { get; set; }
        // Telefone
        public string fone { get; set; }
    }
}