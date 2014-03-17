using System;
using Erp.Business.Entity.Estoque.Produto;

namespace Erp.Business.NotaFiscalEletronica
{
    [Serializable]
    public class ProdutoNotaFiscal
    {
        [NonSerialized] private int _id;


        public virtual Produto produto { get; set; }

        public virtual string cProd { get; set; }
        public virtual string cEAN { get; set; }
        public virtual string xProd { get; set; }
        public virtual int NCM { get; set; }
        public virtual int EXTIPI { get; set; }
        public virtual int CFOP { get; set; }
        public virtual Decimal uCom { get; set; }
        public virtual Decimal qCom { get; set; }
        public virtual Decimal vUnCom { get; set; }
        public virtual Decimal vProd { get; set; }
        public virtual String cEANTrib { get; set; }
        public virtual String uTrib { get; set; }
        public virtual Decimal qTrib { get; set; }
        public virtual Decimal vUnTrib { get; set; }
        public virtual Decimal vFrete { get; set; }
        public virtual Decimal vSeg { get; set; }
        public virtual Decimal vDesc { get; set; }
        public virtual Decimal vOutro { get; set; }
    }
}