namespace Erp.Business.NotaFiscalEletronica
{
    public class InformacaoReferenciada
    {
        //Chave de acesso da NF-e referenciada.
        public virtual string refNFe { get; set; }
        public virtual NotaModelo1AReferenciada refNF { get; set; }
        public virtual NotaProdutorRuralReferenciada refNFP { get; set; }
    }
}