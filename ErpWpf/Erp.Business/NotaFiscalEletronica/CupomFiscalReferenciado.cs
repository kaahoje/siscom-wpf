namespace Erp.Business.NotaFiscalEletronica
{
    public class CupomFiscalReferenciado
    {
        // Modelo do documento fiscal.
        public virtual string mod { get; set; }
        // Número de ordem sequencial do ECF
        public virtual int nECF { get; set; }
        // Número do contador de ordem de operação - COO
        public virtual int nCOO { get; set; }
    }
}