namespace Erp.Business.NotaFiscalEletronica
{
    public class NotaProdutorRuralReferenciada
    {
        // Código da UF do emitente do documento fiscal.
        public virtual int cUF { get; set; }
        // Ano e mês de missão da NF.
        public virtual int AAMM { get; set; }
        // CNPJ emitente.
        public virtual string CNPJ { get; set; }
        // CPF do emitente.
        public virtual string CPF { get; set; }
        // IE do emitente.
        public virtual string IE { get; set; }
        // Modelo do documento fiscal.
        public virtual int mod { get; set; }
        // Série do documento fiscal.
        public virtual int serie { get; set; }
        // Número do documento fiscal.
        public virtual int nNF { get; set; }
        // Chave de acesso do CT-e referênciada.
        public virtual string refCTe { get; set; }
    }
}