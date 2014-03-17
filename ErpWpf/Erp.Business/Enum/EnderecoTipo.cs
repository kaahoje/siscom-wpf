using System.ComponentModel.DataAnnotations;

namespace Erp.Business.Enum
{
    public enum TipoEndereco
    {
        [Display(Name = "Resid�ncial")]
        Residencial = 1,

        [Display(Name = "Correspond�ncia")]
        Correspondencia = 2,

        [Display(Name = "Cobran�a")]
        Cobranca = 3,

        [Display(Name = "Comercial")]
        Comercial = 4,
    }
}