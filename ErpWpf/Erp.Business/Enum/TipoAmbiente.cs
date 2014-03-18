using System.ComponentModel.DataAnnotations;

namespace Erp.Business.Enum
{
    public enum TipoAmbiente
    {
        [Display(Name = "PRODUCAO")] Producao,
        [Display(Name = "TESTES")] Testes
    }
}