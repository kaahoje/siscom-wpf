using System.ComponentModel.DataAnnotations;

namespace Erp.Business.Enum
{
    public enum FabricanteEcf
    {
        [Display(Name = "Não configurado")] NaoConfigurado = 0,
        [Display(Name = "Daruma")] Daruma = 1,
        [Display(Name = "Bematech")] Bematech = 2
    }
}