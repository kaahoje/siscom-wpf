using System;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace Erp.Business.Enum
{
    [Serializable]
    public enum OrigemProduto
    {
        [Display(Name = "Nacional")] Nacional,
        [Display(Name = "Estrangeiro")] Estrangeiro,
        [Display(Name = "Estrangeiro de importação indireta")] EstrangeiroIndireto
    }
}