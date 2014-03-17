using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace Erp.Business.Enum
{
    public enum NFeTipoOperacao
    {
        [Display(Name = "ENTRADA")] Entrada,
        [Display(Name = "SAIDA")] Saida
    }
}