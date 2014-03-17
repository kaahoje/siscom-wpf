namespace Erp.Business.NotaFiscalEletronica
{
    public class NotaModelo1AReferenciada
    {
        // Código da UF do emitente do documento fiscal.
        public virtual int cUF { get; set; }
        // Ano e mês de missão da NF.
        public virtual int AAMM { get; set; }
        // CNPJ emitente.
        public virtual string CNPJ { get; set; }
        // Modelo do documento fiscal.
        public virtual int mod { get; set; }
        // Série do documento fiscal.
        public virtual int serie { get; set; }
        // Número do documento fiscal.
        public virtual int nNF { get; set; }
    }
}