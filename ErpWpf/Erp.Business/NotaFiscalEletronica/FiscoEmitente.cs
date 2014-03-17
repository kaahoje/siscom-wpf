using System;

namespace Erp.Business.NotaFiscalEletronica
{
    [Serializable]
    public class FiscoEmitente
    {
        // CNPJ do órgão emitente
        public virtual string CNPJ { get; set; }
        // Órgão emitente
        public virtual string xOrgao { get; set; }
        // Matrícula do agente.
        public virtual string matr { get; set; }
        // Nome do agente
        public virtual string xAgente { get; set; }
        // Telefone
        public virtual string fone { get; set; }
        // Sigla do estado
        public virtual string UF { get; set; }
        // Número do documento de arrecadação de receita.
        public virtual string nDAR { get; set; }
        // Data de emissão do documento de arrecadação.
        public virtual DateTime dEmi { get; set; }
        // Valor do documento de arrecadação.
        public virtual Decimal vDAR { get; set; }
        // Repartição fiscal emitente.
        public virtual string repEmi { get; set; }
        // Data de pagamento do documento de arrecadação.
        public virtual DateTime dPag { get; set; }
    }
}