using System.ComponentModel.DataAnnotations;

namespace Erp.Business.Enum
{
    public enum TelefoneTipo
    {
        [Display(Name = "Residêncial")]
        Residencial = 1,

        [Display(Name = "Comercial")]
        Comercial = 2,

        [Display(Name = "Fax")]
        Fax = 3,

        [Display(Name = "Móvel")]
        Movel = 4
    }
}
