using System;
using Erp.Business.Entity.Estoque.Produto.ClassesRelacionadas;

namespace Erp.Business.Entity.Sped
{
    [Serializable]
    public class Ncm
    {
        public virtual int Id { get; set; }
        public virtual string Codigo { get; set; }
        public virtual string Descricao { get; set; }

        
        /// <summary>
        ///     Percentual de tributos sobre o produto de acordo com o IBPT
        ///     para produtos nacionais.
        /// </summary>
        public virtual decimal TributosNacionalIbpt { get; set; }

        /// <summary>
        ///     Percentual de tributos sobre o produto de acordo com o IBPT
        ///     para produtos importados.
        /// </summary>
        public virtual decimal TributosImportadoIbpt { get; set; }

        /// <summary>
        ///     Excessão fiscal segundo o arquivo IBPTTax.
        /// </summary>
        public virtual string ExcessaoFiscal { get; set; }

        /// <summary>
        ///     Tabela a que pertence o código ncm informado segundo o arquivo IBPTTax.
        /// </summary>
        public virtual int Tabela { get; set; }
    }
}