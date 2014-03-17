using System.ComponentModel.DataAnnotations;

namespace Erp.Business.Enum
{
    public enum TipoEmail
    {
        [Display(Name = "Skype")]
        Skype = 1,

        [Display(Name = "Email")]
        Email = 2,

        [Display(Name = "Msn")]
        Msn = 3
    }
}
