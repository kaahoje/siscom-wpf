using Erp.Business.Entity.Estoque.Produto;
using Erp.Business.Entity.Estoque.Produto.ClassesRelacionadas;
using Erp.Business.Entity.Sped;
using Erp.Business.Enum;

namespace Erp.Business.Entity.Fiscal.ClassesRelacionadas
{
    public class ProdutoNotaFiscal
    {
        public virtual int Id { get; set; }
        public virtual int Sequencia { get; set; }
        public virtual string CodigoFornecedor { get; set; }
        public virtual decimal Quantidade { get; set; }
        public virtual decimal ValorUnitario { get; set; }
        public virtual decimal BaseIcms { get; set; }
        public virtual decimal ValorIcms { get; set; }
        public virtual decimal ValorIpi { get; set; }
        public virtual OperacaoNotaDaGente TipoOperacaoNotaDaGente { get; set; }

        public virtual IndicadorTotalizacao IndicadorTotalizacao { get; set; }

        public virtual Produto Produto { get; set; }
        public virtual Ncm NCM { get; set; }
        public virtual Cst CST { get; set; }
        public virtual Cfop CFOP { get; set; }
        public virtual Unidade Unidade { get; set; }
        public virtual NotaFiscal NotaFiscal { get; set; }
    }
}