using System;
using Erp.Business.Entity.Sped;
using Erp.Business.Enum;

namespace Erp.Business.Entity.Estoque.Produto.ClassesRelacionadas
{
    [Serializable]
    public class Tributacao
    {
        public virtual int Id { get; set; }
        

        #region Situação tributaria

        public virtual Decimal PisPercentCompra { get; set; }
        public virtual Decimal CofinsPercentCompra { get; set; }
        public virtual Decimal IpiPrecentCompra { get; set; }
        public virtual OperacaoNotaDaGente OperacaoNotaDaGente { get; set; }
        public virtual RegimeTributacao Regime { get; set; }
        public virtual Decimal QtdUnidadeTributavel { get; set; }
        public virtual CstPis SitTribPisCompra { get; set; }
        public virtual CstCofins SitTribCofinsCompra { get; set; }
        public virtual CstIpi SitTribIpiCompra { get; set; }
        public virtual Cst CodigoCst { get; set; }
        public virtual Tipi ExtTipi { get; set; }
        public virtual Unidade UnidadeTributavel { get; set; }

        #endregion

        #region Tributação de icms do cupom fiscal.

        public virtual SituacaoTributaria TipoTributacaoIcms { get; set; }
        public virtual Decimal IcmsDevedor { get; set; }

        #endregion

        #region Tributação de ISS do cupom fiscal.

        public virtual SituacaoTributaria TipoTributacaoIss { get; set; }
        public virtual Decimal IssDevedor { get; set; }

        #endregion
    }
}