using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace Erp.Business.Enum
{
    public enum TipoConta
    {
        [Display(Name = "ANALITICA")] Analitica,
        [Display(Name = "SINTETICA")] Sintetica
    }
}