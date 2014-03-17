using System;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace Erp.Business.Enum
{
    [Serializable]
    public enum TipoProduto
    {
        [Display(Name = "MERCADORIA")] Mercadoria,
        [Display(Name = "PRODUTO")] Produto,
        [Display(Name = "SERVICO")] Servico
    }
}