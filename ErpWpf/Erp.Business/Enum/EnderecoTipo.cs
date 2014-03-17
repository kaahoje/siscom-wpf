using System.ComponentModel.DataAnnotations;

namespace Erp.Business.Enum
{
    public enum TipoEndereco
    {
        [Display(Name = "Residêncial")]
        Residencial = 1,

        [Display(Name = "Correspondência")]
        Correspondencia = 2,

        [Display(Name = "Cobrança")]
        Cobranca = 3,

        [Display(Name = "Comercial")]
        Comercial = 4,
    }
}