using System.ComponentModel.DataAnnotations;

namespace Erp.Business.Enum
{
    public enum NivelRelatorio
    {
        [Display(Name = "OPERACIONAL")]
        Operacional,
        [Display(Name = "ADMINISTRATIVO NIVEL 1")]
        Administrativo1,
        [Display(Name = "ADMINISTRATIVO NIVEL 2")]
        Administrativo2,
        [Display(Name = "ADMINISTRATIVO NIVEL 3")]
        Administrativo3
    }
}