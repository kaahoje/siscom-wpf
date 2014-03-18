using System.ComponentModel.DataAnnotations;

namespace Erp.Business.Enum
{
    public enum EntradaSaida
    {
        [Display(Name = "ENTRADA")]
        Entrada,
        [Display(Name = "SAIDA")] Saida
    }
}