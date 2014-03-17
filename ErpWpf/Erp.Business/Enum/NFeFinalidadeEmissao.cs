using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace Erp.Business.Enum
{
    public enum NFeFinalidadeEmissao
    {
        [Display(Name = "NORMAL")] Normal,
        [Display(Name = "COMPLEMENTAR")] Complementar,
        [Display(Name = "AJUSTE")] Ajuste
    }
}